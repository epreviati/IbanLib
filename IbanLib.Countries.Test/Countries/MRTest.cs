using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class MDTest : ACountryTest
    {
        public MDTest() : base(new MD())
        {
        }

        [Test]
        [TestCase("MD24AG000225100013104168")]
        [TestCase("MD01AG000225100013104168")]
        [TestCase("MD99AG000225100013104168")]
        [TestCase("MD00AG00022510001310416")]
        [TestCase("XX00AG000225100013104168")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("MD24AG000225100013104168")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}