using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class CRTest : ACountryTest
    {
        public CRTest() : base(new CR())
        {
        }

        [Test]
        [TestCase("CR0515202001026284066")]
        [TestCase("CR9915202001026284066")]
        [TestCase("CR0115202001026284066")]
        [TestCase("CR001520200102628406")]
        [TestCase("XX0015202001026284066")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("CR0515202001026284066")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}