using System.Linq;
using Xunit;

namespace FantasyCharacterBot
{
    public class TestName
    {
        [Fact]
        public void AllNamesAreUnique()
        {
            Assert.False( NameGenerator.names.HasDuplicateEntries() );
        }

        [Fact]
        public void AllEpithetsAreUnique()
        {
            Assert.False( NameGenerator.epithets.HasDuplicateEntries() );
        }
    }
}