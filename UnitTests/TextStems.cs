using GendeStemmer;

using Xunit;

namespace UnitTests
{
    public class TextStems
    {
        [Fact]
        public void SimpleSentence1()
        {
            var input = "سڵاویشمان لێیان کرد";
            var expected = "سڵاو لێ کرد";

            var actual = Stemmer.Stem(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SimpleSentence7()
        {
            var input = "سڵاومان گەیاندە هەموویان";
            var expected = "سڵاو گەیاند هەموو";

            var actual = Stemmer.Stem(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SimpleSentence2()
        {
            var input = "زۆرمان هەوڵدا بچین لەگەڵیان";
            var expected = "زۆر هەوڵ چ لەگەڵ";

            var actual = Stemmer.Stem(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SimpleSentence3()
        {
            var input = "نووسەرێکی بەریتانیی بە رەچەڵەک ئەفریقی خەڵاتی نۆبڵی بۆ ئەدەب بردەوە";
            var expected = "نووسەر بەر بە رەچەڵەک فرق خەڵا نۆبڵ بۆ ئەدەب رد";

            var actual = Stemmer.Stem(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SimpleSentence4()
        {
            var input = "میوزیکی کوردی و چیکی لە قەڵای هەولێر پێشکێشدەکرێت";
            var expected = "میوزیک کورد و چیک لە قەڵا هەولێر پێشکێشدەکر";

            var actual = Stemmer.Stem(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SimpleSentence5()
        {
            var input = "لە سلێمانی شەقامێک بە ناوی نووسەر و رۆژنامەنووس مستەفا ساڵح کەریم دەکرێت";
            var expected = "لە سلێ شەقا بە ناو نووسەر و رۆژنامەنووس مستەفا ساڵح کەر کر";

            var actual = Stemmer.Stem(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SimpleSentence6()
        {
            var input = "73یەمین رێوڕەسمی خەڵاتی ئێمی بۆ بەرهەمە تەلەڤزیۆنییەکان بەڕێوەچوو";
            var expected = "73 رێوڕەس خەڵا ئێم بۆ بەره تەلەڤزیۆ بەڕێوەچوو";

            var actual = Stemmer.Stem(input);

            Assert.Equal(expected, actual);
        }
    }
}
