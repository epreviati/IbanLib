using IbanLib.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Exceptions;

namespace IbanLib
{
    /// <summary>
    ///     DefaultBbanGenerator class.
    /// </summary>
    public class DefaultBbanGenerator : IBbanGenerator
    {
        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <param name="validators"></param>
        /// <param name="splitter"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        /// <exception cref="InvalidBbanDetailException"></exception>
        public IBban NewBban(ICountry country, string bban, IValidators validators, IBbanSplitter splitter)
        {
            return new Bban(country, bban, validators, splitter);
        }
    }
}