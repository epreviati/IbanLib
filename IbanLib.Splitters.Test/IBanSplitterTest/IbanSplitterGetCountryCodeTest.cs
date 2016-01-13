using NUnit.Framework;

namespace IbanLib.Splitters.Test.IBanSplitterTest
{
    public class IbanSplitterGetCountryCodeTest : AIbanSplitterTest
    {
        private void GetCountryCode_Valid_Input_Return_Correct_Value(string iban, string countryCode)
        {
            var valueGot = IbanSplitterValidValidation.GetCountryCode(iban);
            Assert.AreEqual(countryCode, valueGot);
        }

        [Test]
        [TestCase("AD1200012030200359100100", "AD")]
        [TestCase("AE070331234567890123456", "AE")]
        [TestCase("AT611904300234573201", "AT")]
        [TestCase("AZ21NABZ00000000137010001944", "AZ")]
        [TestCase("BE68539007547034", "BE")]
        [TestCase("BH67BMAG00001299123456", "BH")]
        public void GetCountryCode_Valid_Input_Return_Correct_Value_AD(string iban, string countryCode)
        {
            GetCountryCode_Valid_Input_Return_Correct_Value(iban, countryCode);
        }
    }
}