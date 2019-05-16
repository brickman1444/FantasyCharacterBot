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
            new EmojiEntry( Emoji.Event.JackOLantern, EmojiFlags.Face ),

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

            new EmojiEntry( Emoji.AnimalAamphibian.FrogFace, EmojiFlags.Familiar | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.AnimalBird.BabyChick, EmojiFlags.Familiar | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.AnimalBird.Bird, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Chicken, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Dove, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Duck, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Eagle, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Flamingo, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Owl, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Parrot, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Peacock, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Penguin, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Swan, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBird.Turkey, EmojiFlags.Familiar ),

            new EmojiEntry( Emoji.AnimalBug.Ant, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.Bug, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.Butterfly, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.Cricket, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.Honeybee, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.LadyBeetle, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.Microbe, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.Mosquito, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.Scorpion, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.Snail, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalBug.Spider, EmojiFlags.Familiar ),

            new EmojiEntry( Emoji.AnimalMammal.Chipmunk, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Ewe, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Giraffe, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Gorilla, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.GuideDog, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.HamsterFace, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Hedgehog, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Hippopotamus, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Kangaroo, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Koala, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Leopard, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.LionFace, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Llama, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Mouse, EmojiFlags.Familiar | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.AnimalMammal.Orangutan, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Otter, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.PandaFace, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Poodle, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Raccoon, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Ram, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Rhinoceros, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Sloth, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.TwoHumpCamel, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.WolfFace, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMammal.Zebra, EmojiFlags.Familiar ),

            new EmojiEntry( Emoji.AnimalMarine.Blowfish, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.Crab, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.Dolphin, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.Fish, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.Lobster, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.Octopus, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.Oyster, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.Shark, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.Shrimp, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.SpiralShell, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.AnimalMarine.SpoutingWhale, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.Squid, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalMarine.TropicalFish, EmojiFlags.Familiar ),

            new EmojiEntry( Emoji.AnimalReptile.Crocodile, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalReptile.Lizard, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalReptile.Sauropod, EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.AnimalReptile.TRex, EmojiFlags.Familiar ),

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

            new EmojiEntry( Emoji.Sport.FishingPole, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Sport.IceSkate, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Sport.MartialArtsUniform, EmojiFlags.Likes | EmojiFlags.Specialty ),
            new EmojiEntry( Emoji.FoodPrepared.Cooking, EmojiFlags.Likes | EmojiFlags.Specialty ),

            new EmojiEntry( Emoji.FoodAsian.BentoBox, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.CookedRice, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.CurryRice, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.Dango, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.Dumpling, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.FishCakeWithSwirl, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.FortuneCookie, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.FriedShrimp, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.MoonCake, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.Oden, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.RiceBall, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.RiceCracker, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.RoastedSweetPotato, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.Spaghetti, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.Sushi, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodAsian.TakeoutBox, EmojiFlags.Likes | EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.FoodFruit.Banana, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Cherries, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Coconut, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Grapes, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.GreenApple, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Kiwi, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Lemon, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Mango, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Melon, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Peach, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Pear, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Pineapple, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.RedApple, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Strawberry, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Tangerine, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Tomato, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodFruit.Watermelon, EmojiFlags.Likes | EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.FoodPrepared.Bacon, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Bagel, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.BaguetteBread, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Bread, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Butter, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.CheeseWedge, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Croissant, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.CutOfMeat, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Egg, EmojiFlags.Likes | EmojiFlags.Inventory | EmojiFlags.Familiar ),
            new EmojiEntry( Emoji.FoodPrepared.Falafel, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.GreenSalad, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.MeatOnBone, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Pancakes, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.PoultryLeg, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Pretzel, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Salt, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Sandwich, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.StuffedFlatbread, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodPrepared.Taco, EmojiFlags.Likes | EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.FoodVegetable.Avocado, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Broccoli, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Carrot, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Chestnut, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Cucumber, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.EarOfCorn, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Eggplant, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Garlic, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.HotPepper, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.LeafyGreen, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Mushroom, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Onion, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Peanuts, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodVegetable.Potato, EmojiFlags.Likes | EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.FoodSweet.BirthdayCake, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.Candy, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.ChocolateBar, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.Cookie, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.Cupcake, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.Custard, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.Doughnut, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.HoneyPot, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.IceCream, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.Lollipop, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.Pie, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.ShavedIce, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.Shortcake, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.FoodSweet.SoftIceCream, EmojiFlags.Likes | EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.Drink.BeerMug, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Drink.BottleWithPoppingCork, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Drink.CocktailGlass, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Drink.GlassOfMilk, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Drink.HotBeverage, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Drink.Sake, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Drink.TeacupWithoutHandle, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Drink.TropicalDrink, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Drink.TumblerGlass, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Drink.WineGlass, EmojiFlags.Likes ),

            new EmojiEntry( Emoji.Event.AdmissionTickets, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Event.Balloon, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Event.CarpStreamer, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Event.Firecracker, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Event.Fireworks, EmojiFlags.Likes ),
            new EmojiEntry( Emoji.Event.Ribbon, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Event.Ticket, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Event.WrappedGift, EmojiFlags.Likes | EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.Game.ChessPawn, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Game.CrystalBall, EmojiFlags.Likes | EmojiFlags.Inventory | EmojiFlags.Specialty ),
            new EmojiEntry( Emoji.Game.FlowerPlayingCards, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Game.GameDie, EmojiFlags.Likes | EmojiFlags.Inventory | EmojiFlags.Specialty ),
            new EmojiEntry( Emoji.Game.Joker, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Game.Kite, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Game.MahjongRedDragon, EmojiFlags.Likes | EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.Game.TeddyBear, EmojiFlags.Likes | EmojiFlags.Inventory | EmojiFlags.Familiar ),
            
            new EmojiEntry( Emoji.Hotel.Luggage, EmojiFlags.Inventory ),
            
            new EmojiEntry( Emoji.LightVideo.Candle, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.LightVideo.DiyaLamp, EmojiFlags.Inventory),
            new EmojiEntry( Emoji.LightVideo.GlassRight, EmojiFlags.Inventory | EmojiFlags.Specialty ),
            new EmojiEntry( Emoji.LightVideo.RedPaperLantern, EmojiFlags.Inventory),
            
            new EmojiEntry( Emoji.Mail.Envelope, EmojiFlags.Inventory),
            new EmojiEntry( Emoji.Mail.Package, EmojiFlags.Inventory),

            new EmojiEntry( Emoji.Medical.AdhesiveBandage, EmojiFlags.Inventory),
            new EmojiEntry( Emoji.Medical.Pill, EmojiFlags.Inventory),
            new EmojiEntry( Emoji.Medical.Stethoscope, EmojiFlags.Specialty),

            new EmojiEntry( Emoji.OtherObjects.FuneralUrn, EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.HouseHold.Broom, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.FireExtinguisher, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.SafetyPin, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.LotionBottle, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.Soap, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.RollOfPaper, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.Razor, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.HouseHold.Sponge, EmojiFlags.Inventory ),

            new EmojiEntry( Emoji.BookPaper.BlueBook, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.BookPaper.GreenBook, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.BookPaper.Newspaper, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.BookPaper.Notebook, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.BookPaper.NotebookWithCover, EmojiFlags.Inventory ),
            new EmojiEntry( Emoji.BookPaper.OrangeBook, EmojiFlags.Inventory ),
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
            new EmojiEntry( Emoji.TransportGround.RailwayCar, EmojiFlags.Home ),

        };
    }
}