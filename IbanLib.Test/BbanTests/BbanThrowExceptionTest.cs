using System;
using IbanLib.Domain;
using IbanLib.Exceptions;
using IbanLib.Test.Common;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test.BbanTests
{
    public class BbanThrowExceptionTest : ABbanTest
    {
        [Test]
        public void Constructor_Parameters_Account_Number_Validator_Return_False_Expected_InvalidBbanDetailException()
        {
            var validators = new Mock<IValidators>();
            validators
                .Setup(x => x.GetBankCodeValidator())
                .Returns(GetBankCodeValidator(true));
            validators
                .Setup(x => x.GetBranchCodeValidator())
                .Returns(GetBranchCodeValidator(false));
            validators
                .Setup(x => x.GetAccountNumberValidator())
                .Returns(GetAccountNumberValidator(false));

            Action action =
                () => new Bban(
                    TestUtil.MockNotNullCountry,
                    null, null,
                    validators.Object);
            TestUtil.ExpectedException<InvalidBbanDetailException>(action);
        }

        [Test]
        public void Constructor_Parameters_Bank_Code_Validator_Return_False_Expected_InvalidBbanDetailException()
        {
            var validators = new Mock<IValidators>();
            validators
                .Setup(x => x.GetBankCodeValidator())
                .Returns(GetBankCodeValidator(false));

            Action action =
                () => new Bban(
                    TestUtil.MockNotNullCountry,
                    null, null,
                    validators.Object);
            TestUtil.ExpectedException<InvalidBbanDetailException>(action);
        }

        [Test]
        public void Constructor_Parameters_Branch_Code_Validator_Return_False_Expected_InvalidBbanDetailException()
        {
            var validators = new Mock<IValidators>();
            validators
                .Setup(x => x.GetBankCodeValidator())
                .Returns(GetBankCodeValidator(true));
            validators
                .Setup(x => x.GetBranchCodeValidator())
                .Returns(GetBranchCodeValidator(false));

            Action action =
                () => new Bban(
                    TestUtil.MockNotNullCountry,
                    null, null,
                    validators.Object);
            TestUtil.ExpectedException<InvalidBbanDetailException>(action);
        }

        [Test]
        public void Constructor_Parameters_Country_Is_Null_Expected_InvalidCountryException()
        {
            Action action = () => new Bban(null, "bankCode", "branchCode", "accountNumber", ValidValidators);
            TestUtil.ExpectedException<InvalidCountryException>(action);
        }
    }
}