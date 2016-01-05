using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    [TestFixture]
    public class IETest : ACountryTest
    {
        public IETest() : base(new IE())
        {
        }

        [Test]
        [TestCase("IE29AIBK93115212345678")]
        [TestCase("IE01AIBK93115212345678")]
        [TestCase("IE99AIBK93115212345678")]
        [TestCase("IE00AIBK9311521234567")]
        [TestCase("XX00AIBK93115212345678")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("IE29AIBK93115212345678")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}