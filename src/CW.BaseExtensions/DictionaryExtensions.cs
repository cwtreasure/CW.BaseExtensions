namespace System
{
    using System.Collections.Generic;
    using System.Linq;

    public static class DictionaryExtensions
    {
        /// <summary>
        /// Returns the query string of the Url.
        /// </summary>
        /// <param name="dict">The query string parmaters</param>
        /// <returns>The query string.</returns>
        public static string ToQueryString(this Dictionary<string, string> dict)
        {
            if (dict == null || !dict.Any()) return string.Empty;

            var list = new List<string>();

            foreach (var item in dict) list.Add($"{item.Key}={item.Value}");

            return string.Join("&", list);
        }
    }
}
