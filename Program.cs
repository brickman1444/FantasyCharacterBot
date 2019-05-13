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

            Console.WriteLine(String.Format(
                "Name: {0}\n"
                + "Look:{1}{2}\n"
                + "Sign:{3}\n"
                + "Specialty:{4}\n"
                + "Familiar:{5}\n"
                + "Likes:{6}{7}{8}\n"
                + "Dislikes:{9}{10}{11}\n"
                + "Inventory:\n"
                + "Home:\n",
                NameGenerator.GetFullName(),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Face),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Clothing),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Sign),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Specialty),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Familiar),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes),
                EmojiIndex.GetRandomEmoji(EmojiIndex.EmojiFlags.Likes) ));
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
    }
}
