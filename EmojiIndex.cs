using System;
using System.Collections.Generic;
using System.Linq;

using Emoji = Centvrio.Emoji;

namespace FantasyCharacterBot
{
    public static class EmojiIndex
    {
        [Flags]
        public enum EmojiFlags
        {
            Face = 1 << 0,
            Clothing = 1 << 1,
            Sign = 1 << 2,
        }

        public static string GetRandomEmoji(EmojiFlags flags)
        {
            Random rand = new Random();
            IEnumerable<EmojiEntry> matches = emojiIndex.Where(e => e.mFlags.HasFlag(flags));
            EmojiEntry selection = matches.ElementAt(rand.Next(matches.Count()));

            return selection.mEmoji.ToString();
        }

        class EmojiEntry
        {
            public EmojiEntry(Emoji.UnicodeString emoji, EmojiFlags flags)
            {
                mEmoji = emoji;
                mFlags = flags;
            }

            public readonly Centvrio.Emoji.UnicodeString mEmoji;
            public readonly EmojiFlags mFlags;
        }

        static EmojiEntry[] emojiIndex = {
            new EmojiEntry( Emoji.Person.Man, EmojiFlags.Face ),
            new EmojiEntry( Emoji.Person.Adult, EmojiFlags.Face ),
            new EmojiEntry( Emoji.Person.Woman, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Mage, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Mage, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Fairy, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Genie, EmojiFlags.Face ),
            new EmojiEntry( Emoji.Clothing.BalletShoes, EmojiFlags.Clothing ),
            new EmojiEntry( Emoji.Clothing.Coat, EmojiFlags.Clothing ),
            new EmojiEntry( Emoji.Clothing.Crown, EmojiFlags.Clothing ),
            new EmojiEntry( Emoji.Clothing.Dress, EmojiFlags.Clothing ),
            new EmojiEntry( Emoji.Clothing.Glasses, EmojiFlags.Clothing ),
            new EmojiEntry( Emoji.Clothing.ManShoe, EmojiFlags.Clothing ),
            new EmojiEntry( Emoji.Clothing.Scarf, EmojiFlags.Clothing ),
            new EmojiEntry( Emoji.Clothing.TopHat, EmojiFlags.Clothing ),
            new EmojiEntry( Emoji.Clothing.WomanBoot, EmojiFlags.Clothing ),
            new EmojiEntry( Emoji.Clothing.Gloves, EmojiFlags.Clothing ),

            new EmojiEntry( Emoji.Zodiac.Aquarius, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Aries, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Cancer, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Capricorn, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Gemini, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Leo, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Libra, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Ophiuchus, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Pisces, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Sagittarius, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Scorpius, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Taurus, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.Zodiac.Virgo, EmojiFlags.Sign ),

            new EmojiEntry( Emoji.AnimalMammal.Rat, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Ox, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Tiger, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Rabbit, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalReptile.Dragon, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalReptile.Snake, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Horse, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Goat, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Monkey, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalBird.Rooster, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Dog, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Pig, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Cat, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalReptile.Turtle, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.AnimalMammal.Elephant, EmojiFlags.Sign ),

            new EmojiEntry( Emoji.SkyAndWeather.Fire, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.SkyAndWeather.WaterWave, EmojiFlags.Sign ),
        };
    }
}