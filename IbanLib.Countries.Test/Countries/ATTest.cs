using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class ATTest : ACountryTest
    {
        public ATTest() : base(new AT())
        {
        }

        [Test]
        [TestCase("AT611904300234573201")]
        [TestCase("AT011904300234573201")]
        [TestCase("AT991904300234573201")]
        [TestCase("AT00190430023457320")]
        [TestCase("XX001904300234573201")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("AT611904300234573201")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}