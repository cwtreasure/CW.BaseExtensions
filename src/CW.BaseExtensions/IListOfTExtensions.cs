namespace System
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IListOfTExtensions
    {
        /// <summary>
        /// Indicates whether this list is null or empty.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="input">The list.</param>
        /// <returns>true if null or empty, false if not.</returns>
        public static bool IsNullOrEmpty<T>(this IList<T> input)
            => input == null || !input.Any();

        /// <summary>
        ///  Indicates whether this list is not null or empty.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="input">The list.</param>
        /// <returns>true if not null or empty, false if null or empty.</returns>
        public static bool IsNotNullOrEmpty<T>(this IList<T> input)
           => input != null && input.Any();

        /// <summary>
        /// Concatenates all the elements of this list, using the specified separator between each element.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="input">The list.</param>
        /// <param name="separator">The separator.</param>
        /// <returns> A string that consists of the elements in value delimited by the separator string.</returns>
        public static string StringJoin<T>(this IEnumerable<T> input, string separator)
            => string.Join(separator, input);

        /// <summary>
        /// Add a value if this list doesn't contains it already.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="input">The list.</param>
        /// <param name="value">The value.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool AddIfNotContains<T>(this IList<T> input, T value)
        {
            if (!input.Contains(value))
            {
                input.Add(value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Add a range of values to this list that's not already in the ICollection.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="input">The list.</param>
        /// <param name="values">The values.</param>
        public static void AddRangeIfNotContains<T>(this IList<T> input, params T[] values)
        {
            foreach (T value in values)
            {
                if (!input.Contains(value))
                {
                    input.Add(value);
                }
            }
        }
    }
}
