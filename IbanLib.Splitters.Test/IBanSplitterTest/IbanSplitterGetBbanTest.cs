using IbanLib.Countries;
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
        [TestCase("AE070331234567890123456", "0331234567890123456")]
        [TestCase("AT611904300234573201", "1904300234573201")]
        [TestCase("AZ21NABZ00000000137010001944", "NABZ00000000137010001944")]
        [TestCase("BE68539007547034", "539007547034")]
        [TestCase("BH67BMAG00001299123456", "BMAG00001299123456")]
        public void GetBban_Valid_Input_Return_Correct_Value(string iban, string bban)
        {
            var country = GetCountryFromIBan(iban);
            GetBban_Valid_Input_Return_Correct_Value(country, iban, bban);
        }
    }
}