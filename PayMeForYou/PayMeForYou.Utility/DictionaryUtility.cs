using System.Collections.Generic;
using System.Linq;

namespace PayMeForYou.Utility
{
    public static class DictionaryUtility
    {
        public static string GetValue(Dictionary<string, string> source, string parameterName) => source.ContainsKey(parameterName) ? source[parameterName] : string.Empty;
        public static Dictionary<string, string> ConvertKeyValueStringToDictionary(string keyValueString, char splitCharBetweenKV = '=', char splitCharBetweenKVArray = '&')
        {
            var kvList = keyValueString.Split(splitCharBetweenKVArray);
            var dic = new Dictionary<string, string>();
            foreach (var kv in kvList)
            {
                var kvArray = kv.Split(splitCharBetweenKV);
                if (kvArray.Length == 2 && !dic.ContainsKey(kvArray[0]))
                    dic.Add(kvArray[0], kvArray[1]);
            }
            return dic;
        }
        public static string ConvertToKeyValueString(Dictionary<string, string> dictionary) => dictionary.Select(d => $"{d.Key}={d.Value}").Aggregate((result, next) => $"{result}&{next}");
    }
}
