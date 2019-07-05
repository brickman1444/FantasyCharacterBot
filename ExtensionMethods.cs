using System.Linq;
using System.Collections.Generic;

namespace FantasyCharacterBot
{
    public static class ExtensionMethods
    {
        public static bool HasDuplicateEntries<T>( this IEnumerable<T> enumerable)
        {
            return enumerable.Count() != enumerable.Distinct().Count();
        }
    }
}