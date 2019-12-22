namespace System
{
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;

    public static class StringExtensions
    {
        public static string GetDefaultIfEmpty(this string input, string defaultValue)
            => input.IsNullOrWhiteSpace() ? defaultValue : input;

        public static bool IsNotNullOrWhiteSpace(this string input)
            => !input.IsNotNullOrWhiteSpace();

        public static bool IsNullOrWhiteSpace(this string input)
            => string.IsNullOrWhiteSpace(input);

        public static int GetLength(this string input)
            => string.IsNullOrWhiteSpace(input) ? 0 : input.Length;

        public static bool IsBoolean(this string input)
           => bool.TryParse(input, out _);

        public static bool IsBoolean(this string input, out bool result)
            => bool.TryParse(input, out result);

        public static bool IsDateTime(this string input)
           => DateTime.TryParse(input, out _);

        public static bool IsDateTime(this string input, out DateTime result)
            => DateTime.TryParse(input, out result);

        public static bool IsDateTime(this string input, string format)
            => DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

        public static bool IsDateTime(this string input, string format, out DateTime result)
            => DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

        public static bool IsDouble(this string input)
           => double.TryParse(input, out _);

        public static bool IsDouble(this string input, out double result)
            => double.TryParse(input, out result);

        public static bool IsInt32(this string input)
           => int.TryParse(input, out _);

        public static bool IsInt32(this string input, out int result)
            => int.TryParse(input, out result);

        public static bool IsInt64(this string input)
            => long.TryParse(input, out _);

        public static bool IsInt64(this string input, out long result)
            => long.TryParse(input, out result);

        public static DateTime ToDateTime(this string input)
          => input.IsDateTime(out DateTime result) ? result : DateTime.MinValue;

        public static DateTime ToDateTime(this string input, string format)
            => input.IsDateTime(format, out DateTime result) ? result : DateTime.MinValue;

        public static double ToDouble(this string input)
            => input.IsDouble(out double result) ? result : 0;

        public static int ToInt32(this string input)
            => input.IsInt32(out int result) ? result : 0;

        public static long ToInt64(this string input)
           => input.IsInt64(out long result) ? result : 0;

        public static bool EqualsIgnoreCase(this string input, string comparedString)
            => input.Equals(comparedString, StringComparison.OrdinalIgnoreCase);

        public static string Format(this string input, params object[] args)
            => string.Format(input, args);

        public static string ToBase64(this string input)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

        public static string FromBase64(this string input)
            => Encoding.UTF8.GetString(Convert.FromBase64String(input));

        public static string ToMd5(this string input, bool upperCase = false)
            => GetMd5(input, upperCase);

        public static string ToSha1(this string input)
            => GetSha1(input);

        private static string GetMd5(string str, bool upperCase = false)
        {
            string str_md5_out = string.Empty;
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes_md5_in = Encoding.UTF8.GetBytes(str);
                byte[] bytes_md5_out = md5.ComputeHash(bytes_md5_in);
                str_md5_out = BitConverter.ToString(bytes_md5_out);
                str_md5_out = str_md5_out.Replace("-", "");
                return upperCase ? str_md5_out.ToUpper() : str_md5_out;
            }
        }

        private static string GetSha1(string str)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] bytes_sha1_in = Encoding.UTF8.GetBytes(str);
                byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
                string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
                str_sha1_out = str_sha1_out.Replace("-", "");
                return str_sha1_out;
            }
        }
    }
}
