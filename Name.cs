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

            using (StreamReader file = File.OpenText("FantasyCharacterNames.txt"))
            {
                string line = file.ReadLine();
                while (line != null)
                {
                    chain.Add(line);
                    line = file.ReadLine();
                }
            }
            return chain;
        }

    }
}