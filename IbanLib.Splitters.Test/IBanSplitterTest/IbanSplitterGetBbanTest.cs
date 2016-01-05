using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.IBanSplitterTest
{
    public class IbanSplitterGetBbanTest : AIbanSplitterTest
    {
        private void GetBban_Valid_Input_Return_Correct_Value(ICountry country, string iban, string bban)
        {
            var valueGot = IbanSplitterValidValidation.GetBban(country, iban);
            Assert.AreEqual(valueGot, bban);
        }

        [Test]
        [TestCase("AD1200012030200359100100", "00012030200359100100")]
        public void GetBban_Valid_Input_Return_Correct_Value_AD(string iban, string bban)
        {
            GetBban_Valid_Input_Return_Correct_Value(new AD(), iban, bban);
        }
    }
}