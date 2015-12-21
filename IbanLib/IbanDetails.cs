using System.Diagnostics;
using System.Text.RegularExpressions;
using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib
{
    public class IbanDetails
    {
        private string _accountNumber;
        private string _bankCode;
        private string _branchCode;

        public IbanDetails(ICountry country, string bankCode, string accountNumber)
            : this(country, bankCode, null, accountNumber)
        {
        }

        public IbanDetails(ICountry country, string bankCode, string branchCode, string accountNumber)
            : this(country, bankCode, branchCode, accountNumber, new DetailsValidator())
        {
        }

        public IbanDetails(ICountry country, string bankCode, string accountNumber, IDetailsValidator validators)
            : this(country, bankCode, null, accountNumber, validators)
        {
        }

        public IbanDetails(ICountry country, string bankCode, string branchCode, string accountNumber,
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
                country.BranchIdentifierLength != 0 && string.IsNullOrWhiteSpace(branchCode),
                DetailType.BranchCode,
                typeof (string).Name);

            CheckArgumentNull(
                string.IsNullOrWhiteSpace(accountNumber),
                DetailType.AccountNumber,
                typeof (string).Name);

            Country = country;
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
        }

        public ICountry Country { get; set; }


        /// <summary>
        /// </summary>
        public string BankCode
        {
            get { return _bankCode; }
            set { _bankCode = Normalize(value); }
        }

        /// <summary>
        /// </summary>
        public string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = Normalize(value); }
        }

        /// <summary>
        /// </summary>
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = Normalize(value); }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(
                "{0}: {1}\n" +
                "{2}: {3}\n" +
                "{4}: {5}\n" +
                "{6}: {7}",
                "CountryCode", Country.ISO3166,
                "BankCode", BankCode,
                "BranchCode", BranchCode,
                "AccountNumber", AccountNumber);
        }

        /// <summary>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Normalize(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            var strUpperInvariant = str.ToUpperInvariant();
            var strWithoutDashes = Regex.Replace(strUpperInvariant, @"-+", string.Empty);
            var strWithoutSpaces = Regex.Replace(strWithoutDashes, @"\s+", string.Empty);
            return strWithoutSpaces;
        }

        /// <summary>
        /// </summary>
        /// <param name="throwException"></param>
        /// <param name="detailType"></param>
        /// <param name="parameterType"></param>
        /// <exception cref="InvalidIbanDetailException"></exception>
        private static void CheckArgumentNull(bool throwException, DetailType detailType, string parameterType)
        {
            if (throwException)
            {
                throw new InvalidIbanDetailException(
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
        /// <exception cref="InvalidIbanDetailException"></exception>
        private static void CheckArgumentInvalid(bool throwException, DetailType detailType, string parameterType)
        {
            if (throwException)
            {
                throw new InvalidIbanDetailException(
                    detailType,
                    string.Format(
                        "The parameter '{0}' of type '{1}' has an invalid format.",
                        detailType,
                        parameterType));
            }
        }
    }
}