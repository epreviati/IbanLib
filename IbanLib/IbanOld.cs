using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;
using IbanLib.Countries;
using IbanLib.Exceptions;
using IbanLib.Validators.Validators;

namespace IbanLib
{
    public class IbanOld
    {
        # region Constructors

        /// <summary>
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="bankCode"></param>
        /// <param name="accountNumber"></param>
        /// <exception cref="InvalidCountryCodeException"></exception>
        /// <exception cref="InvalidIbanDetailException"></exception>
        public IbanOld(string countryCode, string bankCode, string accountNumber)
            : this(Util.GetCountry(Normalize(countryCode)), bankCode, null, accountNumber)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bankCode"></param>
        /// <param name="accountNumber"></param>
        /// <exception cref="InvalidIbanException"></exception>
        /// <exception cref="InvalidIbanDetailException"></exception>
        public IbanOld(ICountry country, string bankCode, string accountNumber)
            : this(country, bankCode, null, accountNumber)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="bankCode"></param>
        /// <param name="branchCode"></param>
        /// <param name="accountNumber"></param>
        /// <exception cref="InvalidIbanException"></exception>
        /// <exception cref="InvalidIbanDetailException"></exception>
        public IbanOld(string countryCode, string bankCode, string branchCode, string accountNumber)
            : this(Util.GetCountry(Normalize(countryCode)), bankCode, branchCode, accountNumber)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bankCode"></param>
        /// <param name="branchCode"></param>
        /// <param name="accountNumber"></param>
        /// <exception cref="InvalidIbanDetailException"></exception>
        /// <exception cref="InvalidCheckDigitsException"></exception>
        public IbanOld(ICountry country, string bankCode, string branchCode, string accountNumber)
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
                !new BankCodeValidator().IsValid(country, BankCode),
                DetailType.BankCode,
                typeof (string).Name);

            Debug.Assert(country != null, "country != null");
            CheckArgumentInvalid(
                !new BranchCodeValidator().IsValid(country, BranchCode),
                DetailType.BranchCode,
                typeof (string).Name);

            CheckArgumentInvalid(
                !new AccountNumberValidator().IsValid(country, AccountNumber),
                DetailType.AccountNumber,
                typeof (string).Name);

            NationalCheckDigits = CalculateNationalCheckDigits(
                string.Concat(
                    Country.ISO3166,
                    "00",
                    BankCode,
                    BranchCode,
                    AccountNumber));
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <exception cref="InvalidIbanException"></exception>
        /// <exception cref="IbanSplitterException"></exception>
        public IbanOld(string iban)
        {
            iban = Normalize(iban);
            var countryCode = iban.Substring(0, 2);

            if (!new CountryCodeValidator().IsValid(countryCode))
            {
                throw new InvalidIbanException(
                    string.Format(
                        "The IBAN parameter '{0}' has an invalid country code '{1}'.",
                        iban,
                        countryCode));
            }

            Country = Util.GetCountry(countryCode);

            var splitter = new IbanSplitter(Country, new IbanValidator());
            NationalCheckDigits = splitter.GetNationalCheckDigitsFromIban(iban);
            BankCode = splitter.GetBankIdentifierFromIban(iban);
            BranchCode = splitter.GetBranchIdentifierFromIban(iban);
            AccountNumber = splitter.GetAccountNumberFromIban(iban);
        }


        /// <summary>
        /// </summary>
        public IbanOld()
        {
        }

        #endregion

        # region Details

        private string _accountNumber;
        private string _bankCode;
        private string _branchCode;
        private string _nationalCheckDigits = "00";

        public ICountry Country { get; set; }

        /// <summary>
        /// </summary>
        public string NationalCheckDigits
        {
            get { return _nationalCheckDigits; }
            set { _nationalCheckDigits = value; }
        }

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

        # endregion

        # region Methods

        private static readonly string[] From =
        {
            "A", "B", "C", "D", "E", "F",
            "G", "H", "I", "J", "K", "L",
            "M", "N", "O", "P", "Q", "R",
            "S", "T", "U", "V", "W", "X",
            "Y", "Z"
        };

        private static readonly string[] To =
        {
            "10", "11", "12", "13", "14", "15",
            "16", "17", "18", "19", "20", "21",
            "22", "23", "24", "25", "26", "27",
            "28", "29", "30", "31", "32", "33",
            "34", "35"
        };

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCheckDigitsException"></exception>
        public static string CalculateNationalCheckDigits(string iban)
        {
            if (!iban.Substring(2, 2).Equals("00"))
            {
                throw new InvalidCheckDigitsException(
                    "It is not possible to calculate the national check digits for the requested iban because it seems that it was already calculated.");
            }

            var truncated = iban.Substring(0, 4);
            var tmp = string.Concat(iban.Substring(4), truncated);

            for (var i = 0; i < From.Length; i++)
            {
                tmp = tmp.Replace(From[i], To[i]);
            }

            BigInteger n;
            BigInteger.TryParse(tmp, out n);

            return (98 - (n%97)).ToString("00");
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(
                "{0}{1}{2}{3}{4}",
                Country.ISO3166,
                NationalCheckDigits,
                BankCode,
                BranchCode,
                AccountNumber);
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

        # endregion
    }
}