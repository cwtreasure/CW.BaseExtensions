namespace System
{
    using System.Collections.Generic;
    using System.Linq;

    public static class DictionaryExtensions
    {
        public static string ToQueryString(this Dictionary<string, string> dict)
        {
            if (dict == null || !dict.Any()) return string.Empty;

            List<string> list = new List<string>();

            foreach (var item in dict)
            {
                list.Add($"{item.Key}={item.Value}");
            }

            return string.Join("&", list);
        }
    }
}
