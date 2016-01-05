using System;
using IbanLib.Countries;
using IbanLib.Domain.Splitters;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Splitters
{
    public class BbanSplitter : ASplitter, IBbanSplitter
    {
        private const string Bban = "BBAN";
        private const int CharsRemovedFromIban = 4;
        private readonly IBbanValidator _bbanValidator;

        public BbanSplitter(IBbanValidator bbanValidator)
        {
            _bbanValidator = bbanValidator;
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <returns></returns>
        public string GetCheck1(ICountry country, string bban)
        {
            ValidateCountry(country);
            ValidateBban(country, bban);

            try
            {
                return country.Check1Position.HasValue
                    ? bban.Substring(
                        country.Check1Position.Value - CharsRemovedFromIban,
                        country.Check1Length)
                    : null;
            }
            catch (Exception e)
            {
                throw new BbanSplitterException(GetErrorMessage(Bban, bban, "Check 1"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <returns></returns>
        /// <exception cref="BbanSplitterException"></exception>
        public string GetBankCode(ICountry country, string bban)
        {
            ValidateCountry(country);
            ValidateBban(country, bban);

            try
            {
                return bban.Substring(
                    country.BankIdentifierPosition - CharsRemovedFromIban,
                    country.BankIdentifierLength);
            }
            catch (Exception e)
            {
                throw new BbanSplitterException(GetErrorMessage(Bban, bban, "Bank Identifier"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <returns></returns>
        /// <exception cref="BbanSplitterException"></exception>
        public string GetBranchCode(ICountry country, string bban)
        {
            ValidateCountry(country);
            ValidateBban(country, bban);

            try
            {
                return country.BranchIdentifierPosition.HasValue
                    ? bban.Substring(
                        country.BranchIdentifierPosition.Value - CharsRemovedFromIban,
                        country.BranchIdentifierLength)
                    : null;
            }
            catch (Exception e)
            {
                throw new BbanSplitterException(GetErrorMessage(Bban, bban, "Branch Identifier"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <returns></returns>
        public string GetCheck2(ICountry country, string bban)
        {
            ValidateCountry(country);
            ValidateBban(country, bban);

            try
            {
                return country.Check2Position.HasValue
                    ? bban.Substring(
                        country.Check2Position.Value - CharsRemovedFromIban,
                        country.Check2Length)
                    : null;
            }
            catch (Exception e)
            {
                throw new BbanSplitterException(GetErrorMessage(Bban, bban, "Check 2"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <returns></returns>
        /// <exception cref="BbanSplitterException"></exception>
        public string GetAccountNumber(ICountry country, string bban)
        {
            ValidateCountry(country);
            ValidateBban(country, bban);

            try
            {
                return bban.Substring(
                    country.AccountNumberPosition - CharsRemovedFromIban,
                    country.AccountNumberLength);
            }
            catch (Exception e)
            {
                throw new BbanSplitterException(GetErrorMessage(Bban, bban, "Account Number"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <returns></returns>
        public string GetCheck3(ICountry country, string bban)
        {
            ValidateCountry(country);
            ValidateBban(country, bban);

            try
            {
                return country.Check3Position.HasValue
                    ? bban.Substring(
                        country.Check3Position.Value - CharsRemovedFromIban,
                        country.Check3Length)
                    : null;
            }
            catch (Exception e)
            {
                throw new BbanSplitterException(GetErrorMessage(Bban, bban, "Check 3"), e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <exception cref="IbanSplitterException"></exception>
        private void ValidateBban(ICountry country, string bban)
        {
            if (!_bbanValidator.IsValid(country, bban))
            {
                throw new BbanSplitterException(
                    string.Format(
                        "Parameter BBAN '{0}' for country '{1}' is not valid.",
                        bban,
                        country.ISO3166));
            }
        }
    }
}