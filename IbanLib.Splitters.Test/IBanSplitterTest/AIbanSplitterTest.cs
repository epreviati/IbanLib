using IbanLib.Countries;
using IbanLib.Domain.Splitters;
using IbanLib.Domain.Validators;
using Moq;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.IBanSplitterTest
{
    [TestFixture]
    public abstract class AIbanSplitterTest
    {
        protected IIbanSplitter IbanSplitterInvalidValidation;
        protected IIbanSplitter IbanSplitterValidValidation;

        protected AIbanSplitterTest()
        {
            IbanSplitterValidValidation = new IbanSplitter(GetMockIBbanValidator(true));
            IbanSplitterInvalidValidation = new IbanSplitter(GetMockIBbanValidator(false));
        }

        protected static IIbanValidator GetMockIBbanValidator(bool validationResult)
        {
            var mockBbanValidator = new Mock<IIbanValidator>();

            mockBbanValidator
                .Setup(x => x.IsValid(It.IsAny<ICountry>(), It.IsAny<string>()))
                .Returns(validationResult);

            return mockBbanValidator.Object;
        }
    }
}