using Cake.Common;
using Cake.Common.Solution;
using Cake.Common.IO;
using Cake.Common.Tools.NUnit;
using Cake.Common.Tools.MSBuild;
using Cake.Common.Tools.NuGet;
using Cake.Core;
using Cake.Common.Diagnostics;
using Cake.Common.Text;
using Cake.Common.Tools.NuGet.Pack;
using Cake.Common.Tools.OpenCover;
using System;
using System.Linq;
using Cake.Core.Diagnostics;
using Cake.Common.Tools.NuGet.Push;
using Cake.Core.IO;
using SimpleGitVersion;
using System.Collections.Generic;

namespace CodeCake
{
    /// <summary>
    /// Sample build "script".
    /// Build scripts can be decorated with AddPath attributes that inject existing paths into the PATH environment variable. 
    /// </summary>
    [AddPath( "CodeCakeBuilder/Tools" )]
    [AddPath( "packages/**/tools*" )]
    // The following one is a sample, but the two previous ones are useful: 
    // the first one finds the nuget.exe that bootstrap.ps1 downloads and uses, 
    // the second one enables to find tools that can be installed as NuGet packages in a solution.
    // You may keep this sample AddPath since unexisting paths are actually ignored.
    public class Build : CodeCakeHost
    {
        public Build()
        {
            // The configuration ("Debug", etc.) defaults to "Release".
            var configuration = Cake.Argument( "configuration", "Release" );

            // Git .ignore file should ignore this folder.
            // Here, we name it "Releases" (default , it could be "Artefacts", "Publish" or anything else, 
            // but "Releases" is by default ignored in https://github.com/github/gitignore/blob/master/VisualStudio.gitignore.
            var releasesDir = Cake.Directory( "CodeCakeBuilder/Releases" );

            var projectsToPublish = Cake.ParseSolution( "S_M_D.sln" )
                                        .Projects
                                        .Where( p => p.Name != "CodeCakeBuilder"
                                                     && !p.Path.Segments.Contains( "Tests" ) );
            SimpleRepositoryInfo gitInfo = null;

            Task( "Check-Repository" )
                .Does( () =>
                {
                    gitInfo = Cake.GetSimpleRepositoryInfo();
                    if (!gitInfo.IsValid) throw new Exception( "Repository is not ready to be published." );
                    configuration = gitInfo.IsValidRelease && gitInfo.PreReleaseName.Length == 0 ? "Release" : "Debug";

                    Cake.Information( "Publishing {0} projects with version={1} and configuration={2}: {3}",
                        projectsToPublish.Count(),
                        gitInfo.SemVer,
                        configuration,
                        String.Join( ", ", projectsToPublish.Select( p => p.Name ) ) );
                } );

            Task( "Clean" )
                .IsDependentOn( "Check-Repository" )
                .Does( () =>
                {
                    // Avoids cleaning CodeCakeBuilder itself!
                    Cake.CleanDirectories( "**/bin/" + configuration, d => !d.Path.Segments.Contains( "CodeCakeBuilder" ) );
                    Cake.CleanDirectories( "**/obj/" + configuration, d => !d.Path.Segments.Contains( "CodeCakeBuilder" ) );
                    Cake.CleanDirectories( releasesDir );
                } );

            Task( "Restore-NuGet-Packages" )
                .IsDependentOn( "Clean" )
                .Does( () =>
                {
                    // Reminder for first run.
                    // Bootstrap.ps1 ensures that Tools/nuget.exe exists
                    // and compiles this CodeCakeBuilder application in Release mode.
                    // It is the first thing that a CI should execute in the initialization phase and
                    // once done bin/Release/CodeCakeBuilder.exe can be called to do its job.
                    // (Of course, the following check can be removed and nuget.exe be conventionnaly located somewhere else.)
                    if (!Cake.FileExists( "CodeCakeBuilder/Tools/nuget.exe" ))
                    {
                        throw new Exception( "Please execute Bootstrap.ps1 first." );
                    }

                    Cake.Information( "Restoring nuget packages for existing .sln files at the root level.", configuration );
                    foreach (var sln in Cake.GetFiles( "*.sln" ))
                    {
                        Cake.NuGetRestore( sln );
                    }
                } );

            Task( "Build" )
                .IsDependentOn( "Clean" )
                .IsDependentOn( "Restore-NuGet-Packages" )
                .Does( () =>
                {
                    Cake.Information( "Building all existing .sln files at the root level with '{0}' configuration (excluding this builder application).", configuration );
                    foreach (var sln in Cake.GetFiles( "*.sln" ))
                    {
                        using (var tempSln = Cake.CreateTemporarySolutionFile( sln ))
                        {
                            // Excludes "CodeCakeBuilder" itself from compilation!
                            tempSln.ExcludeProjectsFromBuild( "CodeCakeBuilder" );
                            Cake.MSBuild( tempSln.FullPath, new MSBuildSettings()
                                    .SetConfiguration( configuration )
                                    .SetVerbosity( Verbosity.Minimal )
                                    .SetMaxCpuCount( 1 ) );
                        }
                    }
                } );

            Task( "Unit-Testing" )
                 .IsDependentOn( "Build" )
                 .Does( () =>
                 {
                     Cake.NUnit( "*.Tests/bin/" + configuration + "/*.Tests.dll", new NUnitSettings()
                     {
                         Framework = "v4.5",
                         StopOnError = true
                     }
                     );

                 } );
            Task( "Code-Coverage" )
                .IsDependentOn( "Unit-Testing" )
                .Does( () =>
                {
                    Cake.OpenCover(
                        c => c.NUnit("*.Tests/bin/" + configuration + "/*.Tests.dll", new NUnitSettings { Framework = "v4.5" } ),
                        new FilePath( "/CoverageResult.txt" ),
                        new OpenCoverSettings()
                            .WithFilter( "+[S_M_D]*" ) );
                }
                );

            Task("Create-NuGet-Packages")
                .IsDependentOn("Build")
                .Does(() =>
               {
                   Cake.CreateDirectory(releasesDir);
                   var settings = new NuGetPackSettings()
                   {
                       // Hard coded version!?
                       // Cake offers tools to extract the version number from a ReleaseNotes.txt.
                       // But other tools exist: have a look at SimpleGitVersion.Cake to easily 
                       // manage Constrained Semantic Versions on Git repositories.
                       Version = gitInfo.NuGetVersion,
                       BasePath = Cake.Environment.WorkingDirectory,
                       OutputDirectory = releasesDir,
                       Properties = new Dictionary<string, string> { { "configuration", configuration } }
                   };
                   foreach (var nuspec in Cake.GetFiles("CodeCakeBuilder/NuSpec/*.nuspec"))
                   {
                       Cake.NuGetPack(nuspec, settings);
                   }

               });

            // We want to push on NuGet only the Release packages.
            Task("Push-NuGet-Packages")
                .IsDependentOn("Create-NuGet-Packages")
                .WithCriteria(() => configuration == "Release")
                .Does(() =>
               {
                    // Resolve the API key: if the environment variable is not found
                    // AND CodeCakeBuilder is running in interactive mode (ie. no -nointeraction parameter),
                    // then the user is prompted to enter it.
                    // This is specific to CodeCake (in Code.Cake.dll).
                    var apiKey = Cake.InteractiveEnvironmentVariable("MYGET_API_KEY");
                   if (string.IsNullOrEmpty(apiKey)) throw new InvalidOperationException("Could not resolve NuGet API key.");

                   var settings = new NuGetPushSettings
                   {
                       Source = "https://www.myget.org/F/s_m_d-core/api/v2/package",
                       ApiKey = apiKey
                   };

                   foreach (var nupkg in Cake.GetFiles(releasesDir.Path + "/*.nupkg"))
                   {
                       Cake.NuGetPush(nupkg, settings);
                   }
               });

            Task( "Default" ).IsDependentOn("Push-NuGet-Packages");

        }
    }
}
