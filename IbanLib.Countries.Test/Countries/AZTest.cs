using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class AZTest : ACountryTest
    {
        public AZTest() : base(new AZ())
        {
        }

        [Test]
        [TestCase("AZ21NABZ00000000137010001944")]
        [TestCase("AZ01NABZ00000000137010001944")]
        [TestCase("AZ99NABZ00000000137010001944")]
        [TestCase("AZ00NABZ0000000013701000194")]
        [TestCase("XX21NABZ00000000137010001944")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("AZ21NABZ00000000137010001944")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}