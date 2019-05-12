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
            Face      = 1 << 0,
            Clothing  = 1 << 1,
        }

        public static string GetRandomEmoji( EmojiFlags flags )
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
            new EmojiEntry( Emoji.PersonFantasy.Mage, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Fairy, EmojiFlags.Face ),
            new EmojiEntry( Emoji.PersonFantasy.Genie, EmojiFlags.Face ),
        };
    }
}