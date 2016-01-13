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
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("012345678901234")]
        [TestCase("01234567890123456")]
        [TestCase("012345678901234A")]
        [TestCase("A123456789012345")]
        [TestCase("ABCDEFGHIJKLMNOP")]
        public void AccountNumberValidator_Is_Not_Valid_Account_Number_AE(string accountNumber)
        {
            AccountNumberValidator_Is_Not_Valid_Account_Number(new AE(), accountNumber);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("012345678901")]
        [TestCase("0123456789")]
        [TestCase("0123456789A")]
        [TestCase("A1234567890")]
        [TestCase("ABCDEFGHIJK")]
        public void AccountNumberValidator_Is_Not_Valid_Account_Number_AT(string accountNumber)
        {
            AccountNumberValidator_Is_Not_Valid_Account_Number(new AT(), accountNumber);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("0123456789012345678")]
        [TestCase("012345678901234567890")]
        [TestCase("01234567890123456789A")]
        [TestCase("A01234567890123456789")]
        [TestCase("ABCDEFGHIJABCDEFGHIJK")]
        [TestCase("ABCDEFGHIJABCDEFGHI")]
        public void AccountNumberValidator_Is_Not_Valid_Account_Number_AZ(string accountNumber)
        {
            AccountNumberValidator_Is_Not_Valid_Account_Number(new AZ(), accountNumber);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("01234567")]
        [TestCase("012345")]
        [TestCase("012345A")]
        [TestCase("A012345")]
        [TestCase("ABCDEFG")]
        public void AccountNumberValidator_Is_Not_Valid_Account_Number_BE(string accountNumber)
        {
            AccountNumberValidator_Is_Not_Valid_Account_Number(new BE(), accountNumber);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("012345678901234")]
        [TestCase("0123456789012")]
        [TestCase("01234567890123A")]
        [TestCase("A01234567890123")]
        [TestCase("ABCDEFGABCDEFGH")]
        [TestCase("ABCDEFGABCDEF")]
        public void AccountNumberValidator_Is_Not_Valid_Account_Number_BH(string accountNumber)
        {
            AccountNumberValidator_Is_Not_Valid_Account_Number(new BH(), accountNumber);
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

        [Test]
        [TestCase("0123456789012345")]
        public void AccountNumberValidator_Is_Valid_Account_Number_AE(string accountNumber)
        {
            AccountNumberValidator_Is_Valid_Account_Number(new AE(), accountNumber);
        }

        [Test]
        [TestCase("01234567890")]
        public void AccountNumberValidator_Is_Valid_Account_Number_AT(string accountNumber)
        {
            AccountNumberValidator_Is_Valid_Account_Number(new AT(), accountNumber);
        }

        [Test]
        [TestCase("01234567890123456789")]
        [TestCase("0123456789ABCDEFGHIJ")]
        [TestCase("ABCDEFGHIJ0123456789")]
        [TestCase("ABCDEFGHIJABCDEFGHIJ")]
        public void AccountNumberValidator_Is_Valid_Account_Number_AZ(string accountNumber)
        {
            AccountNumberValidator_Is_Valid_Account_Number(new AZ(), accountNumber);
        }

        [Test]
        [TestCase("0123456")]
        public void AccountNumberValidator_Is_Valid_Account_Number_BE(string accountNumber)
        {
            AccountNumberValidator_Is_Valid_Account_Number(new BE(), accountNumber);
        }

        [Test]
        [TestCase("01234567890123")]
        [TestCase("0123456ABCDEFG")]
        [TestCase("ABCDEFG0123456")]
        [TestCase("ABCDEFGABCDEFG")]
        public void AccountNumberValidator_Is_Valid_Account_Number_BH(string accountNumber)
        {
            AccountNumberValidator_Is_Valid_Account_Number(new BH(), accountNumber);
        }
    }
}