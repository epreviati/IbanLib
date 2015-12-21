using System.Diagnostics;
using IbanLib.Countries;
using IbanLib.Exceptions;
using IbanLib.Exceptions.Enums;
using IbanLib.Splitters;
using IbanLib.Splitters.Splitters;

namespace IbanLib.Structures
{
    public class Bban : IBban
    {
        # region Constructors

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bankCode"></param>
        /// <param name="accountNumber"></param>
        /// <param name="validators"></param>
        /// <exception cref="InvalidBbanDetailException"></exception>
        public Bban(ICountry country, string bankCode, string accountNumber, IDetailsValidator validators)
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
        /// <exception cref="InvalidBbanDetailException"></exception>
        public Bban(ICountry country, string bankCode, string branchCode, string accountNumber,
            IDetailsValidator validators)
        {
            CheckArgumentNull(
                country == null,
                DetailType.CountryCode,
                typeof (ICountry).Name);

            CheckArgumentNull(
                string.IsNullOrWhiteSpace(bankCode),
                DetailType.BankCode,
                typeof (string).Name);

            Debug.Assert(country != null, "country != null");
            CheckArgumentNull(
                country.BranchIdentifierLength > 0 && string.IsNullOrWhiteSpace(branchCode),
                DetailType.BranchCode,
                typeof (string).Name);

            CheckArgumentNull(
                string.IsNullOrWhiteSpace(accountNumber),
                DetailType.AccountNumber,
                typeof (string).Name);

            BankCode = bankCode;
            BranchCode = branchCode;
            AccountNumber = accountNumber;

            CheckArgumentInvalid(
                !validators.GetBankCodeValidator().IsValid(country, BankCode),
                DetailType.BankCode,
                typeof (string).Name);

            Debug.Assert(country != null, "country != null");
            CheckArgumentInvalid(
                !validators.GetBranchCodeValidator().IsValid(country, BranchCode),
                DetailType.BranchCode,
                typeof (string).Name);

            CheckArgumentInvalid(
                !validators.GetAccountNumberValidator().IsValid(country, AccountNumber),
                DetailType.AccountNumber,
                typeof (string).Name);

            // TODO: do here

            CheckDigits1 = null;
            CheckDigits2 = null;
            CheckDigits3 = null;
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <exception cref="InvalidBbanDetailException"></exception>
        public Bban(ICountry country, string bban)
            : this(country, bban, new DetailsValidator(), new BbanSplitter())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <param name="validators"></param>
        /// <param name="splitter"></param>
        /// <exception cref="InvalidBbanDetailException"></exception>
        public Bban(ICountry country, string bban, IDetailsValidator validators, IBbanSplitter splitter)
        {
            CheckArgumentNull(
                country == null,
                DetailType.CountryCode,
                typeof (ICountry).Name);

            CheckArgumentNull(
                string.IsNullOrWhiteSpace(bban),
                DetailType.Bban,
                typeof (string).Name);

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

            Debug.Assert(country != null, "country != null");
            CheckArgumentInvalid(
                !validators.GetBranchCodeValidator().IsValid(country, BranchCode),
                DetailType.BranchCode,
                typeof (string).Name);

            CheckArgumentInvalid(
                !validators.GetAccountNumberValidator().IsValid(country, AccountNumber),
                DetailType.AccountNumber,
                typeof (string).Name);
        }

        # endregion

        # region Fields

        /// <summary>
        /// </summary>
        public string CheckDigits1
        {
            get { return _checkDigits1; }
            set { _checkDigits1 = Util.Normalize(value); }
        }

        private string _checkDigits1;

        /// <summary>
        /// </summary>
        public string BankCode
        {
            get { return _bankCode; }
            set { _bankCode = Util.Normalize(value); }
        }

        private string _bankCode;

        /// <summary>
        /// </summary>
        public string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = Util.Normalize(value); }
        }

        private string _branchCode;

        /// <summary>
        /// </summary>
        public string CheckDigits2
        {
            get { return _checkDigits2; }
            set { _checkDigits2 = Util.Normalize(value); }
        }

        private string _checkDigits2;

        /// <summary>
        /// </summary>
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = Util.Normalize(value); }
        }

        private string _accountNumber;

        /// <summary>
        /// </summary>
        public string CheckDigits3
        {
            get { return _checkDigits3; }
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
                "{10}: {11}\n",
                "CheckDigits1", CheckDigits1,
                "BankCode", BankCode,
                "BranchCode", BranchCode,
                "CheckDigits2", CheckDigits2,
                "AccountNumber", AccountNumber,
                "CheckDigits3", CheckDigits3);
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
        private static void CheckArgumentNull(bool throwException, DetailType detailType, string parameterType)
        {
            if (throwException)
            {
                throw new InvalidBbanDetailException(
                    detailType,
                    string.Format(
                        "Parameter '{0}' of type '{1}' can not be null{2}.",
                        detailType,
                        parameterType,
                        parameterType.Equals(typeof (string).Name) ? " or white space" : string.Empty));
            }
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
                        "The parameter '{0}' of type '{1}' has an invalid format.",
                        detailType,
                        parameterType));
            }
        }

        # endregion
    }
}