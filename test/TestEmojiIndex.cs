using System.Collections.Generic;
using Xunit;

namespace FantasyCharacterBot
{
    public static class TestEmojiIndex
    {
        class EmojiEntryByKeyComparer : IEqualityComparer<EmojiIndex.EmojiEntry>
        {
            public bool Equals(EmojiIndex.EmojiEntry a, EmojiIndex.EmojiEntry b)
            {
                return a.mEmoji == b.mEmoji;
            }

            public int GetHashCode(EmojiIndex.EmojiEntry entry)
            {
                return entry.mEmoji.GetHashCode();
            }
        }

        [Fact]
        public static void EmojiIndex_DoesntContainDuplicateEntries()
        {
            Assert.False(EmojiIndex.emojiIndex.HasDuplicateEntries(new EmojiEntryByKeyComparer()));
        }
    }
}