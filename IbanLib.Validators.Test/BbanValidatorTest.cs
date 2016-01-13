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
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("01201234567890123456")]
        [TestCase("012012345678901234")]
        [TestCase("012012345678901234A")]
        [TestCase("A012012345678901234")]
        [TestCase("ABCDEFGHIJKLMNOPQRS")]
        public void BbanValidator_Is_Not_Valid_Bban_AE(string bban)
        {
            BbanValidator_Is_Not_Valid_Bban(new AE(), bban);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("012340123456789")]
        [TestCase("01234012345678901")]
        [TestCase("012340123456789A")]
        [TestCase("A012340123456789")]
        [TestCase("ABCDEFGHIJKLMNOP")]
        public void BbanValidator_Is_Not_Valid_Bban_AT(string bban)
        {
            BbanValidator_Is_Not_Valid_Bban(new AT(), bban);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("ABCD012345678901234567890")]
        [TestCase("ABCD0123456789012345678")]
        [TestCase("ABCD0123456789ABCDEFGHIJK")]
        [TestCase("ABCD0123456789ABCDEFGHI")]
        [TestCase("ABCDABCDEFGHIJ01234567890")]
        [TestCase("ABCDABCDEFGHIJ012345678")]
        [TestCase("ABCDABCDEFGHIJABCDEFGHIJK")]
        [TestCase("ABCDABCDEFGHIJABCDEFGHI")]
        [TestCase("012301234567890123456789")]
        [TestCase("ABCDEABCDEFGHIJ0123456789")]
        [TestCase("ABC0123456789ABCDEFGHIJ")]
        [TestCase("ABC0ABCDEFGHIJABCDEFGHIJ")]
        [TestCase("0ABCABCDEFGHIJABCDEFGHIJ")]
        public void BbanValidator_Is_Not_Valid_Bban_AZ(string bban)
        {
            BbanValidator_Is_Not_Valid_Bban(new AZ(), bban);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("0120123456012")]
        [TestCase("01201234560")]
        [TestCase("012012345601A")]
        [TestCase("A012012345601")]
        [TestCase("ABCDEFGHIJKLM")]
        public void BbanValidator_Is_Not_Valid_Bban_BE(string bban)
        {
            BbanValidator_Is_Not_Valid_Bban(new BE(), bban);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-")]
        [TestCase("ABCD012345678901234")]
        [TestCase("ABCD0123456789012")]
        [TestCase("ABCD0123456ABCDEFGH")]
        [TestCase("ABCD0123456ABCDEF")]
        [TestCase("ABCDABCDEFG01234567")]
        [TestCase("ABCDABCDEFG012345")]
        [TestCase("ABCDABCDEFGABCDEFGH")]
        [TestCase("ABCDABCDEFGABCDEF")]
        [TestCase("ABCDE01234567890123")]
        [TestCase("ABC0123456ABCDEFG")]
        [TestCase("0ABCABCDEFG0123456")]
        [TestCase("ABC0ABCDEFGABCDEFG")]
        public void BbanValidator_Is_Not_Valid_Bban_BH(string bban)
        {
            BbanValidator_Is_Not_Valid_Bban(new BH(), bban);
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

        [Test]
        [TestCase("0120123456789012345")]
        public void BbanValidator_Is_Valid_Bban_AE(string bban)
        {
            BbanValidator_Is_Valid_Bban(new AE(), bban);
        }

        [Test]
        [TestCase("0123401234567890")]
        public void BbanValidator_Is_Valid_Bban_AT(string bban)
        {
            BbanValidator_Is_Valid_Bban(new AT(), bban);
        }

        [Test]
        [TestCase("ABCD01234567890123456789")]
        [TestCase("ABCD0123456789ABCDEFGHIJ")]
        [TestCase("ABCDABCDEFGHIJ0123456789")]
        [TestCase("ABCDABCDEFGHIJABCDEFGHIJ")]
        public void BbanValidator_Is_Valid_Bban_AZ(string bban)
        {
            BbanValidator_Is_Valid_Bban(new AZ(), bban);
        }

        [Test]
        [TestCase("012012345601")]
        public void BbanValidator_Is_Valid_Bban_BE(string bban)
        {
            BbanValidator_Is_Valid_Bban(new BE(), bban);
        }

        [Test]
        [TestCase("ABCD01234567890123")]
        [TestCase("ABCD0123456ABCDEFG")]
        [TestCase("ABCDABCDEFG0123456")]
        [TestCase("ABCDABCDEFGABCDEFG")]
        public void BbanValidator_Is_Valid_Bban_BH(string bban)
        {
            BbanValidator_Is_Valid_Bban(new BH(), bban);
        }
    }
}