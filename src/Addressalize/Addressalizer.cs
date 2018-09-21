using Addressalize.StandardData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Addressalize
{
    public class Addressalizer
    {
        public string NormalizeAddress(string source)
        {
            var segments = source.ToUpper().Split(' ');

            var newSegments = segments
                .DictionaryLookupOrDefault(Data.USPS_C1_Street_Suffix_Abbreviations)
                .DictionaryLookupOrDefault(Data.Numbers)
                .DictionaryLookupOrDefault(Data.Directions)
                .DictionaryLookupThenMergeNextOrDefault(Data.Tens)
               ;

            var result = string.Join(" ", newSegments.ToArray());
            return result;
        }
    }

    public static class Extensions
    {
        public static IEnumerable<string> DictionaryLookupOrDefault(this IEnumerable<string> source, Dictionary<string, string> data)
        {
            return source.Select(x => data.ContainsKey(x) ? data[x] : x);
        }
        public static IEnumerable<string> DictionaryLookupThenMergeNextOrDefault(this IEnumerable<string> source,
            Dictionary<string, string> data,
            Func<IEnumerable<string>, int, IEnumerable<string>> changedSegmentFunc = null)
        {
            var updatedSegments = source.DictionaryLookupOrDefault(data)
                .Select((x, i) => x == source.ElementAt(i) ? x : x + source.ElementAt(i + 1));
            return updatedSegments.Where((x, i) => i == 0 || updatedSegments.ElementAt(i - 1) == source.ElementAt(i - 1));
        }
    }
}
