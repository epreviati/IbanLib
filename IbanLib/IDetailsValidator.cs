using IbanLib.Validators;

namespace IbanLib
{
    public interface IDetailsValidator
    {
        ICountryCodeValidator GetCountryCodeValidator();

        IIbanValidator GetIbanValidator();

        IBankCodeValidator GetBankCodeValidator();

        IBranchCodeValidator GetBranchCodeValidator();

        IAccountNumberValidator GetAccountNumberValidator();
    }
}