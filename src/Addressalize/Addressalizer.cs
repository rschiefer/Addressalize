using Addressalize.StandardData;
using System;
using System.Diagnostics;
using System.Linq;

namespace Addressalize
{
    public class Addressalizer
    {
        public string NormalizeAddress(string source)
        {
            var segments = source.ToUpper().Split(' ');

            var streetPrefixes = Data.USPS_C1_Street_Suffix_Abbreviations;

            var newSegments = segments
                .Select(s => streetPrefixes.ContainsKey(s) ? streetPrefixes[s] : s)
                .Select(s => Data.Numbers.ContainsKey(s) ? Data.Numbers[s] : s)
                .Select(s => Data.Directions.ContainsKey(s) ? Data.Directions[s] : s)
                .ToArray();

            var result = string.Join(" ", newSegments);
            return result;
        }
    }
}
