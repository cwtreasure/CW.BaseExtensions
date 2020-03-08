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

        [Fact]
        public void IsNullOrEmpty_Should_Return_True_When_IsNull()
        {
            Dictionary<string, string> dict = null;

            var res = dict.IsNullOrEmpty();

            res.ShouldBeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_Should_Return_True_When_IsEmpty()
        {
            var dict = new Dictionary<string, string>();

            var res = dict.IsNullOrEmpty();

            res.ShouldBeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_Should_Return_Flase()
        {
            var dict = new Dictionary<string, string>()
            {
                { "a", "b" },
            };

            var res = dict.IsNullOrEmpty();

            res.ShouldBeFalse();
        }

        [Fact]
        public void IsNotNullOrEmpty_Should_Return_False_When_IsNull()
        {
            Dictionary<string, string> dict = null;

            var res = dict.IsNotNullOrEmpty();

            res.ShouldBeFalse();
        }

        [Fact]
        public void IsNotNullOrEmpty_Should_Return_Flase_When_IsEmpty()
        {
            var dict = new Dictionary<string, string>();

            var res = dict.IsNotNullOrEmpty();

            res.ShouldBeFalse();
        }

        [Fact]
        public void IsNotNullOrEmpty_Should_Return_True()
        {
            var dict = new Dictionary<string, string>()
            {
                { "a", "b" },
            };

            var res = dict.IsNotNullOrEmpty();

            res.ShouldBeTrue();
        }
    }
}
