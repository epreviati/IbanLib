using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class ADTest : ACountryTest
    {
        public ADTest() : base(new AD())
        {
        }

        [Test]
        [TestCase("AD0100012030200359100100")]
        [TestCase("AD9900012030200359100100")]
        [TestCase("AD000001203020035910010")]
        [TestCase("XX0000012030200359100100")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("AD1200012030200359100100")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}