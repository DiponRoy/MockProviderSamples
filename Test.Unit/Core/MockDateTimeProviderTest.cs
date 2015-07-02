using System;
using System.Threading;
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
        public void Mocked_Now_Returns_SettedDateTime()
        {
            MockDateTimeProvider.SetNow(DateTime.Now);
            DateTimeProvider provider = DateTimeProvider.DateTime;
            DateTime dateTime = provider.Now;
            Thread.Sleep(TimeSpan.FromSeconds(1));      //wait a little bit
            DateTime dateTime2 = provider.Now;

            Assert.AreEqual(dateTime, dateTime2);    //same date time after setting once
            Assert.AreEqual(dateTime.Kind, dateTime2.Kind);
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
        public void Mocked_UtcNow_Returns_SettedDateTime()
        {
            MockDateTimeProvider.SetUtcNow(DateTime.UtcNow);
            DateTimeProvider provider = DateTimeProvider.DateTime;
            DateTime dateTime = provider.UtcNow;
            Thread.Sleep(TimeSpan.FromSeconds(1));      //wait a little bit
            DateTime dateTime2 = provider.UtcNow;

            Assert.AreEqual(dateTime, dateTime2);    //same date time after setting once
            Assert.AreEqual(dateTime.Kind, dateTime2.Kind);
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
