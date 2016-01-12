using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class ITTest : ACountryTest
    {
        public ITTest() : base(new IT())
        {
        }

        [Test]
        [TestCase("IT60X0542811101000000123456")]
        [TestCase("IT01X0542811101000000123456")]
        [TestCase("IT99X0542811101000000123456")]
        [TestCase("IT00X054281110100000012345")]
        [TestCase("XX00X0542811101000000123456")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("IT60X0542811101000000123456")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}