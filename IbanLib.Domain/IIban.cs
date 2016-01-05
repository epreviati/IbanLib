using IbanLib.Countries;

namespace IbanLib.Domain
{
    /// <summary>
    /// </summary>
    public interface IIban
    {
        ICountry Country { get; set; }

        string NationalCheckDigits { get; set; }

        IBban Bban { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        string Value();
    }
}