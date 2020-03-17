namespace CW.BaseExtensions.Tests
{
    using System;
    using System.Linq;
    using Shouldly;
    using Xunit;

    public class SnowflakeIdGenTest
    {
        [Fact]
        public void GetDefaultIfEmpty_Should_Succeed()
        {
            System.Collections.Concurrent.ConcurrentBag<long> cb = new System.Collections.Concurrent.ConcurrentBag<long>();

            System.Threading.Tasks.Parallel.For(0, 10000, (x) =>
            {
                cb.Add(CW.BaseExtensions.SnowflakeIdGen.IdWorker.Instance.NextId());
            });

            cb.Distinct().Count().ShouldBe(10000);
        }
    }
}
