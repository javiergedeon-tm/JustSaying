using System;
using JustEat.Testing;
using NUnit.Framework;

namespace JustSaying.UnitTests.JustSayingTests.ConfigValidation
{
    public class WhenNoRegionIsProvided : FluentMessageMuleTestBase
    {
        protected override JustSayingFluently CreateSystemUnderTest()
        {
            return null;
        }

        protected override void Given()
        {
            RecordAnyExceptionsThrown();
        }

        protected override void When()
        {
            Factory.JustSaying(configuration => { });
        }

        [Then]
        public void ConfigItemsAreRequired()
        {
            Assert.IsInstanceOf<ArgumentNullException>(ThrownException);
        }

        [Then]
        public void RegionIsRequested()
        {
            Assert.AreEqual(((ArgumentException)ThrownException).ParamName, "config.Region");
        }
    }
}