using IbanLib.Domain;
using IbanLib.Domain.Validators;
using IbanLib.Validators;

namespace IbanLib
{
    public class DefaultValidators : IValidators
    {
        private static readonly IAccountNumberValidator AccountNumberValidator = new AccountNumberValidator();
        private static readonly IBankCodeValidator BankCodeValidator = new BankCodeValidator();
        private static readonly IBbanValidator BbanValidator = new BbanValidator();
        private static readonly IBranchCodeValidator BranchCodeValidator = new BranchCodeValidator();
        private static readonly ICountryCodeValidator CountryCodeValidator = new CountryCodeValidator();
        private static readonly IIbanValidator IbanValidator = new IbanValidator();

        public IIbanValidator GetIbanValidator()
        {
            return IbanValidator;
        }

        public IBbanValidator GetBbanValidator()
        {
            return BbanValidator;
        }

        public ICountryCodeValidator GetCountryCodeValidator()
        {
            return CountryCodeValidator;
        }

        public IBankCodeValidator GetBankCodeValidator()
        {
            return BankCodeValidator;
        }

        public IBranchCodeValidator GetBranchCodeValidator()
        {
            return BranchCodeValidator;
        }

        public IAccountNumberValidator GetAccountNumberValidator()
        {
            return AccountNumberValidator;
        }
    }
}