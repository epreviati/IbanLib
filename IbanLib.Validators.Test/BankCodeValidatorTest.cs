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
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("0123")]
        [TestCase("01")]
        [TestCase("01A")]
        [TestCase("A01")]
        [TestCase("ABC")]
        public void BankCodeValidator_Is_Not_Valid_Bank_Code_AE(string bankCode)
        {
            BankCodeValidator_Is_Not_Valid_Bank_Code(new AE(), bankCode);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("012345")]
        [TestCase("0123")]
        [TestCase("01234A")]
        [TestCase("A01234")]
        [TestCase("ABCDEF")]
        public void BankCodeValidator_Is_Not_Valid_Bank_Code_AT(string bankCode)
        {
            BankCodeValidator_Is_Not_Valid_Bank_Code(new AT(), bankCode);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("ABCDE")]
        [TestCase("ABC")]
        [TestCase("ABC0")]
        [TestCase("0ABC")]
        [TestCase("0123")]
        public void BankCodeValidator_Is_Not_Valid_Bank_Code_AZ(string bankCode)
        {
            BankCodeValidator_Is_Not_Valid_Bank_Code(new AZ(), bankCode);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("0123")]
        [TestCase("01")]
        [TestCase("01A")]
        [TestCase("A01")]
        [TestCase("ABC")]
        public void BankCodeValidator_Is_Not_Valid_Bank_Code_BE(string bankCode)
        {
            BankCodeValidator_Is_Not_Valid_Bank_Code(new BE(), bankCode);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("1234")]
        [TestCase("01234")]
        [TestCase("012")]
        [TestCase("012A")]
        [TestCase("A012")]
        public void BankCodeValidator_Is_Not_Valid_Bank_Code_BH(string bankCode)
        {
            BankCodeValidator_Is_Not_Valid_Bank_Code(new BH(), bankCode);
        }

        [Test]
        [TestCase("0123")]
        public void BankCodeValidator_Is_Valid_Bank_Code_AD(string bankCode)
        {
            BankCodeValidator_Is_Valid_Bank_Code(new AD(), bankCode);
        }

        [Test]
        [TestCase("012")]
        public void BankCodeValidator_Is_Valid_Bank_Code_AE(string bankCode)
        {
            BankCodeValidator_Is_Valid_Bank_Code(new AE(), bankCode);
        }

        [Test]
        [TestCase("01234")]
        public void BankCodeValidator_Is_Valid_Bank_Code_AT(string bankCode)
        {
            BankCodeValidator_Is_Valid_Bank_Code(new AT(), bankCode);
        }

        [Test]
        [TestCase("ABCD")]
        public void BankCodeValidator_Is_Valid_Bank_Code_AZ(string bankCode)
        {
            BankCodeValidator_Is_Valid_Bank_Code(new AZ(), bankCode);
        }

        [Test]
        [TestCase("012")]
        public void BankCodeValidator_Is_Valid_Bank_Code_BE(string bankCode)
        {
            BankCodeValidator_Is_Valid_Bank_Code(new BE(), bankCode);
        }

        [Test]
        [TestCase("ABCD")]
        public void BankCodeValidator_Is_Valid_Bank_Code_BH(string bankCode)
        {
            BankCodeValidator_Is_Valid_Bank_Code(new BH(), bankCode);
        }
    }
}