using IbanLib.Countries;
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
        [TestCase("AE070331234567890123456", "07")]
        [TestCase("AT611904300234573201", "61")]
        [TestCase("AZ21NABZ00000000137010001944", "21")]
        [TestCase("BE68539007547034", "68")]
        [TestCase("BH67BMAG00001299123456", "67")]
        public void GetNationalCheckDigits_Valid_Input_Return_Correct_Value(string iban, string check)
        {
            var country = GetCountryFromIBan(iban);
            GetNationalCheckDigits_Valid_Input_Return_Correct_Value(country, iban, check);
        }
    }
}