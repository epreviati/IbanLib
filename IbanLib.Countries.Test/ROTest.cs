using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test
{
    [TestFixture]
    public class ROTest : ACountryTest
    {
        public ROTest() : base(new RO())
        {
        }

        [Test]
        [TestCase("RO49AAAA1B31007593840000")]
        [TestCase("RO01AAAA1B31007593840000")]
        [TestCase("RO99AAAA1B31007593840000")]
        [TestCase("RO00AAAA1B3100759384000")]
        [TestCase("XX00AAAA1B31007593840000")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("RO49AAAA1B31007593840000")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}