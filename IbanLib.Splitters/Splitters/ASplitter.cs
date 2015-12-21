using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib.Splitters.Splitters
{
    public abstract class ASplitter
    {
        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <exception cref="IbanSplitterException"></exception>
        protected static void ValidateCountry(ICountry country)
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
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldToSplit"></param>
        /// <param name="fieldToExtract"></param>
        /// <returns></returns>
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