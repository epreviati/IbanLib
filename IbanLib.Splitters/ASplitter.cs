using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib.Splitters
{
    /// <summary>
    ///     ASplitter base class that defines the basically funcionalities for all the splitter classes.
    /// </summary>
    public abstract class ASplitter
    {
        /// <summary>
        ///     The method throws an <see cref="InvalidCountryException" /> if the country is null.
        /// </summary>
        /// <param name="country">
        ///     Country to check.
        /// </param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be throwed.
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

        /// <summary>
        ///     Method that returns a generic error message personalized with the three fields.
        /// </summary>
        /// <param name="fieldName">
        ///     Parameter Field Name.
        /// </param>
        /// <param name="fieldToSplit">
        ///     Parameter Field To split.
        /// </param>
        /// <param name="fieldToExtract">
        ///     Parameter Field To Extract.
        /// </param>
        /// <returns>
        ///     The error message created using the passed parameters.
        /// </returns>
        protected static string GetErrorMessage(string fieldName, string fieldToSplit, string fieldToExtract)
        {
            return string.Format(
                "It is not possible to split the {0} '{1}' to extract the '{2}'.",
                fieldName,
                fieldToSplit,
                fieldToExtract);
        }
    }
}