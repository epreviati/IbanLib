using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class VGTest : ACountryTest
    {
        public VGTest() : base(new VG())
        {
        }

        [Test]
        [TestCase("VG96VPVG00000123456789010")]
        [TestCase("VG01VPVG0000012345678901")]
        [TestCase("VG99VPVG0000012345678901")]
        [TestCase("VG00VPVG000001234567890")]
        [TestCase("XX96VPVG0000012345678901")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("VG96VPVG0000012345678901")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}