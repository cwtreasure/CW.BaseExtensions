namespace CW.BaseExtensions.Tests
{
    using Shouldly;
    using System;
    using Xunit;

    public class LongExtensionsTest
    {
        [Fact]
        public void Long_ToDateTimeOffset_Is_Sec_Should_Succeed()
        {
            var ut = 1573495200L;

            var dtf = ut.ToDateTimeOffset(true);

            dtf.ShouldBe(new DateTimeOffset(2019, 11, 11, 18, 0, 0, TimeSpan.FromHours(0)));
        }

        [Fact]
        public void Long_ToDateTimeOffset_Is_Not_Sec_Should_Succeed()
        {
            var ut = 1573495200000L;

            var dtf = ut.ToDateTimeOffset(false);

            dtf.ShouldBe(new DateTimeOffset(2019, 11, 11, 18, 0, 0, TimeSpan.FromHours(0)));
        }

        [Theory]
        [InlineData(1573495200L, DateTimeKind.Utc)]
        [InlineData(1573466400L, DateTimeKind.Local)]
        public void Long_ToDateTime_Is_Sec_Should_Succeed(long ut, DateTimeKind kind)
        {
            var dt = ut.ToDateTime(true, kind);

            dt.ShouldBe(new DateTime(2019, 11, 11, 18, 0, 0));
        }

        [Theory]
        [InlineData(1573495200000L, DateTimeKind.Utc)]
        [InlineData(1573466400000L, DateTimeKind.Local)]
        public void Long_ToDateTime_Is_Not_Sec_Should_Succeed(long ut, DateTimeKind kind)
        {
            var dt = ut.ToDateTime(false, kind);

            dt.ShouldBe(new DateTime(2019, 11, 11, 18, 0, 0));
        }
    }
}
