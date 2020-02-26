namespace CW.BaseExtensions.Tests
{
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class DictionaryExtensionsTest
    {
        [Fact]
        public void ToQueryString_Should_Return_Empty_When_Dict_IsEmpty()
        {
            var dict = new Dictionary<string, string>();

            var queryString = dict.ToQueryString();

            queryString.ShouldBeEmpty();
        }

        [Fact]
        public void ToQueryString_Should_Return_Empty_When_Dict_IsNull()
        {
            Dictionary<string, string> dict = null;

            var queryString = dict.ToQueryString();

            queryString.ShouldBeEmpty();
        }

        [Fact]
        public void ToQueryString_Should_Succeed()
        {
            var dict = new Dictionary<string, string>
            {
                { "a", "b" },
                { "c", "d" }
            };

            var queryString = dict.ToQueryString();

            queryString.ShouldBe("a=b&c=d");
        }
    }
}
