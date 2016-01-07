using System;
using IbanLib.Countries;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test.Common
{
    public static class TestUtil
    {
        public static ICountry MockNotNullCountry = new Mock<ICountry>().Object;

        public static void ExpectedException<TException>(Action action)
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