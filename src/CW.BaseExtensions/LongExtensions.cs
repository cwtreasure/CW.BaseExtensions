namespace System
{
    public static class LongExtensions
    {
        /// <summary>
        /// Converts a Unix time expressed as the number of seconds/milliseconds that have elapsed since 1970-01-01T00:00:00Z to a System.DateTimeOffset value.
        /// </summary>
        /// <param name="input">A Unix time</param>
        /// <param name="isSec">The numner is seconds or milliseconds, default is seconds</param>
        /// <returns>DateTimeOffset</returns>
        public static DateTimeOffset ToDateTimeOffset(this long input, bool isSec = true)
            => isSec ? DateTimeOffset.FromUnixTimeSeconds(input) : DateTimeOffset.FromUnixTimeMilliseconds(input);

        /// <summary>
        /// Converts a Unix time expressed as the number of seconds/milliseconds that have elapsed since 1970-01-01T00:00:00Z to a System.DateTime value.
        /// </summary>
        /// <param name="input">A Unix time</param>
        /// <param name="isSec">The numner is seconds or milliseconds, default is seconds</param>
        /// <param name="kind">Specifies the datetime kind, default is local.</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this long input, bool isSec = true, DateTimeKind kind = DateTimeKind.Local)
            => isSec
            ? TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), kind == DateTimeKind.Utc ? TimeZoneInfo.Utc : TimeZoneInfo.Local).AddSeconds(input)
            : TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), kind == DateTimeKind.Utc ? TimeZoneInfo.Utc : TimeZoneInfo.Local).AddMilliseconds(input);
    }
}
