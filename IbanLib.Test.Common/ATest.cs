using System;
using NUnit.Framework;

namespace IbanLib.Test.Common
{
    [TestFixture]
    public abstract class ATest
    {
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