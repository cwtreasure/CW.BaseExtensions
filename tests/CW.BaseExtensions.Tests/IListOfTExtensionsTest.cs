namespace CW.BaseExtensions.Tests
{
    using System;
    using System.Collections.Generic;
    using Shouldly;
    using Xunit;

    public class IListOfTExtensionsTest
    {
        [Fact]
        public void IsNullOrEmpty_Should_Succeed_When_Is_Empty()
        {
            var list = new List<int> { };

            var res = list.IsNullOrEmpty();

            res.ShouldBeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_Should_Succeed_When_Is_Null()
        {
            List<int> list = null;

            var res = list.IsNullOrEmpty();

            res.ShouldBeTrue();
        }

        [Fact]
        public void IsNotNullOrEmpty_Should_Succeed()
        {
            var list = new List<int> { 1 };

            var res = list.IsNotNullOrEmpty();

            res.ShouldBeTrue();
        }

        [Fact]
        public void StringJoin_Should_Succeed()
        {
            var list = new List<int> { 1, 2 };

            var res = list.StringJoin(":");

            res.ShouldBe("1:2");
        }

        [Fact]
        public void StringJoin_Should_Succeed_When_Is_Empty()
        {
            var list = new List<int> { };

            var res = list.StringJoin(":");

            res.ShouldBeEmpty();
        }

        [Fact]
        public void AddIfNotContains_Should_Return_False_When_Contains()
        {
            var list = new List<int> { 1 };

            var res = list.AddIfNotContains(1);

            res.ShouldBeFalse();
        }

        [Fact]
        public void AddIfNotContains_Should_Return_False_When_Not_Contains()
        {
            var list = new List<int> { 1 };

            var res = list.AddIfNotContains(2);

            res.ShouldBeTrue();
        }

        [Fact]
        public void AddRangeIfNotContains_Should()
        {
            var list = new List<int> { 1, 2, 3 };

            list.AddRangeIfNotContains(new List<int> { 2, 3, 4 }.ToArray());

            list.ShouldContain(4);
            list.Count.ShouldBe(4);
        }
    }
}
