using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetBankCode : ABbanSplitterTest
    {
        private void GetBankCode_Valid_Input_Return_Correct_Value(ICountry country, string bban, string bankCode)
        {
            var valueGot = BbanSplitterValidValidation.GetBankCode(country, bban);
            Assert.AreEqual(bankCode, valueGot);
        }

        [Test]
        [TestCase("AD1200012030200359100100", "0001")]
        public void GetBankCode_Valid_Input_Return_Correct_Value_AD(string iban, string bankCode)
        {
            var bban = GetBbanFromIBan(iban);
            GetBankCode_Valid_Input_Return_Correct_Value(new AD(), bban, bankCode);
        }
    }
}