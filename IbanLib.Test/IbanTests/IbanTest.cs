using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test.IbanTests
{
    public class IbanTest : AIbanTest
    {
        public IbanTest()
        {
            var mockCountry = new Mock<ICountry>();
            mockCountry
                .Setup(x => x.Iso3166)
                .Returns(CountryCode);
            mockCountry
                .Setup(x => x.CalculateCheck1(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Check1);
            mockCountry
                .Setup(x => x.CalculateCheck2(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Check2);
            mockCountry
                .Setup(x => x.CalculateCheck3(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Check3);
            mockCountry
                .Setup(x => x.CalculateNationalCheckDigits(It.IsAny<string>()))
                .Returns(NationalCheckDigits);

            Country = mockCountry.Object;
        }

        private void AssertIban(IIban ibanObj, string branchCode = BranchCode)
        {
            Assert.IsNotNullOrEmpty(ibanObj.Value());
            Assert.IsNotNullOrEmpty(ibanObj.ToString());

            Assert.IsNotNull(ibanObj.Country);
            Assert.AreEqual(ibanObj.Country, Country);

            Assert.IsNotNull(ibanObj.NationalCheckDigits);
            Assert.AreEqual(ibanObj.NationalCheckDigits, NationalCheckDigits);

            Assert.IsNotNull(ibanObj.Bban);
            Assert.AreEqual(GetBban(branchCode), ibanObj.Bban.Value());
            Assert.AreEqual(GetIban(branchCode), ibanObj.Value());
        }

        [Test]
        public void Constructor_Empty()
        {
            var iban = new Iban();
            Assert.IsNull(iban.Country);
            Assert.IsNotNullOrEmpty(iban.NationalCheckDigits);
            Assert.AreEqual(NationalCheckDigits, iban.NationalCheckDigits);
            Assert.IsNull(iban.Bban);
            Assert.IsNullOrEmpty(iban.Value());
            Assert.IsNotNullOrEmpty(iban.ToString());
        }

        [Test]
        public void Constructor_Parameters()
        {
            var bban = new Mock<IBban>();
            bban.Setup(x => x.Value())
                .Returns(GetBban());

            var iban = new Iban(Country, bban.Object);
            AssertIban(iban);
        }

        [Test]
        public void Constructor_Splitter()
        {
            var countryResolver = new Mock<ICountryResolver>();
            countryResolver
                .Setup(x => x.GetCountry(It.IsAny<string>()))
                .Returns(Country);

            var bban = new Mock<IBban>();
            bban.Setup(x => x.Value())
                .Returns(GetBban());

            var bbanGenerator = new Mock<IBban>();
            bbanGenerator
                .Setup(
                    x => x.SplitBban(
                        It.IsAny<ICountry>(),
                        It.IsAny<string>(),
                        It.IsAny<IValidators>(),
                        It.IsAny<IBbanSplitter>()))
                .Returns(bban.Object);

            var iban = new Iban(
                GetIban(),
                countryResolver.Object, bbanGenerator.Object,
                ValidValidators, GetIBbanSplitter(), GetBbanSplitter());
            AssertIban(iban);
        }
    }
}