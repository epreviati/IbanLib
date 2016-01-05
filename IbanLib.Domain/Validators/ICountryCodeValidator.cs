namespace IbanLib.Domain.Validators
{
    /// <summary>
    ///     ICountryCodeValidator interface that define the actions to validate a Country Code.
    /// </summary>
    public interface ICountryCodeValidator
    {
        /// <summary>
        ///     The method returns true or false if the Country Code is valid or not.
        /// </summary>
        /// <param name="countryCode">
        ///     Country Code to validate.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        bool IsValid(string countryCode);
    }
}