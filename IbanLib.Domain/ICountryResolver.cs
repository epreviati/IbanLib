using IbanLib.Countries;

namespace IbanLib.Domain
{
    /// <summary>
    ///     ICountryResolver interface that defines the method to resolve a Country from the Code.
    /// </summary>
    public interface ICountryResolver
    {
        /// <summary>
        ///     The methods try to resolve from the Country Code the corrispondent ICountry object.
        /// </summary>
        /// <param name="countryCode">
        ///     Country Code to resolve.
        /// </param>
        /// <returns>
        ///     The ICountry object found.
        /// </returns>
        ICountry GetCountry(string countryCode);
    }
}