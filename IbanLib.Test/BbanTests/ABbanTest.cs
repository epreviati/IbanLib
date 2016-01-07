using IbanLib.Countries;
using IbanLib.Domain;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test.BbanTests
{
    public abstract class ABbanTest : ATest
    {
        protected static void AssertBban(IBban bbanObj, string branchCode = BranchCode)
        {
            Assert.IsNotNullOrEmpty(bbanObj.BankCode);
            Assert.AreEqual(bbanObj.BankCode, BankCode);

            Assert.AreEqual(bbanObj.BranchCode, branchCode);

            Assert.IsNotNullOrEmpty(bbanObj.AccountNumber);
            Assert.AreEqual(bbanObj.AccountNumber, AccountNumber);

            Assert.AreEqual(bbanObj.CheckDigits1, Check1);
            Assert.AreEqual(bbanObj.CheckDigits2, Check2);
            Assert.AreEqual(bbanObj.CheckDigits3, Check3);

            Assert.IsNotNullOrEmpty(bbanObj.Value());
            Assert.AreEqual(
                GetBban(branchCode),
                bbanObj.Value());

            Assert.IsNotNullOrEmpty(bbanObj.ToString());
        }

        protected ABbanTest()
        {
            var mockCountry = new Mock<ICountry>();
            mockCountry
                .Setup(x => x.CalculateCheck1(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Check1);
            mockCountry
                .Setup(x => x.CalculateCheck2(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Check2);
            mockCountry
                .Setup(x => x.CalculateCheck3(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Check3);

            Country = mockCountry.Object;
        }

        protected override IValidators GetValidators(bool returnValue)
        {
            var mockValidators = new Mock<IValidators>();
            mockValidators
                .Setup(x => x.GetBankCodeValidator())
                .Returns(GetBankCodeValidator(returnValue));
            mockValidators
                .Setup(x => x.GetBranchCodeValidator())
                .Returns(GetBranchCodeValidator(returnValue));
            mockValidators
                .Setup(x => x.GetAccountNumberValidator())
                .Returns(GetAccountNumberValidator(returnValue));
            mockValidators
                .Setup(x => x.GetBbanValidator())
                .Returns(GetBbanValidator(returnValue));

            return mockValidators.Object;
        }
    }
}