using System;
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
            Assert.LessOrEqual(DateTimeProvider.DateTime.Now - DateTime.Now, TimeSpan.FromMilliseconds(1));
        }

        [Test]
        public void Utc()
        {
            Assert.AreEqual(DateTime.UtcNow.Kind, DateTimeProvider.DateTime.UtcNow.Kind);
            Assert.LessOrEqual(DateTime.UtcNow, DateTimeProvider.DateTime.UtcNow);
            Assert.LessOrEqual(DateTimeProvider.DateTime.UtcNow - DateTime.UtcNow, TimeSpan.FromMilliseconds(1));
        }
    }
}
