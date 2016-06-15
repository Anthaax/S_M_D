########################################################### 
# AUTHOR  : Marius / Hican - http://www.hican.nl - @hicannl  
# DATE    : 26-06-2012  
# COMMENT : Search zip files for specific files and extract
#           them to a (temp) directory.
###########################################################

#ERROR REPORTING ALL
Param(
[string]$destination
)
Set-StrictMode -Version latest

#----------------------------------------------------------
#STATIC VARIABLES
#----------------------------------------------------------
$search = "dll"
$dest = ""
$zips   = $PSScriptRoot

#----------------------------------------------------------
#FUNCTION GetZipFileItems
#----------------------------------------------------------
Function GetZipFileItems
{
  Param([string]$zip)
  
  $split = $split.Split(".") 
  If (!(Test-Path $dest))
  {
    Write-Host "Created folder : $dest"
    $strDest = New-Item $dest -Type Directory
  }

  $shell   = New-Object -Com Shell.Application
  $zipItem = $shell.NameSpace($zip)
  $items   = $zipItem.Items()
  GetZipFileItemsRecursive $items
}

#----------------------------------------------------------
#FUNCTION GetZipFileItemsRecursive
#----------------------------------------------------------
Function GetZipFileItemsRecursive
{
  Param([object]$items)

  ForEach($item In $items)
  {
    If ($item.GetFolder -ne $Null)
    {
      GetZipFileItemsRecursive $item.GetFolder.items()
    }
    $strItem = [string]$item.Name
    If ($strItem -Like "*$search*")
    {
      If ((Test-Path ($dest + "\" + $strItem)) -eq $False)
      {
        Write-Host "Copied file : $strItem from zip-file : $zipFile to destination folder"
        $shell.NameSpace($dest).CopyHere($item)
      }
      Else
      {
        Write-Host "File : $strItem already exists in destination folder"
      }
    }
  }
}

#----------------------------------------------------------
#FUNCTION GetZipFiles
#----------------------------------------------------------
Function GetZipFiles
{
  $zipFiles = Get-ChildItem -Path $zips -Recurse -Filter "*.zip" | % { $_.DirectoryName + "\$_" }
  
  ForEach ($zipFile In $zipFiles)
  {
    $split = $zipFile.Split("\")[-1]
    Write-Host "Found zip-file : $split"
    GetZipFileItems $zipFile
	Write-Host "Press any key to continue ..."
	$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

  }
}

#----------------------------------------------------------
#FUNCTION GetVersion
#----------------------------------------------------------
Function GetVersion
{
	$file = "version.txt"
	$version = ""

	$emplacementFile = "$zips/$file"
	$myFile = get-content $emplacementFile

	foreach ($UneLigne in $myFile){
		Write-Host $UneLigne
		$version = $UneLigne
	}
	DowloadZip $version
}
#----------------------------------------------------------
#FUNCTION DowloadZip
#----------------------------------------------------------
Function DowloadZip
{
	Param([string]$version)
	
	$url = "https://www.myget.org/F/s_m_d-core/api/v2/package/S_M_D/$version"
	Invoke-WebRequest -Uri $url -OutFile "$zips/S_M_D.zip"
}
#----------------------------------------------------------
#FUNCTION SuppressZip
#----------------------------------------------------------
Function SuppressZip
{
	Remove-Item "$zips/S_M_D.zip"
}


#RUN SCRIPT 
$dest = $destination
GetVersion
GetZipFiles
SuppressZip
#Finished
