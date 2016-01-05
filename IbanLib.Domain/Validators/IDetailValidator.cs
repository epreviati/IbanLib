using IbanLib.Countries;

namespace IbanLib.Domain.Validators
{
    /// <summary>
    ///     Generic interface for all the validators that needs to validate a detail performing a check into a specific country.
    /// </summary>
    public interface IDetailValidator
    {
        /// <summary>
        ///     The method returns true or false if the FIELD is valid or not for the specified Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the FIELD.
        /// </param>
        /// <param name="field">
        ///     FIELD to validate.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        bool IsValid(ICountry country, string field);
    }
}