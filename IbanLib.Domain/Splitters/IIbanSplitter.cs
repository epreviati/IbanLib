using IbanLib.Countries;

namespace IbanLib.Domain.Splitters
{
    /// <summary>
    ///     IIbanSplitter interface that defines the actions to split an IBAN.
    /// </summary>
    public interface IIbanSplitter
    {
        /// <summary>
        ///     The method extracts the Country Code from an inputted IBAN.
        /// </summary>
        /// <param name="iban">
        ///     IBAN to extract the Country Code.
        /// </param>
        /// <returns>
        ///     The Country Code.
        /// </returns>
        string GetCountryCode(string iban);

        /// <summary>
        ///     The method gets Country and a IBAN and extracts the National Check Digits.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information about the IBAN.
        /// </param>
        /// <param name="iban">
        ///     IBAN to extract the National Check Digits.
        /// </param>
        /// <returns>
        ///     The National Check Digits.
        /// </returns>
        string GetNationalCheckDigits(ICountry country, string iban);

        /// <summary>
        ///     The method gets Country and a IBAN and extracts the Check1.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information about the IBAN.
        /// </param>
        /// <param name="iban">
        ///     IBAN to extract the BBAN.
        /// </param>
        /// <returns>
        ///     The BBAN.
        /// </returns>
        string GetBban(ICountry country, string iban);
    }
}