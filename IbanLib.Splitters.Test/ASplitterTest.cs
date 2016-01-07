using IbanLib.Countries;
using IbanLib.Test.Common;
using Moq;

namespace IbanLib.Splitters.Test
{
    public abstract class ASplitterTest : ATest
    {
        protected ICountry MockNotNullCountry;

        protected ASplitterTest()
        {
            MockNotNullCountry = new Mock<ICountry>().Object;
        }
    }
}