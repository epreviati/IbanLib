using IbanLib.Countries;
using IbanLib.Countries.Countries;
using IbanLib.Domain.Validators;
using NUnit.Framework;

namespace IbanLib.Validators.Test
{
    [TestFixture]
    public class BranchCodeValidatorTest
    {
        private readonly IBranchCodeValidator _branchCodeValidator;

        public BranchCodeValidatorTest()
        {
            _branchCodeValidator = new BranchCodeValidator();
        }

        private void BranchCodeValidator_Is_Not_Valid_Branch_Code(ICountry country, string branchCode)
        {
            Assert.IsFalse(_branchCodeValidator.IsValid(country, branchCode));
        }

        private void BranchCodeValidator_Is_Valid_Branch_Code(ICountry country, string branchCode)
        {
            Assert.IsTrue(_branchCodeValidator.IsValid(country, branchCode));
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
        public void BranchCodeValidator_Is_Not_Valid_Branch_Code_AD(string branchCode)
        {
            BranchCodeValidator_Is_Not_Valid_Branch_Code(new AD(), branchCode);
        }

        [Test]
        [TestCase("-")]
        public void BranchCodeValidator_Is_Not_Valid_Branch_Code_AE(string branchCode)
        {
            BranchCodeValidator_Is_Not_Valid_Branch_Code(new AE(), branchCode);
        }

        [Test]
        [TestCase("-")]
        public void BranchCodeValidator_Is_Not_Valid_Branch_Code_AT(string branchCode)
        {
            BranchCodeValidator_Is_Not_Valid_Branch_Code(new AT(), branchCode);
        }

        [Test]
        [TestCase("-")]
        public void BranchCodeValidator_Is_Not_Valid_Branch_Code_AZ(string branchCode)
        {
            BranchCodeValidator_Is_Not_Valid_Branch_Code(new AZ(), branchCode);
        }

        [Test]
        [TestCase("-")]
        public void BranchCodeValidator_Is_Not_Valid_Branch_Code_BE(string branchCode)
        {
            BranchCodeValidator_Is_Not_Valid_Branch_Code(new BE(), branchCode);
        }

        [Test]
        [TestCase("-")]
        public void BranchCodeValidator_Is_Not_Valid_Branch_Code_BH(string branchCode)
        {
            BranchCodeValidator_Is_Not_Valid_Branch_Code(new BH(), branchCode);
        }

        [Test]
        [TestCase("0123")]
        public void BranchCodeValidator_Is_Valid_Branch_Code_AD(string branchCode)
        {
            BranchCodeValidator_Is_Valid_Branch_Code(new AD(), branchCode);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void BranchCodeValidator_Is_Valid_Branch_Code_AE(string branchCode)
        {
            BranchCodeValidator_Is_Valid_Branch_Code(new AE(), branchCode);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void BranchCodeValidator_Is_Valid_Branch_Code_AT(string branchCode)
        {
            BranchCodeValidator_Is_Valid_Branch_Code(new AT(), branchCode);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void BranchCodeValidator_Is_Valid_Branch_Code_AZ(string branchCode)
        {
            BranchCodeValidator_Is_Valid_Branch_Code(new AZ(), branchCode);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void BranchCodeValidator_Is_Valid_Branch_Code_BE(string branchCode)
        {
            BranchCodeValidator_Is_Valid_Branch_Code(new BE(), branchCode);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void BranchCodeValidator_Is_Valid_Branch_Code_BH(string branchCode)
        {
            BranchCodeValidator_Is_Valid_Branch_Code(new BH(), branchCode);
        }
    }
}