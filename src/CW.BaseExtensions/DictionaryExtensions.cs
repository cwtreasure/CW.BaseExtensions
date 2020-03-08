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

        /// <summary>
        /// Returns whether the dictionary is null or empty.
        /// </summary>
        /// <param name="dict">dictionary</param>
        /// <returns>is null or empty</returns>
        public static bool IsNullOrEmpty(this Dictionary<string, string> dict)
        {
            return dict == null || !dict.Any();
        }

        /// <summary>
        /// Returns whether the dictionary is not null and empty.
        /// </summary>
        /// <param name="dict">dictionary</param>
        /// <returns>is not null and empty</returns>
        public static bool IsNotNullOrEmpty(this Dictionary<string, string> dict)
        {
            return dict != null && dict.Any();
        }
    }
}
