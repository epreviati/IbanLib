using System;
using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Exceptions;
using IbanLib.Test.Common;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test.IbanTests
{
    public class IbanThrowExceptionTest : AIbanTest
    {
        private static readonly IBban NotNullBban = new Mock<IBban>().Object;
        private static readonly ICountryResolver NotNullCountryResolver = new Mock<ICountryResolver>().Object;
        private static readonly IBbanGenerator NotNullBbanGenerator = new Mock<IBbanGenerator>().Object;
        private static readonly IValidators NotNullValidators = new Mock<IValidators>().Object;
        private static readonly IIbanSplitter NotNullIbanSplitter = new Mock<IIbanSplitter>().Object;
        private static readonly IBbanSplitter NotNullBbanSplitter = new Mock<IBbanSplitter>().Object;

        [Test]
        public void Constructo_Splitterr_Null_Country_Resolver_Expected_InvalidIbanException()
        {
            Action action = () => new Iban(
                GetIban(),
                null, NotNullBbanGenerator,
                NotNullValidators, NotNullIbanSplitter, NotNullBbanSplitter);
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }

        [Test]
        public void Constructor_Splitter_Null_Bban_Generator_Expected_InvalidIbanException()
        {
            Action action = () => new Iban(
                GetIban(),
                NotNullCountryResolver, null,
                NotNullValidators, NotNullIbanSplitter, NotNullBbanSplitter);
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }

        [Test]
        public void Constructor_Splitter_Null_Validators_Expected_InvalidIbanException()
        {
            Action action = () => new Iban(
                GetIban(),
                NotNullCountryResolver, NotNullBbanGenerator,
                null, NotNullIbanSplitter, NotNullBbanSplitter);
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }

        [Test]
        public void Constructor_Splitter_Null_Iban_Splitter_Expected_InvalidIbanException()
        {
            Action action = () => new Iban(
                GetIban(),
                NotNullCountryResolver, NotNullBbanGenerator,
                NotNullValidators, null, NotNullBbanSplitter);
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }

        [Test]
        public void Constructor_Splitter_Null_Bban_Splitter_Expected_InvalidIbanException()
        {
            Action action = () => new Iban(
                GetIban(),
                NotNullCountryResolver, NotNullBbanGenerator,
                NotNullValidators, NotNullIbanSplitter, null);
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }

        [Test]
        public void Constructor_Splitter_Country_Code_Validator_Return_False_Expected_InvalidIbanException()
        {
            Action action = () => new Iban(
                GetIban(),
                NotNullCountryResolver, NotNullBbanGenerator,
                GetValidators(false), NotNullIbanSplitter, NotNullBbanSplitter);
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }

        [Test]
        public void Constructor_Splitter_Country_Resolver_Return_Null_Expected_InvalidIbanException()
        {
            var countryResovler = new Mock<ICountryResolver>();
            countryResovler
                .Setup(x => x.GetCountry(It.IsAny<string>()))
                .Returns(() => null);

            Action action = () => new Iban(
                GetIban(),
                countryResovler.Object, NotNullBbanGenerator,
                GetValidators(true), NotNullIbanSplitter, NotNullBbanSplitter);
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }

        [Test]
        public void Constructor_Parameters_Bban_Is_Null_Expected_InvalidIbanException()
        {
            Action action = () => new Iban(TestUtil.MockNotNullCountry, null);
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }

        [Test]
        public void Constructor_Parameters_Country_Is_Null_Expected_InvalidCountryException()
        {
            Action action = () => new Iban(null, NotNullBban);
            TestUtil.ExpectedException<InvalidCountryException>(action);
        }

        [Test]
        public void Constructor_Parameters_Country_National_Check_Digits_Is_Not_Valid_Expected_InvalidIbanException()
        {
            Action action = () =>
            {
                var country = new Mock<ICountry>();
                country
                    .Setup(x => x.CalculateNationalCheckDigits(It.IsAny<string>()))
                    .Returns("INVALID_LENGHT");

                new Iban(country.Object, NotNullBban);
            };
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }

        [Test]
        public void Constructor_Parameters_Country_National_Check_Digits_Is_Null_Expected_InvalidIbanException()
        {
            Action action = () =>
            {
                var country = new Mock<ICountry>();
                country
                    .Setup(x => x.CalculateNationalCheckDigits(It.IsAny<string>()))
                    .Returns(string.Empty);

                new Iban(country.Object, NotNullBban);
            };
            TestUtil.ExpectedException<InvalidIbanException>(action);
        }
    }
}