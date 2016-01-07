using IbanLib.Countries;

namespace IbanLib.Domain
{
    /// <summary>
    /// </summary>
    public interface ICountryResolver
    {
        /// <summary>
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        ICountry GetCountry(string countryCode);
    }
}