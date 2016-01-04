using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test
{
    [TestFixture]
    public class DETest : ACountryTest
    {
        public DETest() : base(new DE())
        {
        }

        [Test]
        [TestCase("DE89370400440532013000")]
        [TestCase("DE01370400440532013000")]
        [TestCase("DE99370400440532013000")]
        [TestCase("DE0037040044053201300")]
        [TestCase("XX00370400440532013000")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("DE89370400440532013000")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}