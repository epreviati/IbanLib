using IbanLib.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetChek1Test : ABbanSplitterTest
    {
        private void GetCheck1_Valid_Input_Return_Correct_Value(
            ICountry country, string bban, string check1)
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
        [TestCase("AE070331234567890123456", null)]
        [TestCase("AT611904300234573201", null)]
        [TestCase("AZ21NABZ00000000137010001944", null)]
        [TestCase("BE68539007547034", null)]
        [TestCase("BH67BMAG00001299123456", null)]
        public void GetCheck1_Valid_Input_Return_Correct_Value(string iban, string check1)
        {
            var bban = GetBbanFromIBan(iban);
            var country = GetCountryFromIBan(iban);
            GetCheck1_Valid_Input_Return_Correct_Value(country, bban, check1);
        }
    }
}