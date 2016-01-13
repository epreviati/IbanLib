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
        [TestCase("AD12000120302003591001000")]
        [TestCase("AD120001203020035910010")]
        public void IbanValidator_Is_Not_Valid_Iban_AD(string iban)
        {
            IbanValidator_Is_Not_Valid_Iban(new AD(), iban);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("AE000331234567890123456")]
        [TestCase("XX070331234567890123456")]
        [TestCase("AE0703312345678901234560")]
        [TestCase("AE07033123456789012345")]
        public void IbanValidator_Is_Not_Valid_Iban_AE(string iban)
        {
            IbanValidator_Is_Not_Valid_Iban(new AE(), iban);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("AT001904300234573201")]
        [TestCase("XX611904300234573201")]
        [TestCase("AT6119043002345732010")]
        [TestCase("AT61190430023457320")]
        public void IbanValidator_Is_Not_Valid_Iban_AT(string iban)
        {
            IbanValidator_Is_Not_Valid_Iban(new AT(), iban);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("AZ00NABZ00000000137010001944")]
        [TestCase("XX21NABZ00000000137010001944")]
        [TestCase("AZ21NABZ000000001370100019440")]
        [TestCase("AZ21NABZ0000000013701000194")]
        public void IbanValidator_Is_Not_Valid_Iban_AZ(string iban)
        {
            IbanValidator_Is_Not_Valid_Iban(new AZ(), iban);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("BE00539007547034")]
        [TestCase("XX68539007547034")]
        [TestCase("BE685390075470340")]
        [TestCase("BE6853900754703")]
        public void IbanValidator_Is_Not_Valid_Iban_BE(string iban)
        {
            IbanValidator_Is_Not_Valid_Iban(new BE(), iban);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("BH00BMAG00001299123456")]
        [TestCase("XX67BMAG00001299123456")]
        [TestCase("BH67BMAG000012991234560")]
        [TestCase("BH67BMAG0000129912345")]
        public void IbanValidator_Is_Not_Valid_Iban_BH(string iban)
        {
            IbanValidator_Is_Not_Valid_Iban(new BH(), iban);
        }

        [Test]
        [TestCase("AD1200012030200359100100")]
        public void IbanValidator_Is_Valid_Iban_AD(string iban)
        {
            IbanValidator_Is_Valid_Iban(new AD(), iban);
        }

        [Test]
        [TestCase("AE070331234567890123456")]
        public void IbanValidator_Is_Valid_Iban_AE(string iban)
        {
            IbanValidator_Is_Valid_Iban(new AE(), iban);
        }

        [Test]
        [TestCase("AT611904300234573201")]
        public void IbanValidator_Is_Valid_Iban_AT(string iban)
        {
            IbanValidator_Is_Valid_Iban(new AT(), iban);
        }

        [Test]
        [TestCase("AZ21NABZ00000000137010001944")]
        public void IbanValidator_Is_Valid_Iban_AZ(string iban)
        {
            IbanValidator_Is_Valid_Iban(new AZ(), iban);
        }

        [Test]
        [TestCase("BE68539007547034")]
        public void IbanValidator_Is_Valid_Iban_BE(string iban)
        {
            IbanValidator_Is_Valid_Iban(new BE(), iban);
        }

        [Test]
        [TestCase("BH67BMAG00001299123456")]
        public void IbanValidator_Is_Valid_Iban_BH(string iban)
        {
            IbanValidator_Is_Valid_Iban(new BH(), iban);
        }
    }
}