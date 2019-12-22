namespace System
{
    public static class DateTimeExtensions
    {
        private static readonly string _twentyFourHourFormat = "yyyy-MM-dd HH:mm:ss";
        private static readonly string _lastSecondFormat = "yyyy-MM-dd 23:59:59";

        /* DateTime */

        /// <summary>
        /// Converts the value to yyyy-MM-dd HH:mm:ss format.
        /// </summary>
        /// <param name="input">A DateTime.</param>
        /// <returns>A 24 hour datetime string</returns>
        public static string To24HourString(this DateTime input)
            => input.ToString(_twentyFourHourFormat);

        /// <summary>
        /// Returns the number of seconds that have elapsed since 1970-01-01T00:00:00Z.
        /// </summary>
        /// <param name="input">A DateTime.</param>
        /// <param name="kind">Specifies the datetime kind, default is local.</param>
        /// <returns>The number of seconds that have elapsed since 1970-01-01T00:00:00Z.</returns>
        public static long ToUnixTimeSeconds(this DateTime input, DateTimeKind kind = DateTimeKind.Local)
            => (long)(input - TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), kind == DateTimeKind.Utc ? TimeZoneInfo.Utc : TimeZoneInfo.Local)).TotalSeconds;

        /// <summary>
        /// Returns the number of milliseconds that have elapsed since 1970-01-01T00:00:00.000Z.
        /// </summary>
        /// <param name="input">A DateTime.</param>
        /// <param name="kind">Specifies the datetime kind, default is local.</param>
        /// <returns>The number of milliseconds that have elapsed since 1970-01-01T00:00:00.000Z.</returns>
        public static long ToUnixTimeMilliseconds(this DateTime input, DateTimeKind kind = DateTimeKind.Local)
            => (long)(input - TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), kind == DateTimeKind.Utc ? TimeZoneInfo.Utc : TimeZoneInfo.Local)).TotalMilliseconds;

        /// <summary>
        /// Converts the value of the current System.DateTime object to yyyy-MM-dd 23:59:59 format.
        /// </summary>
        /// <param name="input">A DateTime.</param>
        /// <returns>A datetime string.</returns>
        public static string ToDayLastSecondString(this DateTime input)
            => input.ToString(_lastSecondFormat);

        /// <summary>
        /// Converts to a System.DateTime value that represents the day's last second (xx:xx:xx 23:59:59).
        /// </summary>
        /// <param name="input">A DateTime.</param>
        /// <returns>A value represents the day's last second.</returns>
        public static DateTime ToDayLastSecond(this DateTime input)
            => Convert.ToDateTime(input.ToDayLastSecondString());

        /* DateTimeOffset */

        /// <summary>        /// Converts the value to yyyy-MM-dd HH:mm:ss format.
        /// </summary>
        /// <param name="input">A DateTimeOffset.</param>
        /// <returns>A 24 hour datetime string</returns>
        public static string To24HourString(this DateTimeOffset input)
            => input.ToString(_twentyFourHourFormat);

        /// <summary>
        /// Converts the value to yyyy-MM-dd 23:59:59 format.
        /// </summary>
        /// <param name="input">A DateTimeOffset.</param>
        /// <returns>A datetime string.</returns>
        public static string ToDayLastSecondString(this DateTimeOffset input)
            => input.ToString(_lastSecondFormat);

        /// <summary>
        /// Converts to a System.DateTimeOffset value that represents the day's last second (xx:xx:xx 23:59:59).
        /// </summary>
        /// <param name="input">A DateTimeOffset.</param>
        /// <returns>A value represents the day's last second.</returns>
        public static DateTimeOffset ToDayLastSecond(this DateTimeOffset input)
            => DateTimeOffset.Parse(input.ToDayLastSecondString());
    }
}
