using System.Numerics;
using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib.Structures
{
    public class Iban : IIban
    {
        # region Constructors

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        public Iban(ICountry country, IBban bban)
        {
            Bban = bban;
            NationalCheckDigits = CalculateNationalCheckDigits(
                string.Concat(
                    country.ISO3166,
                    NationalCheckDigits,
                    bban.Value()));
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <exception cref="InvalidIbanException"></exception>
        /// <exception cref="IbanSplitterException"></exception>
        public Iban(string iban)
            : this(iban, new DetailsValidator(), new Splitter())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <param name="validators"></param>
        /// <param name="splitter"></param>
        /// <exception cref="InvalidIbanException"></exception>
        public Iban(string iban, IDetailsValidator validators, ISplitter splitter)
        {
            iban = Util.Normalize(iban);
            var countryCode = splitter.GetIbanSplitter().GetCountryCode(iban);
            if (!validators.GetCountryCodeValidator().IsValid(countryCode))
            {
                throw new InvalidIbanException(
                    string.Format(
                        "The IBAN parameter '{0}' has an invalid country code '{1}'.",
                        iban,
                        countryCode));
            }

            var country = Countries.Util.GetCountry(countryCode);
            if (country == null)
            {
                throw new InvalidIbanException(
                    string.Format(
                        "The IBAN parameter '{0}' does not permits to calculate the country with the country code '{1}'.",
                        iban,
                        countryCode));
            }

            NationalCheckDigits = splitter.GetIbanSplitter().GetNationalCheckDigits(country, iban);
            Bban = new Bban(country, iban.Substring(4), validators, splitter.GetBbanSplitter());
        }

        #endregion

        # region Details

        /// <summary>
        /// </summary>
        public ICountry Country { get; set; }

        /// <summary>
        /// </summary>
        public IBban Bban { get; set; }

        /// <summary>
        /// </summary>
        public string NationalCheckDigits
        {
            get { return _nationalCheckDigits; }
            set { _nationalCheckDigits = value; }
        }

        private string _nationalCheckDigits = "00";

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
                "{0}: {1}\n" +
                "{2}: {3}\n" +
                "{4}: [\n{5}\n]",
                "Country", Country.ISO3166,
                "NationalCheckDigits", NationalCheckDigits,
                "BBAN", Bban);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string Value()
        {
            return string.Concat(
                Country.ISO3166,
                NationalCheckDigits,
                Bban.Value());
        }

        # endregion
    }
}