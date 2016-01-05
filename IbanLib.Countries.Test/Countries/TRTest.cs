using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    [TestFixture]
    public class TRTest : ACountryTest
    {
        public TRTest() : base(new TR())
        {
        }

        [Test]
        [TestCase("TR330006100519786457841326")]
        [TestCase("TR010006100519786457841326")]
        [TestCase("TR990006100519786457841326")]
        [TestCase("TR00000610051978645784132")]
        [TestCase("XX000006100519786457841326")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("TR330006100519786457841326")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}