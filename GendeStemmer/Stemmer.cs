using System.Text;

namespace GendeStemmer
{

    public static class Stemmer
    {
        public static string Stem(string text)
        {
            var builder = new StringBuilder(text);

            int index = 0;
            while (index < builder.Length)
            {
                if (Helpers.TryFindChar(builder, ' ', index, out var spaceIndex))
                {
                    var word = builder.ToString(index, spaceIndex - index);
                    builder.Remove(index, word.Length);

                    word = StemWord(word);
                    builder.Insert(index, word);

                    index = index + word.Length + 1;
                }
                else
                {
                    break;
                }
            }

            return builder.ToString();
        }

        public static string StemWord(string word)
        {
            if (Verb.IsVerb(word))
            {
                return Verb.Stem(word);
            }
            else
            {
                return Noun.Stem(word);
            }
        }
    }
}
