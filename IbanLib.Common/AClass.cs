using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib.Common
{
    public abstract class AClass
    {
        /// <summary>
        ///     The method throws an <see cref="InvalidCountryException" /> if the country is null.
        /// </summary>
        /// <param name="country">
        ///     Country to check.
        /// </param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        protected static void CheckCountry(ICountry country)
        {
            if (country == null)
            {
                throw new InvalidCountryException(
                    string.Format(
                        "Parameter '{0}' of type '{1}' can not be null.",
                        "country",
                        "ICountry"));
            }
        }
    }
}