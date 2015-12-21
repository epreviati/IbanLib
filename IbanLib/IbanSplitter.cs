using System;
using IbanLib.Countries;
using IbanLib.Exceptions;
using IbanLib.Validators;

namespace IbanLib
{
    public class IbanSplitter
    {
        private readonly ICountry _country;
        private readonly IIbanValidator _ibanValidator;

        public IbanSplitter(ICountry country, IIbanValidator ibanValidator)
        {
            if (country == null)
            {
                throw new InvalidCountryException(
                    string.Format(
                        "Parameter '{0}' of type '{1}' can not be null.",
                        "country",
                        "ICountry"));
            }

            _country = country;
            _ibanValidator = ibanValidator;
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        /// <exception cref="IbanSplitterException"></exception>
        public string GetCountryCodeFromIban(string iban)
        {
            ValidateIban(iban);

            try
            {
                return iban.Substring(0, 2);
            }
            catch (Exception e)
            {
                throw new IbanSplitterException(GetErrorMessage(iban, "Country Code"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        /// <exception cref="IbanSplitterException"></exception>
        public string GetNationalCheckDigitsFromIban(string iban)
        {
            ValidateIban(iban);

            try
            {
                return iban.Substring(2, 2);
            }
            catch (Exception e)
            {
                throw new IbanSplitterException(GetErrorMessage(iban, "National Check Digits"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        /// <exception cref="IbanSplitterException"></exception>
        public string GetBankIdentifierFromIban(string iban)
        {
            ValidateIban(iban);

            try
            {
                return iban.Substring(_country.BankIdentifierPosition, _country.BankIdentifierLength);
            }
            catch (Exception e)
            {
                throw new IbanSplitterException(GetErrorMessage(iban, "Bank Identifier"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        /// <exception cref="IbanSplitterException"></exception>
        public string GetBranchIdentifierFromIban(string iban)
        {
            ValidateIban(iban);

            try
            {
                return _country.BranchIdentifierPosition.HasValue
                    ? iban.Substring(_country.BranchIdentifierPosition.Value, _country.BranchIdentifierLength)
                    : null;
            }
            catch (Exception e)
            {
                throw new IbanSplitterException(GetErrorMessage(iban, "Branch Identifier"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        /// <exception cref="IbanSplitterException"></exception>
        public string GetAccountNumberFromIban(string iban)
        {
            ValidateIban(iban);

            try
            {
                return iban.Substring(_country.AccountNumberPosition, _country.AccountNumberLength);
            }
            catch (Exception e)
            {
                throw new IbanSplitterException(GetErrorMessage(iban, "Account Number"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <exception cref="IbanSplitterException"></exception>
        private void ValidateIban(string iban)
        {
            if (!_ibanValidator.IsValid(_country, iban))
            {
                throw new IbanSplitterException(
                    string.Format(
                        "Parameter IBAN '{0}' for country '{1}' is not valid.",
                        iban,
                        _country.ISO3166));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        private static string GetErrorMessage(string iban, string field)
        {
            return string.Format(
                "It is no possible to split the iban '{0}' to extract the '{1}'.",
                iban,
                field);
        }
    }
}