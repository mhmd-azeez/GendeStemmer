using System;
using System.Collections.Generic;
using System.Text;

namespace GendeStemmer
{
    internal static class Helpers
    {
        internal static bool TryFindChar(StringBuilder builder, char c, int startIndex, out int index)
        {
            for (index = startIndex; index < builder.Length; index++)
            {
                if (builder[index] == c)
                    return true;
            }

            if (index > startIndex)
            {
                return true;
            }

            return false;
        }

        internal static bool TryFindPrefix(string word, IReadOnlyList<string> prefixes, out string prefix)
        {
            return TryFindAffix(word, prefixes, (w, affix) => w.StartsWith(affix), out prefix);
        }

        internal static bool TryFindSuffix(string word, IReadOnlyList<string> suffixes, out string suffix)
        {
            return TryFindAffix(word, suffixes, (w, affix) => w.EndsWith(affix), out suffix);
        }

        internal static bool TryFindInfix(string word, IReadOnlyList<string> infixes, out string infix)
        {
            return TryFindAffix(word, infixes, (w, affix) => w.Contains(affix), out infix);
        }

        internal static bool TryFindAffix(
            string word,
            IReadOnlyList<string> affixes,
            Func<string, string, bool> wordAffixEvaluator,
            out string suffix)
        {
            suffix = null;

            var longestAffix = "";

            foreach (var current in affixes)
            {
                if (wordAffixEvaluator(word, current) && current.Length > longestAffix.Length)
                {
                    longestAffix = current;
                }
            }

            if (longestAffix != "" && longestAffix.Length < word.Length)
            {
                suffix = longestAffix;
                return true;
            }

            return false;
        }
    }
}
