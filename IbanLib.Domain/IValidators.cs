using IbanLib.Domain.Validators;

namespace IbanLib.Domain
{
    public interface IValidators
    {
        IIbanValidator GetIbanValidator();

        IBbanValidator GetBbanValidator();

        ICountryCodeValidator GetCountryCodeValidator();

        IBankCodeValidator GetBankCodeValidator();

        IBranchCodeValidator GetBranchCodeValidator();

        IAccountNumberValidator GetAccountNumberValidator();
    }
}