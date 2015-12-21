using IbanLib.Countries;

namespace IbanLib.Validators
{
    public interface IDetailValidator
    {
        bool IsValid(ICountry country, string field);
    }
}