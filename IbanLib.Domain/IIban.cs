using IbanLib.Countries;

namespace IbanLib.Domain
{
    /// <summary>
    ///     IIban interface that determines the structrue of the IBAN.
    /// </summary>
    public interface IIban
    {
        /// <summary>
        ///     Country of the IBAN.
        /// </summary>
        ICountry Country { get; set; }

        /// <summary>
        ///     National Check Digits of the IBAN.
        /// </summary>
        string NationalCheckDigits { get; set; }

        /// <summary>
        ///     BBAN of the IBAN.
        /// </summary>
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