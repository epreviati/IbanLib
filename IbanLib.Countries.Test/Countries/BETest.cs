using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    [TestFixture]
    public class BETest : ACountryTest
    {
        public BETest() : base(new BE())
        {
        }

        [Test]
        [TestCase("BE68539007547034")]
        [TestCase("BE01539007547034")]
        [TestCase("BE99539007547034")]
        [TestCase("BE0053900754703")]
        [TestCase("XX00539007547034")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("BE68539007547034")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}