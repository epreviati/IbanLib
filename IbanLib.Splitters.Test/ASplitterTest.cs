using IbanLib.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test
{
    [TestFixture]
    public abstract class ASplitterTest
    {
        protected ICountry GetCountryFromIBan(string iban)
        {
            return Getter.GetCountry(iban.Substring(0, 2));
        }
    }
}