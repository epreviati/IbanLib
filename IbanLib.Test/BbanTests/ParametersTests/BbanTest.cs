using IbanLib.Countries;
using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Test.BbanTests.ParametersTests
{
    public class BbanTest : ABbanTest
    {
        private void Constructor_Parameters(
            ICountry country,
            string bankCode, string branchCode, string accountNumber,
            string check1, string check2, string check3)
        {
            var bbanObj = new Bban(country, bankCode, branchCode, accountNumber, ValidValidators);
            Assert.IsNotNullOrEmpty(bbanObj.BankCode);
            Assert.AreEqual(bbanObj.BankCode, bankCode);

            Assert.AreEqual(bbanObj.BranchCode, branchCode);

            Assert.IsNotNullOrEmpty(bbanObj.AccountNumber);
            Assert.AreEqual(bbanObj.AccountNumber, accountNumber);

            Assert.AreEqual(bbanObj.CheckDigits1, check1);
            Assert.AreEqual(bbanObj.CheckDigits2, check2);
            Assert.AreEqual(bbanObj.CheckDigits3, check3);

            Assert.IsNotNullOrEmpty(bbanObj.Value());
            Assert.AreEqual(
                string.Concat(
                    check1,
                    bankCode,
                    branchCode,
                    check2,
                    accountNumber,
                    check3),
                bbanObj.Value());

            Assert.IsNotNullOrEmpty(bbanObj.ToString());
        }

        [Test]
        [TestCase("0001", "2030", "200359100100")] //AD 12 0001 2030 200359100100
        public void Constructor_Parameters_AD(string bankCode, string branchCode, string accountNumber)
        {
            Constructor_Parameters(
                new AD(),
                bankCode, branchCode, accountNumber,
                null, null, null);
        }
    }
}