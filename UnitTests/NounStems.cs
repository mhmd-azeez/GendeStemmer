using GendeStemmer;

using Xunit;

namespace UnitTests
{
    public class NounStems
    {
        [Theory]
        [InlineData("مامۆستاکەمان", "مامۆستا")]
        [InlineData("خۆشەویستانمان", "خۆشەویس")]
        [InlineData("بزنەکەشیان", "بزن")]
        [InlineData("بزنەکانیشتان", "بزن")]
        [InlineData("سێوەکانیشیانمان", "سێو")]
        [InlineData("شەشەمینیشیان", "شەش")]
        [InlineData("پێنجەم", "پێنج")]
        [InlineData("هەمانبێت", "هە")]
        [InlineData("هەیانبووبێت", "هە")]
        [InlineData("برسیەتی", "برس")]
        [InlineData("سێوەکانیشتان", "سێو")]
        [InlineData("سێوێکی", "سێو")]
        public void Stems(string input, string expected)
        {
            var actual = Stemmer.StemWord(input);
            Assert.Equal(expected, actual);
        }
    }
}
