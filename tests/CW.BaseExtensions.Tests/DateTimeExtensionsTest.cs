namespace CW.BaseExtensions.Tests
{
    using System;
    using Shouldly;
    using Xunit;

    public class DateTimeExtensionsTest
    {
        [Fact]
        public void DateTime_To24HourString_Should_Succeed()
        {
            var input = new DateTime(2019, 11, 11, 18, 0, 0, DateTimeKind.Local);

            var str = input.To24HourString();

            str.ShouldBe("2019-11-11 18:00:00");
        }

        [Theory]
        [InlineData(1573495200L)]
        public void DateTime_ToUnixTimeSeconds_Should_Succeed(long second)
        {
            var input = new DateTime(2019, 11, 11, 18, 0, 0);

            var unixTime = input.ToUnixTimeSeconds();

            unixTime.ShouldBe(second);
        }

        [Theory]
        [InlineData(1573495200000L)]
        public void DateTime_ToUnixTimeMilliseconds_Should_Succeed(long second)
        {
            var input = new DateTime(2019, 11, 11, 18, 0, 0);

            var unixTime = input.ToUnixTimeMilliseconds();

            unixTime.ShouldBe(second);
        }

        [Fact]
        public void DateTime_ToDayLastSecondStr_Should_Succeed()
        {
            var input = new DateTime(2019, 11, 11, 18, 0, 0, DateTimeKind.Local);

            var str = input.ToDayLastSecondString();

            str.ShouldBe("2019-11-11 23:59:59");
        }

        [Fact]
        public void DateTime_ToDayLastSecond_Should_Succeed()
        {
            var input = new DateTime(2019, 11, 11, 18, 0, 0);

            var dt = input.ToDayLastSecond();

            dt.ShouldBe(new DateTime(2019, 11, 11, 23, 59, 59));
        }

        [Fact]
        public void DateTimeOffset_To24HourString_Should_Succeed()
        {
            var input = new DateTimeOffset(2019, 11, 11, 18, 0, 0, TimeSpan.FromHours(8));

            var str = input.To24HourString();

            str.ShouldBe("2019-11-11 18:00:00");
        }

        [Fact]
        public void DateTimeOffset_ToDayLastSecondStr_Should_Succeed()
        {
            var input = new DateTimeOffset(2019, 11, 11, 18, 0, 0, TimeSpan.FromHours(8));

            var str = input.ToDayLastSecondString();

            str.ShouldBe("2019-11-11 23:59:59");
        }

        [Fact]
        public void DateTimeOffset_ToDayLastSecond_Should_Succeed()
        {
            var input = new DateTimeOffset(2019, 11, 11, 18, 0, 0, TimeSpan.FromHours(0));

            var dt = input.ToDayLastSecond();

            dt.ShouldBe(new DateTimeOffset(2019, 11, 11, 23, 59, 59, TimeSpan.FromHours(0)));
        }

        [Theory]
        [InlineData(0, 1573495200L)]
        [InlineData(8, 1573466400L)]
        public void DateTimeOffset_ToUnixTimeSeconds_Should_Succeed(int hour, long second)
        {
            // now    2019-11-11 18:00:00
            // utcnow 2019-11-11 10:00:00
            var input = new DateTimeOffset(2019, 11, 11, 18, 0, 0, TimeSpan.FromHours(hour));

            var unixTime = input.ToUnixTimeSeconds();

            unixTime.ShouldBe(second);
        }
    }
}
