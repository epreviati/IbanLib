using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Validators;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test.BbanTests
{
    [TestFixture]
    public abstract class ABbanTest
    {
        protected readonly IValidators ValidValidators;

        protected ABbanTest()
        {
            ValidValidators = GetValidators(true);
        }

        protected static IValidators GetValidators(bool returnValue)
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
                .Setup(x => x.GetCountryCodeValidator())
                .Returns(GetCountryCodeValidator(returnValue));
            mockValidators
                .Setup(x => x.GetIbanValidator())
                .Returns(GetIbanValidator(returnValue));
            mockValidators
                .Setup(x => x.GetBbanValidator())
                .Returns(GetBbanValidator(returnValue));

            return mockValidators.Object;
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
            var mockBankCodeValidator = new Mock<IBranchCodeValidator>();
            mockBankCodeValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(returnValue);

            return mockBankCodeValidator.Object;
        }

        protected static IAccountNumberValidator GetAccountNumberValidator(bool returnValue)
        {
            var mockBankCodeValidator = new Mock<IAccountNumberValidator>();
            mockBankCodeValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(returnValue);

            return mockBankCodeValidator.Object;
        }

        protected static IIbanValidator GetIbanValidator(bool returnValue)
        {
            var mockBankCodeValidator = new Mock<IIbanValidator>();
            mockBankCodeValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(returnValue);

            return mockBankCodeValidator.Object;
        }

        protected static IBbanValidator GetBbanValidator(bool returnValue)
        {
            var mockBankCodeValidator = new Mock<IBbanValidator>();
            mockBankCodeValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(returnValue);

            return mockBankCodeValidator.Object;
        }

        protected static ICountryCodeValidator GetCountryCodeValidator(bool returnValue)
        {
            var mockBankCodeValidator = new Mock<ICountryCodeValidator>();
            mockBankCodeValidator
                .Setup(x => x.IsValid(It.IsAny<string>()))
                .Returns(returnValue);

            return mockBankCodeValidator.Object;
        }
    }
}