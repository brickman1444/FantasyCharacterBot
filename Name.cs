using System;
using System.IO;
using System.Linq;

using Markov;

namespace FantasyCharacterBot
{
    static class NameGenerator
    {
        public static string GetFullName()
        {
            Random rand = new Random();

            if ( rand.Next() % 2 == 0)
            {
                return GetName() + " " + GetName();
            }
            else
            {
                return GetName() + " " + GetEpithet();
            }
        }

        static string GetName()
        {
            MarkovChain<char> chain = GetChain();

            string name = new string(chain.Chain().ToArray());

            return name;
        }

        static MarkovChain<char> GetChain()
        {
            MarkovChain<char> chain = new MarkovChain<char>(2);

            foreach (string name in names)
            {
                chain.Add(name);
            }
            return chain;
        }

        static string GetEpithet()
        {
            Random rand = new Random();
            return epithets.ElementAt(rand.Next(epithets.Count()));
        }

        static string[] names = {
            "Grignr",
            "Agafnd",
            "Zanilia",
            "Carthena",
            "Drizzt",
            "Dourden",
            "Elminster",
            "Iggwilv",
            "Raistlin",
            "Majere",
            "Mordenkainen",
            "Soth",
            "Strahd",
            "Zarovich",
            "Blackleaf",
            "Elfstar",
            "Osric",
            "Daphne",
            "Luster",
            "Flynn",
            "Therin",
            "Mort",
            "Agrippa",
            "Kemnon",
            "Drazuul",
            "Isogrivs",
            "Maglevs",
            "Ida",
            "Idris",
            "Meriadoc",
            "Arwen",
            "Denethor",
            "Eowyn",
            "Eomer",
            "Faramir",
            "Grima",
            "Theoden",
            "Elrond",
            "Celeborn",
            "Galadriel",
            "Lipwig",
            "Nanny",
            "Rincewind",
            "Susan",
            "Sto",
            "Helit",
            "Vetinari",
            "Vimes",
            "Weatherwax",
            "Sideways",
            "Didactylos",
            "Harridan",
            "Aberforth",
            "Umbridge",
            "Raven",
            "Gideon",
            "Rubeus",
            "Zabini",
            "Scabior",
            "Aladdin",
            "Badroulbadour",
            "Mustapha",
            "Sinbad",
            "Jafar",
            "Harun",
            "Sun",
            "Wukong",
            "Tripitaka",
            "Zhu",
            "Bajie",
            "Sha",
            "Wujing",
            "Elric",
            "Harcourt",
            "Brace",
            "Inigo",
            "Montoya",
            "Humperdinck",
            "Rugen",
            "Vizzini",
            "Fezzik",
            "Westley",
            "Buttercup",
            "Starkiller",
            "Black",
            "Bluetooth",
            "Curtmantle",
            "Greyfell",
            "Lunalilo",
            "Adu",
            "Muhungu",
            "Kitamba",
            "Makeda",
            "Stiffener",
            "K'Chain",
            "Zeddicus",
            "Feyre",
            "Xaro",
            "Yue",
            "Fei",
            "Mulan",
            "Han",
            "Xin",
            "Mu",
            "Guiying",
            "Zarqa",
            "Lemminki",
            "Arash",
            "Kaveh",
            "Thanh",
            "Giong",
        };

        static string[] epithets = {
            "the Able",
            "the Accursed",
            "the Affable",
            "the Ambitious",
            "the Ancient",
            "the Beloved",
            "the Bewitched",
            "the Blessed",
            "the Bold",
            "the Boneless",
            "the Brash",
            "the Brave",
            "the Broad-shouldered",
            "the Capable",
            "the Careless",
            "the Candid",
            "the Ceremonious",
            "the Chaste",
            "the Courteous",
            "the Cruel",
            "the Damned",
            "the Desired",
            "the Determined",
            "the Elder",
            "the Eloquent",
            "the Enlightened",
            "the Exile",
            "the Fair",
            "the Fearless",
            "the Fortunate",
            "from Outerseas",
            "the Generous",
            "the Gentle",
            "the Good",
            "of Good Memory",
            "the Grim",
            "the Hammer",
            "the Hardy",
            "the Hopeful",
            "the Ill-Tempered",
            "the Illustrious",
            "the Indolent",
            "the Invicible",
            "the Just",
            "the Kind-Hearted",
            "the Last",
            "the Learned",
            "the Lover of Elegance",
            "the Mad",
            "the Magnanimous",
            "the Memorable",
            "the Merry",
            "the Mild",
            "the Mighty",
            "the Noble",
            "the Outlaw",
            "the Peaceful",
            "the Pilgrim",
            "the Proud",
            "the Prudent",
            "the Purple-Born",
            "the Quarreller",
            "the Quiet",
            "the Rash",
            "the Reformer",
            "the Righteous",
            "the Sacrificer",
            "of the Seven Parts",
            "the Silent",
            "the Spirited",
            "the Strong",
            "the Terrible",
            "the Tough",
            "the Treacherous",
            "the Tremulous",
            "the Unavoidable",
            "the Unlucky",
            "the Unready",
            "the Vain",
            "the Valiant",
            "the Weak",
            "the Wicked",
            "the Wise",
            "the Younger",
        };
    }
}