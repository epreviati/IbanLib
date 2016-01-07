using IbanLib.Countries;

namespace IbanLib.Domain
{
    /// <summary>
    ///     IIban interface that determines the structrue of the IBAN.
    /// </summary>
    public interface IIban
    {
        ICountry Country { get; set; }

        string NationalCheckDigits { get; set; }

        IBban Bban { get; set; }

        /// <summary>
        ///     Return the rappresentation of the IBAN in a string.
        /// </summary>
        /// <returns>
        ///     The IBAN.
        /// </returns>
        string Value();
    }
}