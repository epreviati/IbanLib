using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    [TestFixture]
    public class FRTest : ACountryTest
    {
        public FRTest() : base(new FR())
        {
        }

        [Test]
        [TestCase("FR1420041010050500013M02606")]
        [TestCase("FR0120041010050500013M02606")]
        [TestCase("FR9920041010050500013M02606")]
        [TestCase("FR0020041010050500013M0260")]
        [TestCase("XX0020041010050500013M02606")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("FR1420041010050500013M02606")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}