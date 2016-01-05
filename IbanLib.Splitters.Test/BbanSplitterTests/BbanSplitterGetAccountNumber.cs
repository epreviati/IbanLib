using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetAccountNumber : ABbanSplitterTest
    {
        private void GetaccountNumber_Valid_Input_Return_Correct_Value(ICountry country, string bban, string accountNumber)
        {
            var valueGot = BbanSplitterValidValidation.GetAccountNumber(country, bban);
            Assert.AreEqual(accountNumber, valueGot);
        }

        [Test]
        [TestCase("AD1200012030200359100100", "200359100100")]
        public void GetaccountNumber_Valid_Input_Return_Correct_Value_AD(string iban, string accountNumber)
        {
            var bban = GetBbanFromIBan(iban);
            GetaccountNumber_Valid_Input_Return_Correct_Value(new AD(), bban, accountNumber);
        }
    }
}