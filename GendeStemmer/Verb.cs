using System;
using System.Collections.Generic;
using System.Linq;

namespace GendeStemmer
{
    internal static class Verb
    {

        private static readonly IReadOnlyList<string> _prefixes = @"
ب
نە
مە
دە
ئە
بش
دەش
ئەش
".Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        private static readonly IReadOnlyList<string> _infixes = @"
مان
تان
یان
م
ت
ی

نە
".Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        private static readonly IReadOnlyList<string> _suffixes = @"
ەوە

م
ین
ن
ی
ات
ێت
بێت
بوو
با
".Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        private static readonly IReadOnlyList<string> _invalidSuffixes = @"
ان
مان
تان
تی
چوون
یی
".Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        internal static bool IsVerb(string word)
        {
            foreach (var c in word)
            {
                if (char.IsDigit(c))
                    return false;
            }

            foreach (var invalidSuffix in _invalidSuffixes)
            {
                if (word.EndsWith(invalidSuffix))
                    return false;
            }

            var score = 0;

            foreach (var prefix in _prefixes)
            {
                if (word.StartsWith(prefix))
                {
                    score++;
                    break;
                }
            }

            foreach (var infix in _infixes)
            {
                if (infix.Length <= 1) continue;

                var index = word.IndexOf(infix);

                if (index == -1 || index + infix.Length == word.Length)
                    continue;

                score++;
                break;
            }


            var hasSuffixPoint = false;
            string noSuffix = word;
            foreach (var suffix in _suffixes)
            {
                if (suffix != "ن" && word.EndsWith(suffix))
                {
                    if (!hasSuffixPoint)
                    {
                        score++;
                        hasSuffixPoint = true;
                    }

                    noSuffix = noSuffix.Substring(0, word.Length - suffix.Length);
                    foreach (var invalidSuffix in _invalidSuffixes)
                    {
                        if (noSuffix.EndsWith(invalidSuffix))
                            return false;
                    }

                    break;
                }
            }

            var minimumScore = 2;

            return score >= minimumScore;
        }

        internal static string Stem(string verb)
        {
            var iteration = 0;

            var infixReplaced = false;

            while (verb.Length > 2)
            {
                if (Helpers.TryFindPrefix(verb, _prefixes, out var prefix) && iteration == 0)
                {
                    verb = verb.Substring(prefix.Length);
                }
                if (Helpers.TryFindSuffix(verb, _suffixes, out var suffix))
                {
                    verb = verb.Substring(0, verb.Length - suffix.Length);
                }
                if (!infixReplaced && Helpers.TryFindInfix(verb, _infixes, out var infix))
                {
                    verb = verb.Replace(infix, "");
                    infixReplaced = true;
                }
                else
                {
                    break;
                }

                iteration++;
            }

            return verb;
        }
    }
}
