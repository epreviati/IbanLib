using System;
using IbanLib.Exceptions;
using IbanLib.Test.Common;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.IBanSplitterTest
{
    public class IbanSplitterThrowExceptionTest : AIbanSplitterTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetBban_Expected_InvalidCountryException(string iban)
        {
            Action action1 = () => IbanSplitterValidValidation.GetBban(null, iban);
            TestUtil.ExpectedException<InvalidCountryException>(action1);

            Action action2 = () => IbanSplitterInValidValidation.GetBban(null, iban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetBban_Throw_IbanSplitterException(string iban)
        {
            Action action = () => IbanSplitterInValidValidation.GetBban(TestUtil.MockNotNullCountry, iban);
            TestUtil.ExpectedException<IbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetCountryCode_Throw_IbanSplitterException(string iban)
        {
            Action action1 = () => IbanSplitterValidValidation.GetCountryCode(iban);
            TestUtil.ExpectedException<IbanSplitterException>(action1);

            Action action2 = () => IbanSplitterInValidValidation.GetCountryCode(iban);
            TestUtil.ExpectedException<IbanSplitterException>(action2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetNationalCheckDigits_Throw_IbanSplitterException(string iban)
        {
            Action action = () => IbanSplitterInValidValidation.GetNationalCheckDigits(
                TestUtil.MockNotNullCountry,
                iban);
            TestUtil.ExpectedException<IbanSplitterException>(action);
        }
    }
}