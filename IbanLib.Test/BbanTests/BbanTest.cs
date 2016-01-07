using IbanLib.Countries;
using IbanLib.Domain;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test.BbanTests
{
    public class BbanTest : ABbanTest
    {
        [Test]
        public void Constructor_BankCode_Account_Number_Parameters()
        {
            var bbanObj = new Bban(Country, BankCode, AccountNumber, ValidValidators);
            AssertBban(bbanObj, null);
        }

        [Test]
        public void Constructor_BankCode_BranchCode_Account_Number_Parameters()
        {
            var bbanObj = new Bban(Country, BankCode, BranchCode, AccountNumber, ValidValidators);
            AssertBban(bbanObj);
        }

        [Test]
        public void Constructor_Empty()
        {
            var bban = new Bban();
            Assert.IsNullOrEmpty(bban.BankCode);
            Assert.IsNullOrEmpty(bban.BranchCode);
            Assert.IsNullOrEmpty(bban.AccountNumber);
            Assert.IsNullOrEmpty(bban.CheckDigits1);
            Assert.IsNullOrEmpty(bban.CheckDigits2);
            Assert.IsNullOrEmpty(bban.CheckDigits3);
            Assert.IsNullOrEmpty(bban.Value());
            Assert.IsNotNullOrEmpty(bban.ToString());
        }

        [Test]
        public void Constructor_Splitter_Bban()
        {
            var bbanObj = new Bban(
                Country,
                GetBban(),
                ValidValidators,
                GetBbanSplitter());
            AssertBban(bbanObj);
        }
    }
}