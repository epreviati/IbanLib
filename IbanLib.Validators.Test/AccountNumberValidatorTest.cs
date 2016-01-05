using IbanLib.Countries;
using IbanLib.Countries.Countries;
using IbanLib.Domain.Validators;
using NUnit.Framework;

namespace IbanLib.Validators.Test
{
    [TestFixture]
    public class AccountNumberValidatorTest
    {
        private readonly IAccountNumberValidator _accountNumberValidator;

        public AccountNumberValidatorTest()
        {
            _accountNumberValidator = new AccountNumberValidator();
        }

        private void AccountNumberValidator_Is_Not_Valid_Account_Number(ICountry country, string accountNumber)
        {
            Assert.IsFalse(_accountNumberValidator.IsValid(country, accountNumber));
        }

        private void AccountNumberValidator_Is_Valid_Account_Number(ICountry country, string accountNumber)
        {
            Assert.IsTrue(_accountNumberValidator.IsValid(country, accountNumber));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("01234567890")]
        [TestCase("0123456789012")]
        [TestCase("ABCDEFGHIJK")]
        [TestCase("ABCDEFGHIJKLJ")]
        public void AccountNumberValidator_Is_Not_Valid_Account_Number_AD(string accountNumber)
        {
            AccountNumberValidator_Is_Not_Valid_Account_Number(new AD(), accountNumber);
        }

        [Test]
        [TestCase("012345678901")]
        [TestCase("ABCDEFGHIJKL")]
        [TestCase("0123456789AB")]
        [TestCase("AB0123456789")]
        [TestCase("AB01234567CD")]
        [TestCase("AB012CD567EF")]
        public void AccountNumberValidator_Is_Valid_Account_Number_AD(string accountNumber)
        {
            AccountNumberValidator_Is_Valid_Account_Number(new AD(), accountNumber);
        }
    }
}