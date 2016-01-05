using System;
using IbanLib.Countries;
using Moq;
using NUnit.Framework;

namespace IbanLib.Splitters.Test
{
    [TestFixture]
    public abstract class ASplitterTest
    {
        protected ICountry MockNotNullCountry;

        protected ASplitterTest()
        {
            MockNotNullCountry = new Mock<ICountry>().Object;
        }

        protected static void ExpectedException<TException>(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof (TException), e.GetType());
            }
        }
    }
}