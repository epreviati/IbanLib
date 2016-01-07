using IbanLib.Countries.Countries;
using NUnit.Framework;

namespace IbanLib.Countries.Test.Countries
{
    public class MRTest : ACountryTest
    {
        public MRTest() : base(new MR())
        {
        }

        [Test]
        [TestCase("MR1300012000010000002037372")]
        [TestCase("MR0100012000010000002037372")]
        [TestCase("MR9900012000010000002037372")]
        [TestCase("MR000001200001000000203737")]
        [TestCase("XX0000012000010000002037372")]
        public new void CalculateNationalCheckDigits_Invalid_Iban_Return_Null(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Invalid_Iban_Return_Null(iban);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("MR1300012000010000002037372")]
        public new void CalculateNationalCheckDigits_Valid_Iban_Test_Success(string iban)
        {
            var result = base.CalculateNationalCheckDigits_Valid_Iban_Test_Success(iban);
            Assert.IsTrue(result);
        }
    }
}