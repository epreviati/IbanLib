using System;
using IbanLib.Exceptions;
using IbanLib.Test.Common;
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
        public void GetAccountNumber_Expected_InvalidCountryException(string iban)
        {
            var bban = GetBbanFromIBan(iban);

            Action action1 = () => BbanSplitterValidValidation.GetAccountNumber(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action1);

            Action action2 = () => BbanSplitterInValidValidation.GetAccountNumber(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
        }

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
                BbanSplitterInValidValidation.GetAccountNumber(TestUtil.MockNotNullCountry, bban);
            };
            TestUtil.ExpectedException<BbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetBankCode_Expected_InvalidCountryException(string iban)
        {
            var bban = GetBbanFromIBan(iban);

            Action action1 = () => BbanSplitterValidValidation.GetBankCode(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action1);

            Action action2 = () => BbanSplitterInValidValidation.GetBankCode(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
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
                BbanSplitterInValidValidation.GetBankCode(TestUtil.MockNotNullCountry, bban);
            };
            TestUtil.ExpectedException<BbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetBranchCode_Expected_InvalidCountryException(string iban)
        {
            var bban = GetBbanFromIBan(iban);

            Action action1 = () => BbanSplitterValidValidation.GetBranchCode(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action1);

            Action action2 = () => BbanSplitterInValidValidation.GetBranchCode(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
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
                BbanSplitterInValidValidation.GetBranchCode(TestUtil.MockNotNullCountry, bban);
            };
            TestUtil.ExpectedException<BbanSplitterException>(action);
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
            TestUtil.ExpectedException<InvalidCountryException>(action1);

            Action action2 = () => BbanSplitterInValidValidation.GetCheck1(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
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
                BbanSplitterInValidValidation.GetCheck1(TestUtil.MockNotNullCountry, bban);
            };
            TestUtil.ExpectedException<BbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetCheck2_Expected_InvalidCountryException(string iban)
        {
            var bban = GetBbanFromIBan(iban);

            Action action1 = () => BbanSplitterValidValidation.GetCheck2(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action1);

            Action action2 = () => BbanSplitterInValidValidation.GetCheck2(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
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
                BbanSplitterInValidValidation.GetCheck2(TestUtil.MockNotNullCountry, bban);
            };
            TestUtil.ExpectedException<BbanSplitterException>(action);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("AD1200012030200359100100")]
        public void GetCheck3_Expected_InvalidCountryException(string iban)
        {
            var bban = GetBbanFromIBan(iban);

            Action action1 = () => BbanSplitterValidValidation.GetCheck3(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action1);

            Action action2 = () => BbanSplitterInValidValidation.GetCheck3(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
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
                BbanSplitterInValidValidation.GetCheck3(TestUtil.MockNotNullCountry, bban);
            };
            TestUtil.ExpectedException<BbanSplitterException>(action);
        }
    }
}