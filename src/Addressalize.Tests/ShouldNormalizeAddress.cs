using Addressalize;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Tests
{
    public class Tests
    {
        private Addressalizer addressalizer;
        private Stopwatch stopWatch;

        [SetUp]
        public void Setup()
        {
            this.addressalizer = new Addressalizer();
            this.stopWatch = new Stopwatch();
            this.stopWatch.Start();
        }
        [TearDown]
        public void Teardown()
        {
            this.stopWatch.Stop();
            TestContext.WriteLine($"Elapsed ticks: {this.stopWatch.ElapsedTicks}");            
        }

        [TestCase("123 First Avenue Northeast", "123 1ST AVE NE")]
        [TestCase("123 Second Avenue Northeast", "123 2ND AVE NE")]
        [TestCase("123 Third Avenue Northeast", "123 3RD AVE NE")]
        [TestCase("123 Fourth Avenue Northeast", "123 4TH AVE NE")]
        [TestCase("123 Forty Fifth Avenue Northeast", "123 45TH AVE NE")]
        [TestCase("123 Hundredth Avenue Northeast", "123 100TH AVE NE")]
        public void ShouldNormalizeCorrectly(string source, string expectedResult)
        {
            var result = this.addressalizer.NormalizeAddress(source);
            Assert.AreEqual(expectedResult, result);
        }
    }
}