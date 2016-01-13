using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetAccountNumber : ABbanSplitterTest
    {
        private void GetaccountNumber_Valid_Input_Return_Correct_Value(
            ICountry country, string bban, string accountNumber)
        {
            var valueGot = BbanSplitterValidValidation.GetAccountNumber(country, bban);
            Assert.AreEqual(accountNumber, valueGot);
        }

        public void GetaccountNumber_Valid_Input_Return_Correct_Value_AE(string iban, string accountNumber)
        {
            var bban = GetBbanFromIBan(iban);
            GetaccountNumber_Valid_Input_Return_Correct_Value(new AE(), bban, accountNumber);
        }

        [Test]
        [TestCase("AD1200012030200359100100", "200359100100")]
        [TestCase("AE070331234567890123456", "1234567890123456")]
        [TestCase("AT611904300234573201", "00234573201")]
        [TestCase("AZ21NABZ00000000137010001944", "00000000137010001944")]
        [TestCase("BE68539007547034", "0075470")]
        [TestCase("BH67BMAG00001299123456", "00001299123456")]
        public void GetAccountNumber_Valid_Input_Return_Correct_Value(string iban, string accountNumber)
        {
            var bban = GetBbanFromIBan(iban);
            var country = GetCountryFromIBan(iban);
            GetaccountNumber_Valid_Input_Return_Correct_Value(country, bban, accountNumber);
        }
    }
}