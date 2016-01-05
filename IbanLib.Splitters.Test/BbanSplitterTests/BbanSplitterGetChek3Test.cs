using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetChek3Test : ABbanSplitterTest
    {
        private void GetCheck3_Valid_Input_Return_Correct_Value(ICountry country, string bban, string check3)
        {
            var check = BbanSplitterValidValidation.GetCheck3(country, bban);
            Assert.AreEqual(check3, check);

            if (country.Check3Position.HasValue)
            {
                Assert.AreNotEqual(check, null);
            }
            else
            {
                Assert.AreEqual(check, null);
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