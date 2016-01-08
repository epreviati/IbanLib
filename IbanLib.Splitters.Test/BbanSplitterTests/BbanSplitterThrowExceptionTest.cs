using System;
using IbanLib.Countries;
using IbanLib.Exceptions;
using IbanLib.Test.Common;
using Moq;
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

            Action action2 = () => BbanSplitterInvalidValidation.GetAccountNumber(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetAccountNumber_It_Is_Not_Possible_To_Extract_The_Field_Expected_InvalidIbanException(string iban)
        {
            var country = new Mock<ICountry>();
            country
                .Setup(x => x.AccountNumberPosition)
                .Returns(5);
            country
                .Setup(x => x.AccountNumberLength)
                .Returns(5);

            Action action = () => BbanSplitterValidValidation.GetAccountNumber(
                country.Object,
                iban);
            TestUtil.ExpectedException<BbanSplitterException>(action);
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
                BbanSplitterInvalidValidation.GetAccountNumber(TestUtil.MockNotNullCountry, bban);
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

            Action action2 = () => BbanSplitterInvalidValidation.GetBankCode(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetBankCode_It_Is_Not_Possible_To_Extract_The_Field_Expected_InvalidIbanException(string iban)
        {
            var country = new Mock<ICountry>();
            country
                .Setup(x => x.BankCodePosition)
                .Returns(5);
            country
                .Setup(x => x.BankCodeLength)
                .Returns(5);

            Action action = () => BbanSplitterValidValidation.GetBankCode(
                country.Object,
                iban);
            TestUtil.ExpectedException<BbanSplitterException>(action);
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
                BbanSplitterInvalidValidation.GetBankCode(TestUtil.MockNotNullCountry, bban);
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

            Action action2 = () => BbanSplitterInvalidValidation.GetBranchCode(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetBranchCode_It_Is_Not_Possible_To_Extract_The_Field_Expected_InvalidIbanException(string iban)
        {
            var country = new Mock<ICountry>();
            country
                .Setup(x => x.BranchCodePosition)
                .Returns(5);
            country
                .Setup(x => x.BranchCodeLength)
                .Returns(5);

            Action action = () => BbanSplitterValidValidation.GetBranchCode(
                country.Object,
                iban);
            TestUtil.ExpectedException<BbanSplitterException>(action);
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
                BbanSplitterInvalidValidation.GetBranchCode(TestUtil.MockNotNullCountry, bban);
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

            Action action2 = () => BbanSplitterInvalidValidation.GetCheck1(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetCheck1_It_Is_Not_Possible_To_Extract_The_Field_Expected_InvalidIbanException(string iban)
        {
            var country = new Mock<ICountry>();
            country
                .Setup(x => x.Check1Position)
                .Returns(5);
            country
                .Setup(x => x.Check1Length)
                .Returns(5);

            Action action = () => BbanSplitterValidValidation.GetCheck1(
                country.Object,
                iban);
            TestUtil.ExpectedException<BbanSplitterException>(action);
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
                BbanSplitterInvalidValidation.GetCheck1(TestUtil.MockNotNullCountry, bban);
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

            Action action2 = () => BbanSplitterInvalidValidation.GetCheck2(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetCheck2_It_Is_Not_Possible_To_Extract_The_Field_Expected_InvalidIbanException(string iban)
        {
            var country = new Mock<ICountry>();
            country
                .Setup(x => x.Check2Position)
                .Returns(5);
            country
                .Setup(x => x.Check2Length)
                .Returns(5);

            Action action = () => BbanSplitterValidValidation.GetCheck2(
                country.Object,
                iban);
            TestUtil.ExpectedException<BbanSplitterException>(action);
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
                BbanSplitterInvalidValidation.GetCheck2(TestUtil.MockNotNullCountry, bban);
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

            Action action2 = () => BbanSplitterInvalidValidation.GetCheck3(null, bban);
            TestUtil.ExpectedException<InvalidCountryException>(action2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetCheck3_It_Is_Not_Possible_To_Extract_The_Field_Expected_InvalidIbanException(string iban)
        {
            var country = new Mock<ICountry>();
            country
                .Setup(x => x.Check3Position)
                .Returns(5);
            country
                .Setup(x => x.Check3Length)
                .Returns(5);

            Action action = () => BbanSplitterValidValidation.GetCheck3(
                country.Object,
                iban);
            TestUtil.ExpectedException<BbanSplitterException>(action);
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
                BbanSplitterInvalidValidation.GetCheck3(TestUtil.MockNotNullCountry, bban);
            };
            TestUtil.ExpectedException<BbanSplitterException>(action);
        }
    }
}