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
            catch (AggregateException e)
            {
                e.Handle(x =>
                {
                    Assert.IsTrue(x is TException);
                    Assert.AreEqual(typeof (TException), x.GetType());
                    return true;
                });
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof (TException), e.GetType());
            }
        }
    }
}