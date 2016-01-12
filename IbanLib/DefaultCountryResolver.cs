using IbanLib.Countries;
using IbanLib.Domain;

namespace IbanLib
{
    /// <summary>
    ///     DefaultCountryResolver class.
    /// </summary>
    public class DefaultCountryResolver : ICountryResolver
    {
        /// <summary>
        ///     The method returns the corrispondent implementation of the interface ICountry or null searched bt the Country Code.
        /// </summary>
        /// <param name="countryCode">
        ///     The Country Code requested.
        /// </param>
        /// <returns>
        ///     The implementation of ICountry that corrisponds with the requested country code.
        /// </returns>
        public ICountry GetCountry(string countryCode)
        {
            return Getter.GetCountry(countryCode);
        }
    }
}