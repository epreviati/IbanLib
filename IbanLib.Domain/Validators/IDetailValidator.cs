using IbanLib.Countries;

namespace IbanLib.Domain.Validators
{
    public interface IDetailValidator
    {
        bool IsValid(ICountry country, string field);
    }
}