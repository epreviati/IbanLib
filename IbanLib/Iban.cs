using System.Diagnostics;
using IbanLib.Common;
using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Exceptions;

namespace IbanLib
{
    /// <summary>
    ///     Iban class that permits to create an IBAN object.
    /// </summary>
    public class Iban : AClass, IIban
    {
        # region Constructors

        /// <summary>
        ///     Constructor of an empty IBAN oject.
        /// </summary>
        public Iban()
        {
        }

        /// <summary>
        ///     Private common constructor.
        /// </summary>
        /// <param name="bban">
        ///     BBAN object.
        /// </param>
        /// <exception cref="InvalidIbanDetailException">
        ///     If the BBAN is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        private Iban(IBban bban)
        {
            CheckNotNullArgument<IBban>(bban, "bban");
        }

        /// <summary>
        ///     Constructor that creates an IBAN starting from the Country and the BBAN and that calculate the National Check
        ///     Digits.
        /// </summary>
        /// <param name="country">
        ///     Country of the IBAN.
        /// </param>
        /// <param name="bban">
        ///     BBAN of the IBAN.
        /// </param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="InvalidIbanDetailException">
        ///     If the BBAN is null or if it is not possible to calculate the National Chekck Digits an
        ///     <see cref="InvalidIbanDetailException" /> will be thrown.
        /// </exception>
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
        ///     The methods try to split the string IBAN parameter to the corrispondent IBBAN object.
        /// </summary>
        /// <param name="iban">
        ///     The IBAN to split.
        /// </param>
        /// <param name="countryResolver">
        ///     Resolver that permits to find the Country.
        /// </param>
        /// <param name="bban">
        ///     BBAN object that will be filled with the informations found on the IBAN.
        /// </param>
        /// <param name="validators">
        ///     All the validators that are required to validate the informations.
        /// </param>
        /// <param name="ibanSplitter">
        ///     Rules to define how to split an IBAN.
        /// </param>
        /// <param name="bbanSplitter">
        ///     Rules to define how to split a BBAN.
        /// </param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="InvalidIbanException">
        ///     If any parametrs is invalid an <see cref="InvalidIbanException" /> will be thrown.
        /// </exception>
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
        ///     Country of the IBAN.
        /// </summary>
        public ICountry Country { get; set; }

        /// <summary>
        ///     National Check Digits of the IBAN.
        /// </summary>
        public string NationalCheckDigits
        {
            get { return _nationalCheckDigits; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 2)
                {
                    value = DefaultNationalCheckDigits;
                }

                if (value.Length == 1)
                {
                    value = string.Concat("0", value);
                }

                _nationalCheckDigits = value.ToUpperInvariant();
            }
        }

        private string _nationalCheckDigits = DefaultNationalCheckDigits;
        public const string DefaultNationalCheckDigits = "00";

        /// <summary>
        ///     BBAN of the IBAN.
        /// </summary>
        public IBban Bban { get; set; }

        # endregion

        # region Methods

        /// <summary>
        ///     Override of base ToString() method that returns the rappresentation of THIS class in a string.
        /// </summary>
        /// <returns>
        ///     The string that rappresent THIS class.
        /// </returns>
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
        ///     Return the rappresentation of the IBAN in a string.
        /// </summary>
        /// <returns>
        ///     The IBAN.
        /// </returns>
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