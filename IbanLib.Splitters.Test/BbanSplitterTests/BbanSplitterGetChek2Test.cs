using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetChek2Test : ABbanSplitterTest
    {
        private void GetCheck2_Valid_Input_Return_Correct_Value(ICountry country, string bban, string check2)
        {
            var valueGot = BbanSplitterValidValidation.GetCheck2(country, bban);
            Assert.AreEqual(check2, valueGot);

            if (country.Check2Position.HasValue)
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
        public void GetCheck2_Valid_Input_Return_Correct_Value_AD(string iban, string check2)
        {
            var bban = GetBbanFromIBan(iban);
            GetCheck2_Valid_Input_Return_Correct_Value(new AD(), bban, check2);
        }
    }
}