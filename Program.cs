﻿using System;
using System.IO;
using System.Collections.Generic;

using Markov;

namespace FantasyCharacterBot
{
    static class Program
    {
        public static Stream awsLambdaHandler(Stream inputStream)
        {
            Console.WriteLine("starting via lambda");
            Main(new string[0]);
            return inputStream;
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Beginning program");

            Console.WriteLine(NameGenerator.GetFullName());
        }

        static void InitializeTwitterCredentials()
        {
            string consumerKey = System.Environment.GetEnvironmentVariable ("twitterConsumerKey");
            string consumerSecret = System.Environment.GetEnvironmentVariable ("twitterConsumerSecret");
            string accessToken = System.Environment.GetEnvironmentVariable ("twitterAccessToken");
            string accessTokenSecret = System.Environment.GetEnvironmentVariable ("twitterAccessTokenSecret");

            if (consumerKey == null)
            {
                using ( StreamReader fs = File.OpenText( "localconfig/twitterKeys.txt" ) )
                {
                    consumerKey = fs.ReadLine();
                    consumerSecret = fs.ReadLine();
                    accessToken = fs.ReadLine();
                    accessTokenSecret = fs.ReadLine();
                }
            }

            Tweetinvi.Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
        }

        static void TweetQuote( string quote )
        {
            Console.WriteLine("Publishing tweet: " + quote);
            var tweet = Tweetinvi.Tweet.PublishTweet(quote);
        }

        static string GenerateQuote()
        {
            Random rand = new Random();

            int order = 1;
            if ( rand.NextDouble() > 0.5 )
            {
                // Add a small chance of a higher order chain. The higher order chains
                // produce output that is a lot closer to the source text. Too close
                // to have on all the time.
                order = 1;
            }

            Console.WriteLine("order " + order);

            MarkovChain<string> chain = GetChain(order);

            string generatedQuote = string.Join(" ", chain.Chain(rand));
            
            // Truncate long quotes to one sentence
            if ( generatedQuote.Length >= 140 )
            {
                char[] sentenceEnders = new char[] { '.', '!', '?' };

                int earliestSentenceEnderIndex = Int32.MaxValue;
                foreach ( char ender in sentenceEnders )
                {
                    int enderIndex = generatedQuote.IndexOf( ender );
                    if ( enderIndex > 0 && enderIndex < earliestSentenceEnderIndex )
                    {
                        earliestSentenceEnderIndex = enderIndex;
                    }
                }
                Console.WriteLine("truncating quote. Original: " + generatedQuote);

                generatedQuote = generatedQuote.Substring(0,earliestSentenceEnderIndex + 1);
            }

            return generatedQuote;
        }

        static MarkovChain<string> GetChain(int order)
        {
            MarkovChain<string> chain = new MarkovChain<string>(order);

            foreach (string sourceQuote in GetQuotes() )
            {
                string[] words = sourceQuote.Split(' ');
                chain.Add(words);
            }

            return chain;
        }

        // We want the average options per state to be between 1.5 to 2.0 ideally.
        // If it's less than that then we're likely directly quoting the input text.
        static void EvaluateOrders()
        {
            for (int order = 1; order < 5; order++)
            {
                MarkovChain<string> chain = GetChain(order);

                var states = chain.GetStates();
                int numStates = 0;
                int numOptions = 0;
                foreach (ChainState<string> state in states)
                {
                    var nextStates = chain.GetNextStates(state);
                    int terminalWeight = chain.GetTerminalWeight(state);
                    numStates++;
                    numOptions += (nextStates != null ? nextStates.Count : 0);
                    numOptions += (terminalWeight > 0 ? 1 : 0); // If this is a possible termination of the chain, that's one option
                }

                Console.WriteLine("Order: " + order + " NumStates: " + numStates + " NumOptionsTotal: " + numOptions + " AvgOptionsPerState " + ((float)numOptions / (float)numStates));
            }
        }

        static void EvaluateCorpus()
        {
            string[] quotes = GetQuotes();
            Console.WriteLine("NumLines: " + quotes.Length);

            HashSet<string> uniqueWords = new HashSet<string>();
            int numTotalWords = 0;

            foreach ( string line in quotes )
            {
                string[] words = line.Split(' ');

                numTotalWords += words.Length;
                uniqueWords.UnionWith( words );

                foreach ( string word in words )
                {
                    if ( word == null || word == "" )
                    {
                        throw new Exception("Invalid string in corpus.");
                    }
                }
            }

            Console.WriteLine("NumTotalWords: " + numTotalWords);
            Console.WriteLine("NumUniqueWords: " + uniqueWords.Count);
        }
    }
}
