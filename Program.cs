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

            InitializeTwitterCredentials();

            EmojiIndex.ValidateEntries();

            //Console.WriteLine(GetCharacterString());
            Tweet(GetCharacterString());
        }

        static string GetCharacterString()
        {
            string characterString = String.Format(
                "Name: {0}\n"
                + "Look:{1}{2}\n"
                + "Sign:{3}\n"
                + "Specialty:{4}\n",
                NameGenerator.GetFullName(),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Face),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Clothing),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Sign),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Specialty));

            Random rand = new Random();

            if (rand.Next() % 2 == 0)
            {
                characterString += "Familiar:" + EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Familiar) + "\n";
            }

            characterString += String.Format(
                "Likes:{0}{1}{2}\n"
                + "Dislikes:{3}{4}{5}\n",
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes));

            int numInventoryItems = rand.Next(1,7);

            characterString += "Inventory:";

            for ( int inventoryItemIndex = 0; inventoryItemIndex < numInventoryItems; inventoryItemIndex++)
            {
                characterString += EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Inventory);
            }

            characterString += "\n";

            characterString += "Home:" + EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Home);

            return characterString;
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

        static void Tweet( string text )
        {
            Console.WriteLine("Publishing tweet: " + text);
            var tweet = Tweetinvi.Tweet.PublishTweet(text);
        }
    }
}
