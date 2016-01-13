using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class BHTest : ACountryTest
    {
        public BHTest() : base(new BH())
        {
        }

        [Test]
        [TestCase("BH67BMAG00001299123456")]
        [TestCase("BH01BMAG00001299123456")]
        [TestCase("BH99BMAG00001299123456")]
        [TestCase("BH00BMAG0000129912345")]
        [TestCase("XX00BMAG00001299123456")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("BH67BMAG00001299123456")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}