using System;
using IbanLib.Countries;
using IbanLib.Domain.Splitters;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Splitters
{
    /// <summary>
    ///     IbanSplitter class that permits to split an IBAN.
    /// </summary>
    public class IbanSplitter : ASplitter, IIbanSplitter
    {
        private const string Iban = "IBAN";
        private readonly IIbanValidator _ibanValidator;

        /// <summary>
        ///     Constructor of the class.
        /// </summary>
        /// <param name="ibanValidator">
        ///     An implementation of the interface <see cref="IIbanValidator" />.
        /// </param>
        public IbanSplitter(IIbanValidator ibanValidator)
        {
            _ibanValidator = ibanValidator;
        }

        /// <summary>
        ///     The method gets an IBAN in input and returns its first two chars that corrispond to the Country Code in ISO3166.
        /// </summary>
        /// <param name="iban">
        ///     IBAN to extract the Country Code.
        /// </param>
        /// <returns>
        ///     The extracted Country Code.
        /// </returns>
        /// <exception cref="IbanSplitterException">
        ///     If the iban it is no possible to extract the Country Code from the IBAN, an <see cref="IbanSplitterException" />
        ///     will be thrown.
        /// </exception>
        public string GetCountryCode(string iban)
        {
            try
            {
                return iban.Substring(0, 2).ToUpperInvariant();
            }
            catch (Exception e)
            {
                throw new IbanSplitterException(GetErrorMessage(Iban, iban, "Country Code"), e);
            }
        }

        /// <summary>
        ///     The method gets an IBAN in input and returns its seconds two chars that corrispond to the National Check Digits.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the IBAN.
        /// </param>
        /// <param name="iban">
        ///     IBAN to extract the National Check Digits.
        /// </param>
        /// <returns>
        ///     The extracted National Check Digits.
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="IbanSplitterException">
        ///     If the IBAN is not valid for the Country or if it is no possible to extract the National Check Digits from the
        ///     IBAN,
        ///     an <see cref="IbanSplitterException" /> will be thrown.
        /// </exception>
        public string GetNationalCheckDigits(ICountry country, string iban)
        {
            CheckCountry(country);
            CheckIban(country, iban);

            try
            {
                return iban.Substring(2, 2).ToUpperInvariant();
            }
            catch (Exception e)
            {
                throw new IbanSplitterException(GetErrorMessage(Iban, iban, "National Check Digits"), e);
            }
        }

        /// <summary>
        ///     The method gets an IBAN in input and returns all the chars except the first four chars.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the IBAN.
        /// </param>
        /// <param name="iban">
        ///     IBAN to extract the BBAN.
        /// </param>
        /// <returns>
        ///     The extracted BBAN.
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="IbanSplitterException">
        ///     If the IBAN is not valid for the Country or if it is no possible to extract the BBAN from the IBAN, an
        ///     <see cref="IbanSplitterException" /> will be thrown.
        /// </exception>
        public string GetBban(ICountry country, string iban)
        {
            CheckCountry(country);
            CheckIban(country, iban);

            try
            {
                return iban.Substring(4).ToUpperInvariant();
            }
            catch (Exception e)
            {
                throw new IbanSplitterException(GetErrorMessage(Iban, iban, "BBAN"), e);
            }
        }

        /// <summary>
        ///     The method throws an <see cref="IbanSplitterException" /> if the IBAN is not valid for the Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to check the IBAN.
        /// </param>
        /// <param name="iban">
        ///     IBAN to check.
        /// </param>
        /// <exception cref="IbanSplitterException">
        ///     If the IBAN is not valid for the Country, an <see cref="IbanSplitterException" /> will be thrown.
        /// </exception>
        private void CheckIban(ICountry country, string iban)
        {
            if (!_ibanValidator.IsValid(country, iban))
            {
                throw new IbanSplitterException(
                    string.Format(
                        "Parameter IBAN '{0}' for country '{1}' is not valid.",
                        iban,
                        country.Iso3166));
            }
        }
    }
}