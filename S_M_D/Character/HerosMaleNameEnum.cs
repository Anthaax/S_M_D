using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    /// <summary>
    /// Contain all heroes male names
    /// </summary>
    [Serializable]
    public enum HerosMaleNameEnum
    {
        Arsène, Charles, Diego, Dylan, Eli,Elie, Joseph, Marcel, Pablo, Rémi,Rémy, Yacine,Yassin,Yassine, Yann,

        Abel, Basil,Basile, Camille, Eloi, Elouan, Iliès,Ilyes,Yliès, Joshua, Léandre, Logan, Marin, Octave, Owen,Owenn, Tao,Taho, Tim, Younes,Younès,

        Achille, Amine, Armand, Auguste, Célian,Célyan, Clovis, Damien, Félix, Grégoire, Ilan,Ilhan, Jonas, Justin, Léopold, Loïc, Mathew,Matthew, Mayeul, Max, Melvin,Melvyn, Nils, Noan,Nohan, Ylan,Ylann,

        Alex, Andy, Ange, Anthony,Antoni, Ayoub,Ayoube, Emilien, Gatien, Jérémie,Jérémy, Joan,Johan,Johann, Manoa,Manoah, Naïm, Nathaël, Sandro, Télio,Thélio, Zacarie,Zacharie,Zachary,Zackary,Zakary, 

        Aloïs,Aloys, Anaël, Andrea, Aurélien, Brayan,Bryan, Carl,Karl, Etienne, Guillaume, Idris,Idriss,Idryss, Ilian,Ilyan,Ylian, Ilias,Ilyas,Ilyass, Jacques, Joachim,Joakim, Kaïss,Kaïs, Léandro, Lissandro,Lïssandro, Lubin, Malone, Medhi, Sam, Solal, Stan, Swan,Swann, Tony, 

        Alessio, Amir, Archibald,Archybald, Ayden, Balthazar,Balthazard, Constantin, Cyprien, Danny,Dany, David, Edgar, Elian, Eloan, Emmanuel, Ewan, Fares,Faress, Florian, Gaël, Gaëtan, Gwendal, Hippolyte, Ibrahim, Imanol, Jibril,Jibrill, Jimmy, Kélian,Kélyan, Lenzo, Léonard, Lino, Lukas, Marcus, Matt, Mickaël, Nassim, Neven,Nevenn, PaulArthur, Siméon, Térence, Théotime, Ulysse, Vincent, Xavier, Yoan,Yohan,

        Abdallah, Adem, Adrian, Albin, Ali, Alix, Alphonse, Alvin, Ambroise, Anguerrand,Enguerran, Arno, Athanase, Aurèl,Aurèle, Bastian, Bilal, Brice, Célestin, Emine, Ernest, Fabian, Faustin, Firmin, Flavio, Germain, Grégory, Guney,Güney, Gustave, Gwenaël, Harold, Harry, Hector, Ian, Iyad, Jason, JeanBaptiste, Jessy, Jonah, Jordan,Jordane, Joris, Juliano,Julyano, Kalvin,Kalvyn, Kieran,Kierann, LéoPaul, Lisandro,Lizandro, Loukas, Luc, Malek, Manech, Mani,Manny, Manoé, Matheïs, Maximilien, Mewen, Moussa, Nadir, Nahil,Naïl, Nathéo, Paco, Philippe, Pol, Roman, Romaric, Ronan, Sébastien, Soel,Sohel, Sofian,Sofiane, Stanislas, Steven, Süleyman,Suleyman, Teddy, Tilio,Tylio, Tylian, Ugo, Vadim, Waël, Walid, Wassim, Wesley, Wyatt, Yannaël, Yasser, Yassir, Yoen,Yohen, 

        AaronCésar, Abdel, Abdelhak, Abdelkerim, AbdelMaijid, Abdelrahmane, Abdoul, AbouBakar, Abraham, Adame, Adel, Aden, Adonis, Akram, Ahmed, Aïdan, Aidan, Aiden, Aimé, Alan, Alaric, Albara, Albéric, Albert, Alendzo, Ales, Alexian, Alezio, Amazigh, AmbroiseMarie, Anass, Ancelin, André, Andreï, Andrew, Anes, Angel, Angelo, Anwar, Armel, Arnaud, Arthaud, Artus, Artyom, Atakan, Aubin, Ayaan, Ayaz, Ayrton, Barak, Baroine, Barthélemy, Bartholomé, Bassim, Baudoin, Ben, Benoît, Béryl, Bilel, Brieuc, Bruno, Brython, Calix, Calvin, Camron, César, Chahine, Chakib, Chris, ChristErwan, Claude, Clémentin, Cléophas, Colomban, Connor, Cornelius, Cristiano, Cyr, Cyrian, Cyril, Dalil, Damian, Daniel, Dann, Dario, Darius, DavidShilo, Délyo, Deniz, Derek, Désiré, Dexter, Deynis, Diago, Didier, Dimitri, DimitriVadim, Djalil, Djibril, Djiby, Djulian, Donovan, Dorayley, Dorian, Driss, Edan, Eddy, Edzio, Efe, Eilan, Elan, Elann, Eléo, Eliandre, EliasNoah, Eliès, Elijah, Elouann, Elric, EmerickJean, Emeris, Emilio, Emir, Emré, Emrys, Endy,
        EnzoGabriel, EnzoTéo, Eren, Etham, Eudes, Eugène, EvanAël, Eyquem, Eytan, Ezequiel, EzraYanis, Fabien, Fabio, Fastial, Félicien, Ferdinand, Fiodor, Florin, Fodié, Foucauld, Francis, François, FrançoisGuillaume, Frédéric, Gad, Galaad, Gary, Gauvain, Geoffrey, Georges, Gianni, Giovani, Giulian, Guénolé, Guilhem, Habib, Hadés, Hadriel, Hakim, Hamza, Hassib, Hédi, Hiago, Hilaire, Hitcham, Hoël, Horace, Horacio, Houcine, Huseyin, Huseyn, Hylan, Ignazio, Ilyam, Imrane, Iniesta, Isaäk, Iséo, Ishaaq, Ishak, Isham, Ismaël, Ismain, Issa, Issac, Jacob, Jamal, James, JanDi, Jassim, Jayden, Jawed, JeanEmmanuel, JeanVictor, Jeffrey, Jessim, Jiyan, Joffrey, Johnny, Jonathan, Josselin, Jossua, Josué, Juan, Judicaël, Julek, JulesArthur, Julio, Kaan, Kalil, Kameron, Kamil, Karel, Karim, Karol, Kayss, Keith, Kemuel, Ken, Kenan, Kenji, Kéran, Kerem, Kérian, Kervelland, Kévin, Kevlànn, Keyan, Kéziah, Kézian, Khemaïs, KhenzoYlan, Khéphren, Kiméo, Kiyan, Klaus, Kuzey, Kyle, KylianLuc, Laël, Lamine, Lancelot, Laonys, Laurent, Lawson, Leeroy, Lendon, Léolin, Léonid, Lewis, Liham, Livio, Loëvan, Loïd, Loïs, Lonys, Loric, LouisMarie, LouisVianney, Louméo, Lounis, Lounoé, Loup, Lysandre, Maérik, Maëlan, Maévan, Maho, Maïron, Malik, Manolo, Manuarii, Maolan, Marc, MarcAntoine, Marcelino, Marien, Marko, Marlon, Martial, Marvin, Mason, Mathéis, Mathiew, Matthenzo, Matti, Mattia, Maurice, Maxen, Maxendre, Maxens, Maximilan, MayronSoreyn, Medhine, Melih, Melwin, Merit, Merlin, Messi, Messon, Miguèl, Milos, Mohammad, MohamedAdam, MohamedLamine, MohamedYacine, Morgan, Mouad, Mouayed, Moujil, Mourad, Muhamed, Mustafa, Mylann, Nabeel, Nadji, Nao, Naoufel, Nassîm, Nathaniel, Nayel, Nazim, Nélio, Néo, Nylio, Odilon, Orféo, Otis, Pacôme, Paolo, Pâris, Parker, PaulAntoine, PaulEdern, PaulElie, PaulEmile, PaulHenri, PaulMarin, PaulWolf, Philémon, PierreAlexandre, PierreAntoine, PierreEmile, PierreLouis, PolArmand, Prospère, Raoued, Reda, Renan, Riad, Ritchy, Rocco, Rodrique, Romuald, Roshan, Rui, Sabri, Salim, Samed, Sami, Samson, Santino, Savio, SayfEddine, Sayd, Sébastian, Sean, Segal, Seïd, Sendoa, Sévan, Shaheed, Shaïry, Shaun, Silas, Solan, Soleil, Sofyane, Soren, Souhail, Stanley, Sulayman, Sully, Sulyvan, Sunny, Sven, Sylrick, Taylor, Tayron, Teimuraz, Tiégo, Tigran, Timaël, Timao, Timée, Timmy, Timo, Tinaël, Tino, Tiwen, Tiziano, Thayan, Théodore, Théophane, Théophile, Thibo, Thoren, Tobias, Tomy, Tybalt, Tyler, Tyron, Uriel, Valérian, Vaneck, Vladimir, Vladislav, Virgile, Warren, Wejdi, Will, Williams, Wilson, Yaël, YannYves, Yasmin, Yekta, Yéro, Yolann, Youssouf, Youzarsif, Zach, Zack, Zackarian, Zakaria, Zakariya, Zayd, Zeïd, Ziad, Zinedine, Zolan,

    }
}
