using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    [TestFixture]
    public class ESTest : ACountryTest
    {
        public ESTest() : base(new ES())
        {
        }

        [Test]
        [TestCase("ES9121000418450200051332")]
        [TestCase("ES0121000418450200051332")]
        [TestCase("ES9921000418450200051332")]
        [TestCase("ES002100041845020005133")]
        [TestCase("XX0021000418450200051332")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("ES9121000418450200051332")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}