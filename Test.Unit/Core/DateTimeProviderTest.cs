using System;
using System.Threading;
using Core;
using NUnit.Framework;

namespace Test.Unit.Core
{
    [TestFixture]
    public class DateTimeProviderTest
    {
        [Test]
        public void Now()
        {
            Assert.AreEqual(DateTime.Now.Kind, DateTimeProvider.DateTime.Now.Kind);
            Assert.LessOrEqual(DateTime.Now, DateTimeProvider.DateTime.Now);
            Assert.LessOrEqual(DateTimeProvider.DateTime.Now - DateTime.Now, TimeSpan.FromMilliseconds(0.00002));
        }

        [Test]
        public void Now_Returns_CurrentDateTime()
        {
            DateTimeProvider provider = DateTimeProvider.DateTime;
            DateTime dateTime = provider.Now;
            Thread.Sleep(TimeSpan.FromSeconds(1));      //wait a little bit
            DateTime dateTime2 = provider.Now;

            Assert.AreNotEqual(dateTime, dateTime2);    //same instance but returns the current datetime
            Assert.AreEqual(dateTime.Kind, dateTime2.Kind);
        }

        [Test]
        public void Utc()
        {
            Assert.AreEqual(DateTime.UtcNow.Kind, DateTimeProvider.DateTime.UtcNow.Kind);
            Assert.LessOrEqual(DateTime.UtcNow, DateTimeProvider.DateTime.UtcNow);
            Assert.LessOrEqual(DateTimeProvider.DateTime.UtcNow - DateTime.UtcNow, TimeSpan.FromMilliseconds(0.00002));
        }

        [Test]
        public void Utc_Returns_CurrentDateTime()
        {
            DateTimeProvider provider = DateTimeProvider.DateTime;
            DateTime dateTime = provider.UtcNow;
            Thread.Sleep(TimeSpan.FromSeconds(1));      //wait a little bit
            DateTime dateTime2 = provider.UtcNow;

            Assert.AreNotEqual(dateTime, dateTime2);    //same instance but returns the current datetime
            Assert.AreEqual(dateTime.Kind, dateTime2.Kind);
        }
    }
}
