using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.IBanSplitterTest
{
    public class IbanSplitterGetNationalCheckDigitsTest : AIbanSplitterTest
    {
        private void GetNationalCheckDigits_Valid_Input_Return_Correct_Value(ICountry country, string iban, string check)
        {
            var valueGot = IbanSplitterValidValidation.GetNationalCheckDigits(country, iban);
            Assert.AreEqual(check, valueGot);
        }

        [Test]
        [TestCase("AD1200012030200359100100", "12")]
        public void GetNationalCheckDigits_Valid_Input_Return_Correct_Value_AD(string iban, string check)
        {
            GetNationalCheckDigits_Valid_Input_Return_Correct_Value(new AD(), iban, check);
        }
    }
}