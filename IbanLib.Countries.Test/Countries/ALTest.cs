using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    [TestFixture]
    public class ALTest : ACountryTest
    {
        public ALTest() : base(new AL())
        {
        }

        [Test]
        [TestCase("AL01212110090000000235698741")]
        [TestCase("AL99212110090000000235698741")]
        [TestCase("AL0021211009000000023569874")]
        [TestCase("XX00212110090000000235698741")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("AL47212110090000000235698741")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}