using IbanLib.Countries;
using IbanLib.Countries.Countries;
using IbanLib.Domain.Validators;
using NUnit.Framework;

namespace IbanLib.Validators.Test
{
    [TestFixture]
    public class BbanValidatorTest
    {
        private readonly IBbanValidator _bbanValidator;

        public BbanValidatorTest()
        {
            _bbanValidator = new BbanValidator();
        }

        private void BbanValidator_Is_Not_Valid_Bban(ICountry country, string bban)
        {
            Assert.IsFalse(_bbanValidator.IsValid(country, bban));
        }

        private void BbanValidator_Is_Valid_Bban(ICountry country, string bban)
        {
            Assert.IsTrue(_bbanValidator.IsValid(country, bban));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("0120123012345ABCDEF")]
        [TestCase("0123012012345ABCDEF")]
        [TestCase("01230123012345ABCDE")]
        [TestCase("012340123012345ABCDEF")]
        [TestCase("012301234012345ABCDEF")]
        [TestCase("012301230123456ABCDEF")]
        [TestCase("01230123012345ABCDEFG")]
        [TestCase("01AB0123012345ABCDEF")]
        [TestCase("012301AB012345ABCDEF")]
        public void BbanValidator_Is_Not_Valid_Bban_AD(string bban)
        {
            BbanValidator_Is_Not_Valid_Bban(new AD(), bban);
        }

        [Test]
        [TestCase("01230123012345ABCDEF")]
        [TestCase("01230123012345678901")]
        [TestCase("01230123ABCDEFGHIJKL")]
        [TestCase("01230123ABCDEF012345")]
        public void BbanValidator_Is_Valid_Bban_AD(string bban)
        {
            BbanValidator_Is_Valid_Bban(new AD(), bban);
        }
    }
}