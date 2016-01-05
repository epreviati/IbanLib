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
        public void GetCountryCode_Valid_Input_Return_Correct_Value_AD(string iban, string countryCode)
        {
            GetCountryCode_Valid_Input_Return_Correct_Value(iban, countryCode);
        }
    }
}