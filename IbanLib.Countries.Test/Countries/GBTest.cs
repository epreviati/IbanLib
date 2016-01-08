using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class GBTest : ACountryTest
    {
        public GBTest() : base(new GB())
        {
        }

        [Test]
        [TestCase("GB29NWBK60161331926819")]
        [TestCase("GB01NWBK60161331926819")]
        [TestCase("GB99NWBK60161331926819")]
        [TestCase("GB00NWBK6016133192681")]
        [TestCase("XX00NWBK60161331926819")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("GB29NWBK60161331926819")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}