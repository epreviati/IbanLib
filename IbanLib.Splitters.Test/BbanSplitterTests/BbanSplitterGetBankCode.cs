using IbanLib.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetBankCode : ABbanSplitterTest
    {
        private void GetBankCode_Valid_Input_Return_Correct_Value(
            ICountry country, string bban, string bankCode)
        {
            var valueGot = BbanSplitterValidValidation.GetBankCode(country, bban);
            Assert.AreEqual(bankCode, valueGot);
        }

        [Test]
        [TestCase("AD1200012030200359100100", "0001")]
        [TestCase("AE070331234567890123456", "033")]
        [TestCase("AT611904300234573201", "19043")]
        [TestCase("AZ21NABZ00000000137010001944", "NABZ")]
        [TestCase("BE68539007547034", "539")]
        [TestCase("BH67BMAG00001299123456", "BMAG")]
        public void GetBankCode_Valid_Input_Return_Correct_Value(string iban, string bankCode)
        {
            var bban = GetBbanFromIBan(iban);
            var country = GetCountryFromIBan(iban);
            GetBankCode_Valid_Input_Return_Correct_Value(country, bban, bankCode);
        }
    }
}