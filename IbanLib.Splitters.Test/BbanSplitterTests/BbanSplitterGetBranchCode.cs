using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterGetBranchCode : ABbanSplitterTest
    {
        private void GetbranchCode_Valid_Input_Return_Correct_Value(ICountry country, string bban, string branchCode)
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
        public void GetbranchCode_Valid_Input_Return_Correct_Value_AD(string iban, string branchCode)
        {
            var bban = GetBbanFromIBan(iban);
            GetbranchCode_Valid_Input_Return_Correct_Value(new AD(), bban, branchCode);
        }
    }
}