namespace IbanLib.Domain.Validators
{
    public interface ICountryCodeValidator
    {
        bool IsValid(string field);
    }
}