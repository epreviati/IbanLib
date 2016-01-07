using System.Diagnostics;
using IbanLib.Common;
using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
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
            CheckCountry(country);
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
            CheckArgumentInvalid(
                !validators.GetBankCodeValidator().IsValid(country, bankCode),
                DetailType.BankCode,
                typeof (string).Name);
            Debug.Assert(
                validators.GetBankCodeValidator().IsValid(country, bankCode),
                "validators.GetBankCodeValidator().IsValid(country, bankCode)");

            CheckArgumentInvalid(
                !validators.GetBranchCodeValidator().IsValid(country, branchCode),
                DetailType.BranchCode,
                typeof (string).Name);
            Debug.Assert(
                validators.GetBranchCodeValidator().IsValid(country, branchCode),
                "validators.GetBranchCodeValidator().IsValid(country, branchCode)");

            CheckArgumentInvalid(
                !validators.GetAccountNumberValidator().IsValid(country, accountNumber),
                DetailType.AccountNumber,
                typeof (string).Name);
            Debug.Assert(
                validators.GetAccountNumberValidator().IsValid(country, accountNumber),
                "validators.GetAccountNumberValidator().IsValid(country, accountNumber)");

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
            CheckArgumentInvalid(
                !validators.GetBbanValidator().IsValid(country, bban),
                DetailType.Bban,
                typeof (string).Name);
            Debug.Assert(
                validators.GetBankCodeValidator().IsValid(country, bban),
                "validators.GetBankCodeValidator().IsValid(country, bban)");

            CheckDigits1 = splitter.GetCheck1(country, bban);
            BankCode = splitter.GetBankCode(country, bban);
            BranchCode = splitter.GetBranchCode(country, bban);
            CheckDigits2 = splitter.GetCheck2(country, bban);
            AccountNumber = splitter.GetAccountNumber(country, bban);
            CheckDigits3 = splitter.GetCheck3(country, bban);

            CheckArgumentInvalid(
                !validators.GetBankCodeValidator().IsValid(country, BankCode),
                DetailType.BankCode,
                typeof (string).Name);
            Debug.Assert(
                validators.GetBankCodeValidator().IsValid(country, BankCode),
                "validators.GetBankCodeValidator().IsValid(country, BankCode)");

            CheckArgumentInvalid(
                !validators.GetBranchCodeValidator().IsValid(country, BranchCode),
                DetailType.BranchCode,
                typeof (string).Name);
            Debug.Assert(
                validators.GetBranchCodeValidator().IsValid(country, BranchCode),
                "validators.GetBranchCodeValidator().IsValid(country, BranchCode)");

            CheckArgumentInvalid(
                !validators.GetAccountNumberValidator().IsValid(country, AccountNumber),
                DetailType.AccountNumber,
                typeof (string).Name);
            Debug.Assert(
                validators.GetAccountNumberValidator().IsValid(country, AccountNumber),
                "validators.GetAccountNumberValidator().IsValid(country, AccountNumber)");
        }

        # endregion

        # region Fields

        /// <summary>
        /// </summary>
        public string CheckDigits1
        {
            get { return GetFieldValue(_checkDigits1); }
            set { _checkDigits1 = Util.Normalize(value); }
        }

        private string _checkDigits1;

        /// <summary>
        /// </summary>
        public string BankCode
        {
            get { return GetFieldValue(_bankCode); }
            set { _bankCode = Util.Normalize(value); }
        }

        private string _bankCode;

        /// <summary>
        /// </summary>
        public string BranchCode
        {
            get { return GetFieldValue(_branchCode); }
            set { _branchCode = Util.Normalize(value); }
        }

        private string _branchCode;

        /// <summary>
        /// </summary>
        public string CheckDigits2
        {
            get { return GetFieldValue(_checkDigits2); }
            set { _checkDigits2 = Util.Normalize(value); }
        }

        private string _checkDigits2;

        /// <summary>
        /// </summary>
        public string AccountNumber
        {
            get { return GetFieldValue(_accountNumber); }
            set { _accountNumber = Util.Normalize(value); }
        }

        private string _accountNumber;

        /// <summary>
        /// </summary>
        public string CheckDigits3
        {
            get { return GetFieldValue(_checkDigits3); }
            set { _checkDigits3 = Util.Normalize(value); }
        }

        private string _checkDigits3;

        # endregion

        # region Methods

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
        /// <param name="throwException"></param>
        /// <param name="detailType"></param>
        /// <param name="parameterType"></param>
        /// <exception cref="InvalidBbanDetailException"></exception>
        private static void CheckArgumentInvalid(bool throwException, DetailType detailType, string parameterType)
        {
            if (throwException)
            {
                throw new InvalidBbanDetailException(
                    detailType,
                    string.Format(
                        "Parameter '{0}' of type '{1}' has an invalid format.",
                        detailType,
                        parameterType));
            }
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