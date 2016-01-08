using System.Diagnostics;
using IbanLib.Common;
using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Exceptions;

namespace IbanLib
{
    /// <summary>
    /// </summary>
    public class Iban : AClass, IIban
    {
        # region Constructors

        /// <summary>
        /// </summary>
        public Iban()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="bban"></param>
        /// <exception cref="InvalidIbanDetailException"></exception>
        private Iban(IBban bban)
        {
            CheckNotNullArgument<IBban>(bban, "bban");
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="InvalidIbanDetailException"></exception>
        public Iban(ICountry country, IBban bban)
            : this(bban)
        {
            CheckNotNullCountry(country);

            Country = country;
            Bban = bban;
            var nationalCheckDigits = country.CalculateNationalCheckDigits(
                string.Concat(
                    country.Iso3166,
                    NationalCheckDigits,
                    bban.Value()));

            if (string.IsNullOrWhiteSpace(nationalCheckDigits) || nationalCheckDigits.Length != 2)
            {
                throw new InvalidIbanException(
                    string.Format(
                        "It is not possible to calculate the 'National Check Digits' with the requested Country '{0}' and BBAN '{1}'.",
                        Country.Iso3166,
                        Bban.Value()));
            }

            NationalCheckDigits = nationalCheckDigits;
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <param name="countryResolver"></param>
        /// <param name="bban"></param>
        /// <param name="validators"></param>
        /// <param name="ibanSplitter"></param>
        /// <param name="bbanSplitter"></param>
        /// <exception cref="InvalidIbanException"></exception>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="InvalidBbanDetailException"></exception>
        public Iban(
            string iban,
            ICountryResolver countryResolver, IBban bban,
            IValidators validators, IIbanSplitter ibanSplitter, IBbanSplitter bbanSplitter)
            : this(bban)
        {
            CheckNotNullArgument<ICountryResolver>(countryResolver, "countryResolver");
            Debug.Assert(countryResolver != null, "countryResolver != null");

            CheckNotNullArgument<IValidators>(validators, "validators");
            Debug.Assert(validators != null, "validators != null");

            CheckNotNullArgument<IIbanSplitter>(ibanSplitter, "ibanSplitter");
            Debug.Assert(ibanSplitter != null, "ibanSplitter != null");

            CheckNotNullArgument<IBbanSplitter>(bbanSplitter, "bbanSplitter");
            Debug.Assert(bbanSplitter != null, "bbanSplitter != null");

            iban = Normalize(iban);
            var countryCode = ibanSplitter.GetCountryCode(iban);
            if (!validators.GetCountryCodeValidator().IsValid(countryCode))
            {
                throw new InvalidIbanException(
                    string.Format(
                        "The IBAN parameter '{0}' has an invalid country code '{1}'.",
                        iban,
                        countryCode));
            }

            Country = countryResolver.GetCountry(countryCode);
            if (Country == null)
            {
                throw new InvalidIbanException(
                    string.Format(
                        "The IBAN parameter '{0}' does not permits to calculate the country with the country code '{1}'.",
                        iban,
                        countryCode));
            }

            NationalCheckDigits = ibanSplitter.GetNationalCheckDigits(Country, iban);
            Bban = bban.SplitBban(Country, iban.Substring(4), validators, bbanSplitter);
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
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 2)
                {
                    value = "00";
                }

                _nationalCheckDigits = value;
            }
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
                "Country", Country == null ? null : ToStringField(Country.Iso3166),
                "NationalCheckDigits", ToStringField(NationalCheckDigits),
                "BBAN", Bban == null ? null : ToStringField(Bban.ToString()));
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
            if (Country == null || Bban == null)
            {
                return null;
            }

            return string.Concat(
                Country.Iso3166,
                NationalCheckDigits,
                Bban.Value());
        }

        /// <summary>
        ///     The method throws an <see cref="InvalidIbanException" /> if the Argument is null.
        /// </summary>
        /// <typeparam name="TType">
        ///     Type of the argument.
        /// </typeparam>
        /// <param name="argument">
        ///     Argument to check.
        /// </param>
        /// <param name="argumentName">
        ///     Name of the argument to check.
        /// </param>
        /// <exception cref="InvalidIbanException">
        ///     If the Argument is null, an Exception of type <see cref="InvalidIbanException" /> will be thrown.
        /// </exception>
        protected static void CheckNotNullArgument<TType>(object argument, string argumentName)
        {
            CheckNotNullArgument<TType, InvalidIbanException>(argument, argumentName);
        }

        # endregion
    }
}