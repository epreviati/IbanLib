using IbanLib.Countries;

namespace IbanLib.Domain
{
    public interface IIban
    {
        ICountry Country { get; set; }

        string NationalCheckDigits { get; set; }

        IBban Bban { get; set; }

        string Value();
    }
}