using System.Numerics;
using IbanLib.Exceptions;

namespace IbanLib
{
    public class Iban
    {
        # region Constructors

        /// <summary>
        /// </summary>
        /// <param name="details"></param>
        /// <exception cref="InvalidIbanDetailException"></exception>
        /// <exception cref="InvalidCheckDigitsException"></exception>
        public Iban(IbanDetails details)
        {
            IbanDetails = details;
            NationalCheckDigits = CalculateNationalCheckDigits(
                string.Concat(
                    details.Country.ISO3166,
                    "00",
                    details.BankCode,
                    details.BranchCode,
                    details.AccountNumber));
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <exception cref="InvalidIbanException"></exception>
        /// <exception cref="IbanSplitterException"></exception>
        public Iban(string iban)
            : this(iban, new DetailsValidator())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <param name="validators"></param>
        /// <exception cref="InvalidIbanException"></exception>
        /// <exception cref="IbanSplitterException"></exception>
        public Iban(string iban, IDetailsValidator validators)
        {
            iban = Util.Normalize(iban);
            var countryCode = iban.Substring(0, 2);

            if (!validators.GetCountryCodeValidator().IsValid(countryCode))
            {
                throw new InvalidIbanException(
                    string.Format(
                        "The IBAN parameter '{0}' has an invalid country code '{1}'.",
                        iban,
                        countryCode));
            }

            var country = Countries.Util.GetCountry(countryCode);

            var splitter = new IbanSplitter(country, validators.GetIbanValidator());
            var bankCode = splitter.GetBankIdentifierFromIban(iban);
            var branchCode = splitter.GetBranchIdentifierFromIban(iban);
            var accountNumber = splitter.GetAccountNumberFromIban(iban);
            NationalCheckDigits = splitter.GetNationalCheckDigitsFromIban(iban);

            IbanDetails = new IbanDetails(country, bankCode, branchCode, accountNumber, validators);
        }

        /// <summary>
        /// </summary>
        public Iban()
        {
        }

        #endregion

        # region Details

        private string _nationalCheckDigits = "00";

        /// <summary>
        /// </summary>
        public IbanDetails IbanDetails { get; set; }

        /// <summary>
        /// </summary>
        public string NationalCheckDigits
        {
            get { return _nationalCheckDigits; }
            set { _nationalCheckDigits = value; }
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
                IbanDetails.Country.ISO3166,
                NationalCheckDigits,
                IbanDetails.BankCode,
                IbanDetails.BranchCode,
                IbanDetails.AccountNumber);
        }

        # endregion
    }
}