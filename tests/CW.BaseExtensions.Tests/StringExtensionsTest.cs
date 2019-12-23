namespace CW.BaseExtensions.Tests
{
    using System;
    using Shouldly;
    using Xunit;

    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("", "1")]
        [InlineData("  ", "1")]
        [InlineData(null, "1")]
        public void GetDefaultIfEmpty_Should_Succeed(string input, string value)
        {
            var res = input.GetDefaultIfEmpty(value);

            res.ShouldBe(value);
        }

        [Theory]
        [InlineData("", true)]
        [InlineData("  ", true)]
        [InlineData(null, true)]
        [InlineData(" 1 ", false)]
        public void IsNullOrWhiteSpace_Should_Succeed(string input, bool flag)
        {
            var res = input.IsNullOrWhiteSpace();

            res.ShouldBe(flag);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("  ", false)]
        [InlineData(null, false)]
        [InlineData(" 1 ", true)]
        public void IsNotNullOrWhiteSpace_Should_Succeed(string input, bool flag)
        {
            var res = input.IsNotNullOrWhiteSpace();

            res.ShouldBe(flag);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("  ", 0)]
        [InlineData(null, 0)]
        [InlineData(" 1 ", 3)]
        public void GetLength_Should_Succeed(string input, int len)
        {
            var res = input.GetLength();

            res.ShouldBe(len);
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData("false", true)]
        [InlineData("1", false)]
        [InlineData("0", false)]
        public void IsBoolean_Should_Succeed(string input, bool flag)
        {
            var res = input.IsBoolean();

            res.ShouldBe(flag);
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData("false", true)]
        [InlineData("1", false)]
        [InlineData("0", false)]
        public void IsBoolean_With_Out_Should_Succeed(string input, bool flag)
        {
            var res = input.IsBoolean(out var b);

            res.ShouldBe(flag);
        }

        [Fact]
        public void EqualsIgnoreCase_Should_Succeed()
        {
            var str = "Str";

            var flag = str.EqualsIgnoreCase("str");

            flag.ShouldBeTrue();
        }

        [Theory]
        [InlineData("https://github.com")]
        [InlineData("https://github.com/")]
        public void EndWithSlash_Should_Succeed(string url)
        {
            var res = url.EnsureEndWithSlash();

            res.ShouldBe("https://github.com/");
        }
    }
}
