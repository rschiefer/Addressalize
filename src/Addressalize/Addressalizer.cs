using Addressalize.StandardData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Addressalize
{
    public class Addressalizer
    {
        private readonly string PunctuationToRemoveRegex = @"[.,]";

        public string NormalizeAddress(string source)
        {
            var segments = Regex.Replace(source, this.PunctuationToRemoveRegex, " ").ToUpper().Split(' ').Where(x => string.IsNullOrEmpty(x) == false);

            var newSegments = segments
                .AfterFirstDictionaryLookupOrDefault(Data.USPS_C1_Street_Suffix_Abbreviations)
                .DictionaryLookupAllOrDefault(Data.USPS_C2_Secondary_Unit_Designators)
                .DictionaryLookupAllOrDefault(Data.Numbers)
                .DictionaryLookupAllOrDefault(Data.Directions)
                .DictionaryLookupThenMergeNextOrDefault(Data.Tens)
               ;

            var result = string.Join(" ", newSegments.ToArray());
            return result;
        }
    }

    public static class Extensions
    {
        public static string ReplaceFromDictionaryOrDefault(this string source, Dictionary<string, string> data)
        {
            return data.ContainsKey(source) ? data[source] : source;
        }
        public static IEnumerable<string> DictionaryLookupAllOrDefault(this IEnumerable<string> source, Dictionary<string, string> data)
        {
            return source.Select(x => x.ReplaceFromDictionaryOrDefault(data));
        }
        public static IEnumerable<string> AfterFirstDictionaryLookupOrDefault(this IEnumerable<string> source, Dictionary<string, string> data)
        {
            var segmentsIdsToChange = source.Select((x, i) => new { index = i, inData = data.ContainsKey(x) }).Where((x, i) => x.inData && i > 1).Select(x => x.index);
            return source.Select((x, i) => segmentsIdsToChange.Contains(i) ? x.ReplaceFromDictionaryOrDefault(data) : x);
        }
        public static IEnumerable<string> DictionaryLookupThenMergeNextOrDefault(this IEnumerable<string> source,
            Dictionary<string, string> data,
            Func<IEnumerable<string>, int, IEnumerable<string>> changedSegmentFunc = null)
        {
            var updatedSegments = source.DictionaryLookupAllOrDefault(data)
                .Select((x, i) => x == source.ElementAt(i) ? x : x + source.ElementAt(i + 1));
            return updatedSegments.Where((x, i) => i == 0 || updatedSegments.ElementAt(i - 1) == source.ElementAt(i - 1));
        }
    }
}
