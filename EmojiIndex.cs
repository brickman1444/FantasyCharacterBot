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
            Specialty = 1 << 3,
            Familiar = 1 << 4,
            Likes = 1 << 5,
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

            new EmojiEntry( Emoji.AnimalMammal.Rat, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Ox, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Tiger, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Rabbit, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalReptile.Dragon, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalReptile.Snake, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Horse, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Goat, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Monkey, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalBird.Rooster, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Dog, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Pig, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Cat, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalReptile.Turtle, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.AnimalMammal.Elephant, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),

            new EmojiEntry( Emoji.AnimalMammal.UnicornFace, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Skunk, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Badger, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Bat, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.BearFace, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Camel, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Cow, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Deer, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.FoxFace, EmojiFlags.Familiar ),

            new EmojiEntry( Emoji.SkyAndWeather.Fire, EmojiFlags.Sign | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.SkyAndWeather.WaterWave, EmojiFlags.Sign | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Emotion.DashingAway, EmojiFlags.Sign | EmojiFlags.Likes ),

            new EmojiEntry( Emoji.Tool.BowAndArrow, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Tool.CrossedSwords, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Tool.Dagger, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Tool.Pistol, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Tool.Shield, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Tool.Axe, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Tool.Pick, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Tool.Toolbox, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.MusicalInstrument.Banjo, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.MusicalInstrument.Drum, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.MusicalInstrument.Saxophone, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.MusicalInstrument.Violin, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.MusicalInstrument.MusicalKeyboard, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.MusicalInstrument.Trumpet, EmojiFlags.Specialty | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.MusicalInstrument.Guitar, EmojiFlags.Specialty | EmojiFlags.Likes ),

            new EmojiEntry( Emoji.FoodAsian.BentoBox, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodAsian.CookedRice, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodAsian.Dango, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodAsian.Dumpling, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodAsian.FishCakeWithSwirl, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodAsian.FortuneCookie, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodAsian.FriedShrimp, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodAsian.MoonCake, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodAsian.Oden, EmojiFlags.Likes ),
            
            new EmojiEntry( Emoji.FoodVegetable.Eggplant, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodVegetable.Avocado, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodVegetable.Broccoli, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodVegetable.Carrot, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.FoodVegetable.Chestnut, EmojiFlags.Likes ),
        };
    }
}