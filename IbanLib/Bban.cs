using System.Diagnostics;
using IbanLib.Common;
using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;
using IbanLib.Exceptions.Enums;

namespace IbanLib
{
    /// <summary>
    /// </summary>
    public class Bban : AClass, IBban
    {
        # region Constructors

        /// <summary>
        /// </summary>
        public Bban()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        private Bban(ICountry country)
        {
            CheckNotNullCountry(country);
            Debug.Assert(country != null, "country != null");
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bankCode"></param>
        /// <param name="accountNumber"></param>
        /// <param name="validators"></param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="InvalidBbanDetailException"></exception>
        public Bban(ICountry country, string bankCode, string accountNumber, IValidators validators)
            : this(country, bankCode, null, accountNumber, validators)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bankCode"></param>
        /// <param name="branchCode"></param>
        /// <param name="accountNumber"></param>
        /// <param name="validators"></param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="InvalidBbanDetailException"></exception>
        public Bban(ICountry country, string bankCode, string branchCode, string accountNumber, IValidators validators)
            : this(country)
        {
            CheckIsValidArgument(
                validators.GetBankCodeValidator(),
                DetailType.Bban,
                country,
                BankCode,
                "BankCode");

            CheckIsValidArgument(
                validators.GetBranchCodeValidator(),
                DetailType.BranchCode,
                country,
                BranchCode,
                "BranchCode");

            CheckIsValidArgument(
                validators.GetAccountNumberValidator(),
                DetailType.AccountNumber,
                country,
                AccountNumber,
                "AccountNumber");

            BankCode = bankCode;
            BranchCode = branchCode;
            AccountNumber = accountNumber;
            CheckDigits1 = country.CalculateCheck1(BankCode, BranchCode, AccountNumber);
            CheckDigits2 = country.CalculateCheck2(BankCode, BranchCode, AccountNumber);
            CheckDigits3 = country.CalculateCheck3(BankCode, BranchCode, AccountNumber);
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <param name="validators"></param>
        /// <param name="splitter"></param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="InvalidBbanDetailException"></exception>
        public Bban(ICountry country, string bban, IValidators validators, IBbanSplitter splitter)
            : this(country)
        {
            SplitBban(country, bban, validators, splitter);
        }

        # endregion

        # region Fields

        /// <summary>
        /// </summary>
        public string CheckDigits1
        {
            get { return GetFieldValue(_checkDigits1); }
            set { _checkDigits1 = Normalize(value); }
        }

        private string _checkDigits1;

        /// <summary>
        /// </summary>
        public string BankCode
        {
            get { return GetFieldValue(_bankCode); }
            set { _bankCode = Normalize(value); }
        }

        private string _bankCode;

        /// <summary>
        /// </summary>
        public string BranchCode
        {
            get { return GetFieldValue(_branchCode); }
            set { _branchCode = Normalize(value); }
        }

        private string _branchCode;

        /// <summary>
        /// </summary>
        public string CheckDigits2
        {
            get { return GetFieldValue(_checkDigits2); }
            set { _checkDigits2 = Normalize(value); }
        }

        private string _checkDigits2;

        /// <summary>
        /// </summary>
        public string AccountNumber
        {
            get { return GetFieldValue(_accountNumber); }
            set { _accountNumber = Normalize(value); }
        }

        private string _accountNumber;

        /// <summary>
        /// </summary>
        public string CheckDigits3
        {
            get { return GetFieldValue(_checkDigits3); }
            set { _checkDigits3 = Normalize(value); }
        }

        private string _checkDigits3;

        # endregion

        # region Methods

        /// <summary>
        ///     The method splits the BBAN string to THIS BBAN object.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <param name="validators"></param>
        /// <param name="splitter"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="InvalidBbanDetailException"></exception>
        public IBban SplitBban(ICountry country, string bban, IValidators validators, IBbanSplitter splitter)
        {
            CheckIsValidArgument(
                validators.GetBbanValidator(),
                DetailType.Bban,
                country,
                bban,
                "bban");

            CheckDigits1 = splitter.GetCheck1(country, bban);
            BankCode = splitter.GetBankCode(country, bban);
            BranchCode = splitter.GetBranchCode(country, bban);
            CheckDigits2 = splitter.GetCheck2(country, bban);
            AccountNumber = splitter.GetAccountNumber(country, bban);
            CheckDigits3 = splitter.GetCheck3(country, bban);

            CheckIsValidArgument(
                validators.GetBankCodeValidator(),
                DetailType.BankCode,
                country,
                BankCode,
                "BankCode");

            CheckIsValidArgument(
                validators.GetBranchCodeValidator(),
                DetailType.BranchCode,
                country,
                BranchCode,
                "BranchCode");

            CheckIsValidArgument(
                validators.GetAccountNumberValidator(),
                DetailType.AccountNumber,
                country,
                AccountNumber,
                "AccountNumber");

            return this;
        }

        /// <summary>
        ///     The method throws an Exception of type <see cref="InvalidBbanDetailException" /> if the Field is not valid.
        /// </summary>
        /// <param name="validator">
        ///     Validator that perfmorms the validation.
        /// </param>
        /// <param name="detailType">
        ///     Enum that defines witch detail is under evaluation.
        /// </param>
        /// <param name="country">
        ///     Country to perform the validation.
        /// </param>
        /// <param name="field">
        ///     Field to validate.
        /// </param>
        /// <param name="fieldName">
        ///     Name of the field to validate.
        /// </param>
        /// <exception>
        ///     If the Field is not valid, an Exception of type <see cref="InvalidBbanDetailException" /> will be thrown.
        /// </exception>
        protected static void CheckIsValidArgument(
            IDetailValidator validator, DetailType detailType,
            ICountry country, string field, string fieldName)
        {
            CheckIsValidArgument<string, InvalidBbanDetailException>(validator, detailType, country, field, fieldName);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(
                "{00}: {01}\n" +
                "{02}: {03}\n" +
                "{04}: {05}\n" +
                "{06}: {07}\n" +
                "{08}: {09}\n" +
                "{10}: {11}",
                "CheckDigits1", ToStringField(CheckDigits1),
                "BankCode", ToStringField(BankCode),
                "BranchCode", ToStringField(BranchCode),
                "CheckDigits2", ToStringField(CheckDigits2),
                "AccountNumber", ToStringField(AccountNumber),
                "CheckDigits3", ToStringField(CheckDigits3));
        }

        /// <summary>
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private static string ToStringField(string field)
        {
            return string.IsNullOrWhiteSpace(field) ? "null" : field;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string Value()
        {
            return string.Concat(
                CheckDigits1,
                BankCode,
                BranchCode,
                CheckDigits2,
                AccountNumber,
                CheckDigits3);
        }

        /// <summary>
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private static string GetFieldValue(string field)
        {
            return string.IsNullOrWhiteSpace(field)
                ? null
                : field;
        }

        # endregion
    }
}