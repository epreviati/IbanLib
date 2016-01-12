using System;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;
using IbanLib.Test.Common;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test
{
    public class DefaultValidatorsTest
    {
        [Test]
        public void Constructor_Not_Valid_IAccountNumberValidator_Parameter_Expected_Exception_ValidatorException()
        {
            Action action = () => new DefaultValidators(
                new Mock<IBankCodeValidator>().Object,
                new Mock<IBranchCodeValidator>().Object,
                null,
                new Mock<ICountryCodeValidator>().Object,
                new Mock<IIbanValidator>().Object,
                new Mock<IBbanValidator>().Object);

            TestUtil.ExpectedException<ValidatorException>(action);
        }

        [Test]
        public void Constructor_Not_Valid_IBankCodeValidator_Parameter_Expected_Exception_ValidatorException()
        {
            Action action = () => new DefaultValidators(
                null,
                new Mock<IBranchCodeValidator>().Object,
                new Mock<IAccountNumberValidator>().Object,
                new Mock<ICountryCodeValidator>().Object,
                new Mock<IIbanValidator>().Object,
                new Mock<IBbanValidator>().Object);

            TestUtil.ExpectedException<ValidatorException>(action);
        }

        [Test]
        public void Constructor_Not_Valid_IBbanValidator_Parameter_Expected_Exception_ValidatorException()
        {
            Action action = () => new DefaultValidators(
                new Mock<IBankCodeValidator>().Object,
                new Mock<IBranchCodeValidator>().Object,
                new Mock<IAccountNumberValidator>().Object,
                new Mock<ICountryCodeValidator>().Object,
                new Mock<IIbanValidator>().Object,
                null);

            TestUtil.ExpectedException<ValidatorException>(action);
        }

        [Test]
        public void Constructor_Not_Valid_IBranchCodeValidator_Parameter_Expected_Exception_ValidatorException()
        {
            Action action = () => new DefaultValidators(
                new Mock<IBankCodeValidator>().Object,
                null,
                new Mock<IAccountNumberValidator>().Object,
                new Mock<ICountryCodeValidator>().Object,
                new Mock<IIbanValidator>().Object,
                new Mock<IBbanValidator>().Object);

            TestUtil.ExpectedException<ValidatorException>(action);
        }

        [Test]
        public void Constructor_Not_Valid_ICountryCodeValidator_Parameter_Expected_Exception_ValidatorException()
        {
            Action action = () => new DefaultValidators(
                new Mock<IBankCodeValidator>().Object,
                new Mock<IBranchCodeValidator>().Object,
                new Mock<IAccountNumberValidator>().Object,
                null,
                new Mock<IIbanValidator>().Object,
                new Mock<IBbanValidator>().Object);

            TestUtil.ExpectedException<ValidatorException>(action);
        }

        [Test]
        public void Constructor_Not_Valid_IIbanValidator_Parameter_Expected_Exception_ValidatorException()
        {
            Action action = () => new DefaultValidators(
                new Mock<IBankCodeValidator>().Object,
                new Mock<IBranchCodeValidator>().Object,
                new Mock<IAccountNumberValidator>().Object,
                new Mock<ICountryCodeValidator>().Object,
                null,
                new Mock<IBbanValidator>().Object);

            TestUtil.ExpectedException<ValidatorException>(action);
        }

        [Test]
        public void Constructor_Valid()
        {
            new DefaultValidators(
                new Mock<IBankCodeValidator>().Object,
                new Mock<IBranchCodeValidator>().Object,
                new Mock<IAccountNumberValidator>().Object,
                new Mock<ICountryCodeValidator>().Object,
                new Mock<IIbanValidator>().Object,
                new Mock<IBbanValidator>().Object);
        }

        [Test]
        public void Getters_Works_Properly()
        {
            var bankCodeValidator = new Mock<IBankCodeValidator>().Object;
            var branchCodeValidator = new Mock<IBranchCodeValidator>().Object;
            var accountNumberValidator = new Mock<IAccountNumberValidator>().Object;
            var countryCodeValidator = new Mock<ICountryCodeValidator>().Object;
            var ibanValidator = new Mock<IIbanValidator>().Object;
            var bbanValidator = new Mock<IBbanValidator>().Object;

            var validators = new DefaultValidators(
                bankCodeValidator,
                branchCodeValidator,
                accountNumberValidator,
                countryCodeValidator,
                ibanValidator,
                bbanValidator);

            Assert.IsNotNull(validators.GetBankCodeValidator());
            Assert.AreEqual(bankCodeValidator, validators.GetBankCodeValidator());

            Assert.IsNotNull(validators.GetBranchCodeValidator());
            Assert.AreEqual(branchCodeValidator, validators.GetBranchCodeValidator());

            Assert.IsNotNull(validators.GetAccountNumberValidator());
            Assert.AreEqual(accountNumberValidator, validators.GetAccountNumberValidator());

            Assert.IsNotNull(validators.GetCountryCodeValidator());
            Assert.AreEqual(countryCodeValidator, validators.GetCountryCodeValidator());

            Assert.IsNotNull(validators.GetIbanValidator());
            Assert.AreEqual(ibanValidator, validators.GetIbanValidator());

            Assert.IsNotNull(validators.GetBbanValidator());
            Assert.AreEqual(bbanValidator, validators.GetBbanValidator());
        }
    }
}