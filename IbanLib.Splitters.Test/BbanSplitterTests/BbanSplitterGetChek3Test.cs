using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetChek3Test : ABbanSplitterTest
    {
        private void GetCheck3_Valid_Input_Return_Correct_Value(ICountry country, string bban, string check3)
        {
            var valueGot = BbanSplitterValidValidation.GetCheck3(country, bban);
            Assert.AreEqual(check3, valueGot);

            if (country.Check3Position.HasValue)
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
        public void GetCheck3_Valid_Input_Return_Correct_Value_AD(string iban, string check3)
        {
            var bban = GetBbanFromIBan(iban);
            GetCheck3_Valid_Input_Return_Correct_Value(new AD(), bban, check3);
        }
    }
}