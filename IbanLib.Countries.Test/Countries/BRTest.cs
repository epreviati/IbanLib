using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class BRTest : ACountryTest
    {
        public BRTest() : base(new BR())
        {
        }

        [Test]
        [TestCase("BR9700360305000010009795493P1")]
        [TestCase("BR0100360305000010009795493P1")]
        [TestCase("BR9900360305000010009795493P1")]
        [TestCase("BR000036030500001000979549P1")]
        [TestCase("XX0000360305000010009795493P1")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("BR9700360305000010009795493P1")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}