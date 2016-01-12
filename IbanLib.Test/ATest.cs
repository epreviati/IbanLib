using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Domain.Validators;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test
{
    [TestFixture]
    public abstract class ATest
    {
        protected const string BankCode = "BANKCODE";
        protected const string BranchCode = "BRANCHCODE";
        protected const string AccountNumber = "ACCOUNTNUMBER";
        protected const string Check1 = "CHECK1";
        protected const string Check2 = "CHECK2";
        protected const string Check3 = "CHECK3";

        protected readonly IValidators ValidValidators;
        protected ICountry Country;

        protected ATest()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            ValidValidators = GetValidators(true);
        }

        protected abstract IValidators GetValidators(bool returnValue);

        protected static IBbanSplitter GetBbanSplitter(string branchCode = BranchCode)
        {
            var mockIbanSplitter = new Mock<IBbanSplitter>();
            mockIbanSplitter
                .Setup(x => x.GetBankCode(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(BankCode);
            mockIbanSplitter
                .Setup(x => x.GetBranchCode(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(branchCode);
            mockIbanSplitter
                .Setup(x => x.GetAccountNumber(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(AccountNumber);
            mockIbanSplitter
                .Setup(x => x.GetCheck1(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(Check1);
            mockIbanSplitter
                .Setup(x => x.GetCheck2(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(Check2);
            mockIbanSplitter
                .Setup(x => x.GetCheck3(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(Check3);

            return mockIbanSplitter.Object;
        }

        protected static IBankCodeValidator GetBankCodeValidator(bool returnValue)
        {
            var mockBankCodeValidator = new Mock<IBankCodeValidator>();
            mockBankCodeValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(returnValue);

            return mockBankCodeValidator.Object;
        }

        protected static IBranchCodeValidator GetBranchCodeValidator(bool returnValue)
        {
            var mockBranchCodeValidator = new Mock<IBranchCodeValidator>();
            mockBranchCodeValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(returnValue);

            return mockBranchCodeValidator.Object;
        }

        protected static IAccountNumberValidator GetAccountNumberValidator(bool returnValue)
        {
            var mockAccountNumberValidator = new Mock<IAccountNumberValidator>();
            mockAccountNumberValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(returnValue);

            return mockAccountNumberValidator.Object;
        }

        protected static IBbanValidator GetBbanValidator(bool returnValue)
        {
            var mockBbanValidator = new Mock<IBbanValidator>();
            mockBbanValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(returnValue);

            return mockBbanValidator.Object;
        }

        protected static string GetBban(string branchCode = BranchCode)
        {
            return string.Concat(
                Check1,
                BankCode,
                branchCode,
                Check2,
                AccountNumber,
                Check3);
        }
    }
}