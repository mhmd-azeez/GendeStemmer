using System;
using System.Collections.Generic;
using System.Linq;

namespace GendeStemmer
{
    internal static class Noun
    {
        private static IReadOnlyList<string> _suffixes =
            @"
ەکە
ێک
کان
ە
ان
یش
م
ت
ی
مان
تان
یان
دا
ەوە
ی
ن
ێ
ینە
یەکە
کە
ش
تی


تر
ترین

یەم
ەم
ەمین
یەمین

بێت
بوو
بوایە
بووایە
بووبێت
بوبێت
".Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        internal static string Stem(string noun)
        {
            while (noun.Length > 3)
            {
                if (Helpers.TryFindSuffix(noun, _suffixes, out var suffix))
                {
                    noun = noun.Substring(0, noun.Length - suffix.Length);
                }
                else
                {
                    break;
                }
            }

            return noun;
        }
    }
}
