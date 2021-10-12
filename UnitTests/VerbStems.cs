using GendeStemmer;

using Xunit;

namespace UnitTests
{
    public class VerbStems
    {
        [Theory]
        [InlineData("بیانخۆ", "خۆ")]
        [InlineData("دەیانخۆم", "خۆ")]
        [InlineData("ئەتانخۆن", "خۆ")]
        [InlineData("بمانبەخشن", "بەخش")]
        [InlineData("بشتانبەخشین", "بەخش")]
        public void Stems(string input, string expected)
        {
            var actual = Stemmer.StemWord(input);
            Assert.Equal(expected, actual);
        }
    }
}
