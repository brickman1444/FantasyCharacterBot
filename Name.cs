using System.IO;
using System.Linq;

using Markov;

namespace FantasyCharacterBot
{
    static class NameGenerator
    {
        public static string GetFullName()
        {
            return GetName() + " " + GetName();
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
            "Meriadoc	",
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
            "Black"
        };
    }
}