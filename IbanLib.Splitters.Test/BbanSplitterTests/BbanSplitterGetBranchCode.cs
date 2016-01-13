using IbanLib.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetBranchCode : ABbanSplitterTest
    {
        private void GetbranchCode_Valid_Input_Return_Correct_Value(
            ICountry country, string bban, string branchCode)
        {
            var valueGot = BbanSplitterValidValidation.GetBranchCode(country, bban);
            Assert.AreEqual(branchCode, valueGot);

            if (country.BranchCodePosition.HasValue)
            {
                Assert.AreNotEqual(valueGot, null);
            }
            else
            {
                Assert.AreEqual(valueGot, null);
            }
        }


        [Test]
        [TestCase("AD1200012030200359100100", "2030")]
        [TestCase("AE070331234567890123456", null)]
        [TestCase("AT611904300234573201", null)]
        [TestCase("AZ21NABZ00000000137010001944", null)]
        [TestCase("BE68539007547034", null)]
        [TestCase("BH67BMAG00001299123456", null)]
        public void GetbranchCode_Valid_Input_Return_Correct_Value(string iban, string branchCode)
        {
            var bban = GetBbanFromIBan(iban);
            var country = GetCountryFromIBan(iban);
            GetbranchCode_Valid_Input_Return_Correct_Value(country, bban, branchCode);
        }
    }
}