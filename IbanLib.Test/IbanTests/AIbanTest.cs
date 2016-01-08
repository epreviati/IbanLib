using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Domain.Validators;
using Moq;

namespace IbanLib.Test.IbanTests
{
    public abstract class AIbanTest : ATest
    {
        protected const string CountryCode = "COUNTRYCODE";
        protected const string NationalCheckDigits = "00";

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
                .Setup(x => x.GetCountryCodeValidator())
                .Returns(GetCountryCodeValidator(returnValue));
            mockValidators
                .Setup(x => x.GetCountryCodeValidator())
                .Returns(GetCountryCodeValidator(returnValue));
            mockValidators
                .Setup(x => x.GetBbanValidator())
                .Returns(GetBbanValidator(returnValue));

            return mockValidators.Object;
        }

        protected static IIbanSplitter GetIBbanSplitter(string branchCode = BranchCode)
        {
            var mockIbanSplitter = new Mock<IIbanSplitter>();
            mockIbanSplitter
                .Setup(x => x.GetBban(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(GetBban(branchCode));
            mockIbanSplitter
                .Setup(x => x.GetCountryCode(It.IsAny<string>()))
                .Returns(CountryCode);
            mockIbanSplitter
                .Setup(x => x.GetNationalCheckDigits(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(NationalCheckDigits);

            return mockIbanSplitter.Object;
        }

        protected static IIbanValidator GetIbanValidator(bool returnValue)
        {
            var mockIbanValidator = new Mock<IIbanValidator>();
            mockIbanValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(returnValue);

            return mockIbanValidator.Object;
        }

        protected static ICountryCodeValidator GetCountryCodeValidator(bool returnValue)
        {
            var mockCountryCodeValidator = new Mock<ICountryCodeValidator>();
            mockCountryCodeValidator
                .Setup(x => x.IsValid(It.IsAny<string>()))
                .Returns(returnValue);

            return mockCountryCodeValidator.Object;
        }

        protected static string GetIban(string branchCode = BranchCode)
        {
            return string.Concat(
                CountryCode,
                NationalCheckDigits,
                GetBban(branchCode));
        }
    }
}