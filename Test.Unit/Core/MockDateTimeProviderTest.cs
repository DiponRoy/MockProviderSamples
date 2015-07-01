using System;
using Core;
using NUnit.Framework;

namespace Test.Unit.Core
{
    [TestFixture]
    public class MockDateTimeProviderTest
    {
        [SetUp]
        public void Setup()
        {
            MockDateTimeProvider.RestoreAsDefault();
        }

        [Test]
        public void Mocked_Now()
        {
            DateTime now = DateTime.Now;
            MockDateTimeProvider.SetNow(now);
            Assert.AreEqual(now, DateTimeProvider.DateTime.Now);
            Assert.AreNotEqual(now, DateTimeProvider.DateTime.UtcNow);
        }

        [Test]
        public void Mocked_UtcNow()
        {
            DateTime utcNow = DateTime.UtcNow;
            MockDateTimeProvider.SetUtcNow(utcNow);
            Assert.AreEqual(utcNow, DateTimeProvider.DateTime.UtcNow);
            Assert.AreNotEqual(utcNow, DateTimeProvider.DateTime.Now);
        }

        [Test]
        public void Mocked_RestoreDefault()
        {
            DateTime now = DateTime.Now.AddDays(-1);
            DateTime utcNow = DateTime.UtcNow.AddDays(-1);
            MockDateTimeProvider.SetNow(now);
            MockDateTimeProvider.SetUtcNow(utcNow);

            MockDateTimeProvider.RestoreAsDefault();
            Assert.AreNotEqual(now, DateTimeProvider.DateTime.Now);
            Assert.AreNotEqual(utcNow, DateTimeProvider.DateTime.UtcNow);
            Assert.LessOrEqual(DateTime.Now, DateTimeProvider.DateTime.Now);
            Assert.LessOrEqual(DateTime.UtcNow, DateTimeProvider.DateTime.UtcNow);
        }
    }
}
