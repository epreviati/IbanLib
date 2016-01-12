using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class SATest : ACountryTest
    {
        public SATest() : base(new SA())
        {
        }

        [Test]
        [TestCase("SA0380000000608010167519")]
        [TestCase("SA0180000000608010167519")]
        [TestCase("SA9980000000608010167519")]
        [TestCase("SA03800000006080101675190")]
        [TestCase("XX0380000000608010167519")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("SA0380000000608010167519")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}