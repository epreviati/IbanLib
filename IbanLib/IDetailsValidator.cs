using IbanLib.Validators;

namespace IbanLib
{
    public interface IDetailsValidator
    {
        IIbanValidator GetIbanValidator();

        IBbanValidator GetBbanValidator();

        ICountryCodeValidator GetCountryCodeValidator();

        IBankCodeValidator GetBankCodeValidator();

        IBranchCodeValidator GetBranchCodeValidator();

        IAccountNumberValidator GetAccountNumberValidator();
    }
}