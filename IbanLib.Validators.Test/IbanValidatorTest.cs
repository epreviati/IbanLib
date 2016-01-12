using IbanLib.Countries;
using IbanLib.Countries.Countries;
using IbanLib.Domain.Validators;
using NUnit.Framework;

namespace IbanLib.Validators.Test
{
    [TestFixture]
    public class IbanValidatorTest
    {
        private readonly IIbanValidator _ibanValidator;

        public IbanValidatorTest()
        {
            _ibanValidator = new IbanValidator();
        }

        private void IbanValidator_Is_Not_Valid_Iban(ICountry country, string iban)
        {
            Assert.IsFalse(_ibanValidator.IsValid(country, iban));
        }

        private void IbanValidator_Is_Valid_Iban(ICountry country, string iban)
        {
            Assert.IsTrue(_ibanValidator.IsValid(country, iban));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("AD0000012030200359100100")]
        [TestCase("XX1200012030200359100100")]
        [TestCase("AD1200AB2030200359100100")]
        [TestCase("AD12000120AB200359100100")]
        [TestCase("AD12000120300200359100100")]
        [TestCase("AD120001203000359100100")]
        [TestCase("AD12000012030200359100100")]
        [TestCase("AD12000102030200359100100")]
        [TestCase("AD1200020003000000000001")]
        public void IbanValidator_Is_Not_Valid_Iban_AD(string iban)
        {
            IbanValidator_Is_Not_Valid_Iban(new AD(), iban);
        }

        [Test]
        [TestCase("AD1200012030200359100100")]
        public void IbanValidator_Is_Valid_Iban_AD(string iban)
        {
            IbanValidator_Is_Valid_Iban(new AD(), iban);
        }
    }
}