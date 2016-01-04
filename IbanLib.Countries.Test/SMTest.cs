using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test
{
    [TestFixture]
    public class SMTest : ACountryTest
    {
        public SMTest() : base(new SM())
        {
        }

        [Test]
        [TestCase("SM86U0322509800000000270100")]
        [TestCase("SM01U0322509800000000270100")]
        [TestCase("SM99U0322509800000000270100")]
        [TestCase("SM00U032250980000000027010")]
        [TestCase("XX00U0322509800000000270100")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("SM86U0322509800000000270100")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}