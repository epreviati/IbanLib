using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib.Structures
{
    public class Iban : IIban
    {
        # region Constructors

        /// <summary>
        /// </summary>
        public Iban()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        public Iban(ICountry country, IBban bban)
        {
            if (country == null)
            {
                throw new InvalidIbanException(
                    string.Format(
                        "The country parameters of type {0} can not be null.",
                        typeof (ICountry)));
            }

            if (bban == null)
            {
                throw new InvalidIbanException(
                    string.Format(
                        "The bban parameters of type {0} can not be null.",
                        typeof (IBban)));
            }

            Country = country;
            Bban = bban;
            NationalCheckDigits = country.CalculateNationalCheckDigits(
                string.Concat(
                    country.ISO3166,
                    NationalCheckDigits,
                    bban.Value()));

            if (NationalCheckDigits == null || NationalCheckDigits.Length != 2)
            {
                throw new InvalidIbanException(
                    string.Format(
                        "It is not possible to calculate the 'National Check Digits' with the requested Country '{0}' and BBAN '{1}'.",
                        Country.ISO3166,
                        Bban.Value()));
            }
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

            Country = Countries.Util.GetCountry(countryCode);
            if (Country == null)
            {
                throw new InvalidIbanException(
                    string.Format(
                        "The IBAN parameter '{0}' does not permits to calculate the country with the country code '{1}'.",
                        iban,
                        countryCode));
            }

            NationalCheckDigits = splitter.GetIbanSplitter().GetNationalCheckDigits(Country, iban);
            Bban = new Bban(Country, iban.Substring(4), validators, splitter.GetBbanSplitter());
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

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(
                "{0}: {1}\n" +
                "{2}: {3}\n" +
                "{4}: [\n{5}\n]",
                "Country", ToStringField(Country.ISO3166),
                "NationalCheckDigits", ToStringField(NationalCheckDigits),
                "BBAN", ToStringField(Bban.ToString()));
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
                Country.ISO3166,
                NationalCheckDigits,
                Bban.Value());
        }

        # endregion
    }
}