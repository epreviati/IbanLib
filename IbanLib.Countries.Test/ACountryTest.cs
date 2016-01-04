using NUnit.Framework;

namespace IbanLib.Countries.Test
{
    public abstract class ACountryTest
    {
        protected ICountry Country;

        protected ACountryTest(ICountry country)
        {
            Country = country;
        }

        protected virtual bool CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var countryCode = iban.Substring(0, 2);
            var checkDigits = iban.Substring(2, 2);
            var bban = iban.Substring(4);
            var ibanWithCheckCodeRemoved = string.Concat(countryCode, "00", bban);
            var calculatedCheckDigits = Country.CalculateNationalCheckDigits(ibanWithCheckCodeRemoved);
            Assert.AreEqual(checkDigits, calculatedCheckDigits);
            return true;
        }

        protected virtual bool CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var checkDigits = Country.CalculateNationalCheckDigits(iban);
            Assert.AreNotEqual(iban.Substring(2, 2), checkDigits);
            Assert.AreEqual(null, checkDigits);
            return true;
        }
    }
}