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
                .DictionaryLookupOrDefault(Data.Tens, (s, index) =>
                {
                    var nextSegment = s.ElementAt(index + 1);
                    return s.Where((ss, i) => i != index + 1).Select((ss, i) => i != index ? ss : ss + nextSegment);
                })
                .ToArray();

            var result = string.Join(" ", newSegments);
            return result;
        }
    }

    public static class Extensions
    {
        public static IEnumerable<string> DictionaryLookupOrDefault(this IEnumerable<string> source, Dictionary<string, string> data, Func<IEnumerable<string>, int, IEnumerable<string>> changedSegmentFunc = null)
        {
            var changedSegmentIds = new List<int>();
            var output = source.Select((x, index) =>
            {
                if (data.ContainsKey(x))
                {
                    changedSegmentIds.Add(index);
                    return data[x];
                }
                else
                {
                    return x;                    
                }
            });
            if (changedSegmentFunc != null)
            {
                output = output.ToArray();
                foreach (var index in changedSegmentIds)
                {
                    output = changedSegmentFunc(output, index);
                }
            }
            return output;
        }
    }
}
