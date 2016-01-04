using IbanLib.Countries;

namespace IbanLib.Domain.Splitters
{
    public interface IIbanSplitter
    {
        string GetCountryCode(string iban);

        string GetNationalCheckDigits(ICountry country, string iban);

        string GetBban(ICountry country, string iban);
    }
}