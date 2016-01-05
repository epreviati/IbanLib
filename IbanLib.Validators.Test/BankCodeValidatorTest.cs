using IbanLib.Countries;
using IbanLib.Countries.Countries;
using IbanLib.Domain.Validators;
using NUnit.Framework;

namespace IbanLib.Validators.Test
{
    [TestFixture]
    public class BankCodeValidatorTest
    {
        private readonly IBankCodeValidator _bankCodeValidator;

        public BankCodeValidatorTest()
        {
            _bankCodeValidator = new BankCodeValidator();
        }

        private void BankCodeValidator_Is_Not_Valid_Bank_Code(ICountry country, string bankCode)
        {
            Assert.IsFalse(_bankCodeValidator.IsValid(country, bankCode));
        }

        private void BankCodeValidator_Is_Valid_Bank_Code(ICountry country, string bankCode)
        {
            Assert.IsTrue(_bankCodeValidator.IsValid(country, bankCode));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("01234")]
        [TestCase("012")]
        [TestCase("ABCD")]
        [TestCase("ABCDE")]
        [TestCase("ABC")]
        [TestCase("0123A")]
        [TestCase("A0123")]
        public void BankCodeValidator_Is_Not_Valid_Bank_Code_AD(string bankCode)
        {
            BankCodeValidator_Is_Not_Valid_Bank_Code(new AD(), bankCode);
        }

        [Test]
        [TestCase("0123")]
        public void BankCodeValidator_Is_Valid_Bank_Code_AD(string bankCode)
        {
            BankCodeValidator_Is_Valid_Bank_Code(new AD(), bankCode);
        }
    }
}