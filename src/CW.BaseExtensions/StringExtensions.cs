namespace System
{
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;

    public static class StringExtensions
    {
        /// <summary>
        /// Get a string with default value.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>string</returns>
        public static string GetDefaultIfEmpty(this string input, string defaultValue)
            => input.IsNullOrWhiteSpace() ? defaultValue : input;

        /// <summary>
        /// Indicates whether this string isn't null or white space string.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>bool</returns>
        public static bool IsNotNullOrWhiteSpace(this string input)
            => !input.IsNullOrWhiteSpace();

        /// <summary>
        /// Indicates whether this string is null or white space string.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>bool</returns>
        public static bool IsNullOrWhiteSpace(this string input)
            => string.IsNullOrWhiteSpace(input);

        /// <summary>
        /// Return the length of this string.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>length</returns>
        public static int GetLength(this string input)
            => string.IsNullOrWhiteSpace(input) ? 0 : input.Length;

        /// <summary>
        /// Indicates whether this string is boolean.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>is boolean or not</returns>
        public static bool IsBoolean(this string input)
           => bool.TryParse(input, out _);

        /// <summary>
        /// Indicates whether this string is boolean.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="result">The Parsed result</param>
        /// <returns>is boolean or not</returns>
        public static bool IsBoolean(this string input, out bool result)
            => bool.TryParse(input, out result);

        /// <summary>
        /// Indicates whether this string is datetime.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>is datetime or not</returns>
        public static bool IsDateTime(this string input)
           => DateTime.TryParse(input, out _);

        /// <summary>
        /// Indicates whether this string is datetime.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="result">The Parsed result</param>
        /// <returns>is datetime or not</returns>
        public static bool IsDateTime(this string input, out DateTime result)
            => DateTime.TryParse(input, out result);

        /// <summary>
        /// Indicates whether this string is datetime.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="format">Specify format</param>
        /// <returns>is datetime or not</returns>
        public static bool IsDateTime(this string input, string format)
            => DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

        /// <summary>
        /// Indicates whether this string is datetime.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="format">Specify format</param>
        /// <param name="result">Parsed result</param>
        /// <returns>is datetime or not</returns>
        public static bool IsDateTime(this string input, string format, out DateTime result)
            => DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

        /// <summary>
        /// Indicates whether this string is double.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>is double or not</returns>
        public static bool IsDouble(this string input)
           => double.TryParse(input, out _);

        /// <summary>
        /// Indicates whether this string is double.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="result">Parsed result</param>
        /// <returns>is double or not</returns>
        public static bool IsDouble(this string input, out double result)
            => double.TryParse(input, out result);

        /// <summary>
        /// Indicates whether this string is int32.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>is int32 or not</returns>
        public static bool IsInt32(this string input)
           => int.TryParse(input, out _);

        /// <summary>
        /// Indicates whether this string is int32.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="result">Parsed result</param>
        /// <returns>is int32 or not</returns>
        public static bool IsInt32(this string input, out int result)
            => int.TryParse(input, out result);

        /// <summary>
        /// Indicates whether this string is int64.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>is int64 or not</returns>
        public static bool IsInt64(this string input)
            => long.TryParse(input, out _);

        /// <summary>
        /// Indicates whether this string is int64.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="result">Parsed result</param>
        /// <returns>is int64 or not</returns>
        public static bool IsInt64(this string input, out long result)
            => long.TryParse(input, out result);

        /// <summary>
        /// Converts this string to datetime.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>Parsed result</returns>
        public static DateTime ToDateTime(this string input)
          => input.IsDateTime(out DateTime result) ? result : DateTime.MinValue;

        /// <summary>
        /// Converts this string to datetime.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="format">Speify format</param>
        /// <returns>Converted result</returns>
        public static DateTime ToDateTime(this string input, string format)
            => input.IsDateTime(format, out DateTime result) ? result : DateTime.MinValue;

        /// <summary>
        /// Converts this string to double.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>Converted result</returns>
        public static double ToDouble(this string input)
            => input.IsDouble(out double result) ? result : 0;

        /// <summary>
        /// Converts this string to int32.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>Converted result</returns>
        public static int ToInt32(this string input)
            => input.IsInt32(out int result) ? result : 0;

        /// <summary>
        /// Converts this string to int64.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>Converted result</returns>
        public static long ToInt64(this string input)
           => input.IsInt64(out long result) ? result : 0;

        /// <summary>
        /// Indicates whether this string is equal the compared string ignore case.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="comparedString">Compared string</param>
        /// <returns>is equal or not</returns>
        public static bool EqualsIgnoreCase(this string input, string comparedString)
            => input.Equals(comparedString, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Format the input with args
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="args">Args</param>
        /// <returns>Formated result</returns>
        public static string Format(this string input, params object[] args)
            => string.Format(input, args);

        /// <summary>
        /// Converts this string to base64.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>Converted result</returns>
        public static string ToBase64(this string input)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

        /// <summary>
        /// Converts this base64 to string.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>Converted result</returns>
        public static string FromBase64(this string input)
            => Encoding.UTF8.GetString(Convert.FromBase64String(input));

        /// <summary>
        /// Converts this string to md5.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="upperCase">Is upper case or not</param>
        /// <returns>Converted result</returns>
        public static string ToMd5(this string input, bool upperCase = false)
            => HashHelper.GetMd5(input, upperCase);

        /// <summary>
        /// Converts this string to sha1.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <param name="upperCase">Is upper case or not</param>
        /// <returns>Converted result</returns>
        public static string ToSha1(this string input, bool upperCase = false)
            => HashHelper.GetSha1(input, upperCase);

        /// <summary>
        /// Adds / to end of given string if it does not ends with the char.
        /// </summary>
        /// <param name="input">A input string</param>
        /// <returns>String</returns>
        public static string EnsureEndWithSlash(this string input)
            => input.EndsWith("/", StringComparison.Ordinal) ? input : $"{input}/";

        public static string Left(this string input, int len)
            => input.Length < len ? input : input.Substring(0, len);

        public static string Right(this string input, int len)
            => input.Length < len ? input : input.Substring(input.Length - len, len);

        public static string TruncateWithPostfix(this string input, int maxLength)
            => TruncateWithPostfix(input, maxLength, "...");

        public static byte[] GetBytes(this string input)
            => Encoding.UTF8.GetBytes(input);

        public static string TruncateWithPostfix(this string input, int maxLength, string postfix)
        {
            if (input.IsNullOrWhiteSpace() || maxLength == 0)
            {
                return string.Empty;
            }

            if (input.Length <= maxLength)
            {
                return input;
            }

            if (maxLength <= postfix.Length)
            {
                return postfix.Left(maxLength);
            }

            return input.Left(maxLength - postfix.Length) + postfix;
        }
    }
}
