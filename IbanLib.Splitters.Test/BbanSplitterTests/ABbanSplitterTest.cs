using IbanLib.Countries;
using IbanLib.Domain.Splitters;
using IbanLib.Domain.Validators;
using Moq;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public abstract class ABbanSplitterTest : ASplitterTest
    {
        protected IBbanSplitter BbanSplitterValidValidation;
        protected IBbanSplitter BbanSplitterInValidValidation;

        protected ABbanSplitterTest()
        {
            BbanSplitterValidValidation = new BbanSplitter(GetMockIBbanValidator(true));
            BbanSplitterInValidValidation = new BbanSplitter(GetMockIBbanValidator(false));
        }

        protected static IBbanValidator GetMockIBbanValidator(bool validationResult)
        {
            var mockBbanValidator = new Mock<IBbanValidator>();

            mockBbanValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(validationResult);

            return mockBbanValidator.Object;
        }

        protected string GetBbanFromIBan(string iban)
        {
            return string.IsNullOrWhiteSpace(iban)
                ? iban
                : iban.Substring(4);
        }
    }
}