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

        public class CustomJsonLanguageConverter : Tweetinvi.Logic.JsonConverters.JsonLanguageConverter
        {
            public override object ReadJson( Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                return reader.Value != null
                    ? base.ReadJson(reader, objectType, existingValue, serializer)
                    : Tweetinvi.Models.Language.English;
            }
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Beginning program");

            InitializeTwitterCredentials();

            Tweetinvi.Logic.JsonConverters.JsonPropertyConverterRepository.JsonConverters.Remove(typeof(Tweetinvi.Models.Language));
            Tweetinvi.Logic.JsonConverters.JsonPropertyConverterRepository.JsonConverters.Add(typeof(Tweetinvi.Models.Language), new CustomJsonLanguageConverter()); // your brand new json converter with workaround

            //for ( int i = 0; i < 20; i++)
            //{
            //    Console.WriteLine(GetCharacterString());
            //}
            
            Tweet(GetCharacterString());
        }

        static string GetCharacterString()
        {
            string characterString = String.Format(
                "Name: {0}\n"
                + "Look:{1}{2}\n"
                + "Specialty:{3}\n",
                NameGenerator.GetFullName(),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Face),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Clothing),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Specialty));

            Random rand = new Random();

            if (rand.Next() % 2 == 0)
            {
                characterString += "Familiar:" + EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Familiar) + "\n";
            }

            characterString += "Likes: ";

            int numLikes = 2;

            for (int likeIndex = 0; likeIndex < numLikes; likeIndex++)
            {
                characterString += EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes);
            }

            characterString += "\n";

            characterString += "Dislikes: ";

            int numDislikes = 2;

            for (int dislikeIndex = 0; dislikeIndex < numDislikes; dislikeIndex++)
            {
                characterString += EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes);
            }

            characterString += "\n";

            characterString += "Inventory:";

            int numInventoryItems = rand.Next(2,4);

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
