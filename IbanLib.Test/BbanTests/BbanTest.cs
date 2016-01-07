using NUnit.Framework;

namespace IbanLib.Test.BbanTests
{
    public class BbanTest : ABbanTest
    {
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
    }
}