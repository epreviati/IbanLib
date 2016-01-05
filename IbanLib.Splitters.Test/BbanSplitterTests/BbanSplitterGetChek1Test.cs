using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetChek1Test : ABbanSplitterTest
    {
        private void GetCheck1_Valid_Input_Return_Correct_Value(ICountry country, string bban, string check1)
        {
            var valueGot = BbanSplitterValidValidation.GetCheck1(country, bban);
            Assert.AreEqual(check1, valueGot);

            if (country.Check1Position.HasValue)
            {
                Assert.AreNotEqual(valueGot, null);
            }
            else
            {
                Assert.AreEqual(valueGot, null);
            }
        }

        [Test]
        [TestCase("AD1200012030200359100100", null)]
        public void GetCheck1_Valid_Input_Return_Correct_Value_AD(string iban, string check1)
        {
            var bban = GetBbanFromIBan(iban);
            GetCheck1_Valid_Input_Return_Correct_Value(new AD(), bban, check1);
        }
    }
}