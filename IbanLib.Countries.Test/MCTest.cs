using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test
{
    [TestFixture]
    public class MCTest : ACountryTest
    {
        public MCTest() : base(new MC())
        {
        }

        [Test]
        [TestCase("MC5813488000010051108001292")]
        [TestCase("MC0113488000010051108001292")]
        [TestCase("MC9913488000010051108001292")]
        [TestCase("MC001348800001005110800129")]
        [TestCase("XX0013488000010051108001292")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("MC5813488000010051108001292")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}