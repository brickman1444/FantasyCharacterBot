using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

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
            Inventory = 1 << 6,
            Home = 1 << 7,
        }

        public static string GetRandomEmoji(EmojiFlags flags)
        {
            Random rand = new Random();
            IEnumerable<EmojiEntry> matches = emojiIndex.Where(e => e.mFlags.HasFlag(flags));
            EmojiEntry selection = matches.ElementAt(rand.Next(matches.Count()));

            return selection.mEmoji.ToString();
        }

        public static void ValidateEntries()
        {
            HashSet<Emoji.UnicodeString> emoji = new HashSet<Emoji.UnicodeString>();
            foreach ( EmojiEntry entry in emojiIndex )
            {
                Debug.Assert(!emoji.Contains( entry.mEmoji));
                emoji.Add(entry.mEmoji);
            }
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
            new EmojiEntry( Emoji.PersonFantasy.Fairy, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Genie, EmojiFlags.Face ),
            new EmojiEntry( Emoji.CatFace.Grinning, EmojiFlags.Face ),
            new EmojiEntry( Emoji.Person.OlderAdult, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonRole.BeardedPerson, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonRole.PersonWearingTurban, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonRole.Prince, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonRole.Princess, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonRole.WomanHeadscarf, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonActivity.BunnyEars, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Merperson, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Elf, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.MrsClaus, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.SantaClaus, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Vampire, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Zombie, EmojiFlags.Face ),
            new EmojiEntry( Emoji.FaceFantasy.Ghost, EmojiFlags.Face ),
            new EmojiEntry( Emoji.FaceFantasy.AngryWithHorns, EmojiFlags.Face ),
            new EmojiEntry( Emoji.FaceFantasy.AlienMonster, EmojiFlags.Face ),
            new EmojiEntry( Emoji.FaceFantasy.Goblin, EmojiFlags.Face ),
            new EmojiEntry( Emoji.FaceFantasy.Ogre, EmojiFlags.Face ),
            new EmojiEntry( Emoji.FaceFantasy.Robot, EmojiFlags.Face ),
            new EmojiEntry( Emoji.FaceFantasy.Skull, EmojiFlags.Face ),
            new EmojiEntry( Emoji.FaceFantasy.SmilingWithHorns, EmojiFlags.Face ),

            new EmojiEntry( Emoji.Clothing.BalletShoes, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.Coat, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.Crown, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.Dress, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.Glasses, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.ManShoe, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.Scarf, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.TopHat, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.WomanBoot, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.Gloves, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.HikingBoot, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.WomanFlatShoe, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.WomanHat, EmojiFlags.Clothing | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.BilledCap, EmojiFlags.Clothing | EmojiFlags.Inventory ),

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

            new EmojiEntry( Emoji.AnimalMammal.Rat, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes | EmojiFlags.Inventory ),
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
            new EmojiEntry( Emoji.AnimalReptile.Turtle, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.AnimalMammal.Elephant, EmojiFlags.Sign | EmojiFlags.Familiar | EmojiFlags.Likes ),

            new EmojiEntry( Emoji.AnimalMammal.UnicornFace, EmojiFlags.Familiar | EmojiFlags.Face ),
            new EmojiEntry( Emoji.AnimalMammal.Skunk, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Badger, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Bat, EmojiFlags.Familiar | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.AnimalMammal.BearFace, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Camel, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Cow, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Deer, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.FoxFace, EmojiFlags.Familiar ),

            new EmojiEntry( Emoji.SkyAndWeather.Fire, EmojiFlags.Sign | EmojiFlags.Likes ),
            new EmojiEntry( Emoji.SkyAndWeather.WaterWave, EmojiFlags.Sign | EmojiFlags.Likes | EmojiFlags.Home ),
            new EmojiEntry( Emoji.Emotion.DashingAway, EmojiFlags.Sign ),
            new EmojiEntry( Emoji.FaceFantasy.SkullAndCrossbones, EmojiFlags.Sign ),

            new EmojiEntry( Emoji.Tool.BowAndArrow, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Tool.CrossedSwords, EmojiFlags.Specialty | EmojiFlags.Likes  | EmojiFlags.Inventory),
            new EmojiEntry( Emoji.Tool.Dagger, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Tool.Pistol, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Tool.Shield, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Tool.Axe, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Tool.Pick, EmojiFlags.Specialty | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Tool.Toolbox, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.MusicalInstrument.Banjo, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.MusicalInstrument.Drum, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.MusicalInstrument.Saxophone, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.MusicalInstrument.Violin, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.MusicalInstrument.MusicalKeyboard, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.MusicalInstrument.Trumpet, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.MusicalInstrument.Guitar, EmojiFlags.Specialty | EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.OtherSymbols.Sparkle, EmojiFlags.Specialty ),

            new EmojiEntry( Emoji.FoodAsian.BentoBox, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.CookedRice, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.Dango, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.Dumpling, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.FishCakeWithSwirl, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.FortuneCookie, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.FriedShrimp, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.MoonCake, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.Oden, EmojiFlags.Likes | EmojiFlags.Inventory ),
            
            new EmojiEntry( Emoji.FoodVegetable.Eggplant, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Avocado, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Broccoli, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Carrot, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Chestnut, EmojiFlags.Likes | EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.OtherObjects.FuneralUrn, EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.HouseHold.Broom, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.FireExtinguisher, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.SafetyPin, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.LotionBottle, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.Soap, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.RollOfPaper, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.BookPaper.BlueBook, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.BookPaper.Ledger, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.BookPaper.Scroll, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.GemStone, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Clothing.Ring, EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.SkyAndWeather.Sun, EmojiFlags.Home ),
            new EmojiEntry( Emoji.SkyAndWeather.CrescentMoon, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceOther.CircusTent, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceGeographic.BeachWithUmbrella, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceGeographic.Desert, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceGeographic.DesertIsland, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceGeographic.Mountain, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceGeographic.SnowCappedMountain, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceGeographic.Volcano, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceBuilding.Castle, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceBuilding.JapaneseCastle, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceBuilding.DerelictHouse, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceBuilding.Building, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceOther.MilkyWay, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceOther.Tent, EmojiFlags.Home ),
            new EmojiEntry( Emoji.PlaceBuilding.Cityscape, EmojiFlags.Home ),

            new EmojiEntry( Emoji.TransportWater.Sailboat, EmojiFlags.Home ),

        };
    }
}