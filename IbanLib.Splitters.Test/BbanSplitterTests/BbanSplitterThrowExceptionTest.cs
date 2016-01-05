using System;
using IbanLib.Exceptions;
using NUnit.Framework;

namespace IbanLib.Splitters.Test.BbanSplitterTests
{
    public class BbanSplitterThrowExceptionTest : ABbanSplitterTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetAccountNumber_Throw_BbanSplitterException(string iban)
        {
            Action action = () =>
            {
                var bban = GetBbanFromIBan(iban);
                BbanSplitterInValidValidation.GetAccountNumber(MockNotNullCountry, bban);
            };
            ExpectedException<BbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetBankCode_Throw_BbanSplitterException(string iban)
        {
            Action action = () =>
            {
                var bban = GetBbanFromIBan(iban);
                BbanSplitterInValidValidation.GetBankCode(MockNotNullCountry, bban);
            };
            ExpectedException<BbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetBranchCode_Throw_BbanSplitterException(string iban)
        {
            Action action = () =>
            {
                var bban = GetBbanFromIBan(iban);
                BbanSplitterInValidValidation.GetBranchCode(MockNotNullCountry, bban);
            };
            ExpectedException<BbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetCheck1_Expected_InvalidCountryException(string iban)
        {
            var bban = GetBbanFromIBan(iban);

            Action action1 = () => BbanSplitterValidValidation.GetCheck1(null, bban);
            ExpectedException<InvalidCountryException>(action1);

            Action action2 = () => BbanSplitterInValidValidation.GetCheck1(null, bban);
            ExpectedException<InvalidCountryException>(action2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetCheck1_Throw_BbanSplitterException(string iban)
        {
            Action action = () =>
            {
                var bban = GetBbanFromIBan(iban);
                BbanSplitterInValidValidation.GetCheck1(MockNotNullCountry, bban);
            };
            ExpectedException<BbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetCheck2_Throw_BbanSplitterException(string iban)
        {
            Action action = () =>
            {
                var bban = GetBbanFromIBan(iban);
                BbanSplitterInValidValidation.GetCheck2(MockNotNullCountry, bban);
            };
            ExpectedException<BbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetCheck3_Throw_BbanSplitterException(string iban)
        {
            Action action = () =>
            {
                var bban = GetBbanFromIBan(iban);
                BbanSplitterInValidValidation.GetCheck3(MockNotNullCountry, bban);
            };
            ExpectedException<BbanSplitterException>(action);
        }
    }
}