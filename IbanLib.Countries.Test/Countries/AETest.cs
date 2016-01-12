using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class AETest : ACountryTest
    {
        public AETest() : base(new AE())
        {
        }

        [Test]
        [TestCase("AE070331234567890123456")]
        [TestCase("AE010331234567890123456")]
        [TestCase("AE990331234567890123456")]
        [TestCase("AE0703312345678901234560")]
        [TestCase("XX070331234567890123456")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("AE070331234567890123456")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}