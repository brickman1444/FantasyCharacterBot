using Xunit;
using Emoji = Centvrio.Emoji;

namespace FantasyCharacterBot
{
    public static class TestExtensionMethods
    {
        [Fact]
        static void HasNoDuplicates_WhenGivenEmptyList_ReturnsFalse()
        {
            Assert.False(new int[0].HasDuplicateEntries());
        }

        [Fact]
        static void HasNoDuplicates_DetectsDuplicateStrings()
        {
            string[] stringListWithDuplicates = {
                "a",
                "a",
                "b"
            };

            Assert.True(stringListWithDuplicates.HasDuplicateEntries());
        }

        [Fact]
        static void HasNoDuplicates_DetectsEmojiEntriesWithDuplicateKeys()
        {
            EmojiIndex.EmojiEntry[] emojiIndexWithDuplicates =
            {
                new EmojiIndex.EmojiEntry( Emoji.AnimalAamphibian.FrogFace, EmojiIndex.EmojiFlags.Clothing ),
                new EmojiIndex.EmojiEntry( Emoji.AnimalAamphibian.FrogFace, EmojiIndex.EmojiFlags.Face ),
            };

            Assert.True(emojiIndexWithDuplicates.HasDuplicateEntries(new TestEmojiIndex.EmojiEntryByKeyComparer()));
        }
    }
}