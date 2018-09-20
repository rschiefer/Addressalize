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
                .ToArray();

            var result = string.Join(" ", newSegments);
            return result;
        }
    }

    public static class Extensions
    {
        public static IEnumerable<string> DictionaryLookupOrDefault(this IEnumerable<string> source, Dictionary<string, string> data)
        {
            return source.Select(x => data.ContainsKey(x) ? data[x] : x);
        }
    }
}
