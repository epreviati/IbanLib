using System;
using IbanLib.Countries;
using IbanLib.Domain.Splitters;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Splitters
{
    /// <summary>
    ///     BbanSplitter class that permits to split a BBAN.
    /// </summary>
    public class BbanSplitter : ASplitter, IBbanSplitter
    {
        private const string Bban = "BBAN";
        private const int CharsRemovedFromIban = 4; // IBAN.Lenght - BBAN.Lenght = 4 Chars
        private readonly IBbanValidator _bbanValidator;

        /// <summary>
        ///     Constructor of the class.
        /// </summary>
        /// <param name="bbanValidator">
        ///     An implementation of the interface <see cref="IBbanValidator" />.
        /// </param>
        public BbanSplitter(IBbanValidator bbanValidator)
        {
            _bbanValidator = bbanValidator;
        }

        /// <summary>
        ///     The method gets a BBAN in input and returns an eventually Check1 how it is defined into the Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the BBAN and to extract the Check1.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Check1.
        /// </param>
        /// <returns>
        ///     The Check1 or null.
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be throwed.
        /// </exception>
        /// <exception cref="BbanSplitterException">
        ///     If the BBAN is not valid for the Country or if it is no possible to extract the Check1 from the BBAN, a
        ///     <see cref="BbanSplitterException" /> will be throwed.
        /// </exception>
        public string GetCheck1(ICountry country, string bban)
        {
            CheckCountry(country);
            CheckBban(country, bban);

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
        ///     The method gets a BBAN in input and returns the Bank Code how it is defined into the Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the BBAN and to extract the Bank Code.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Bank Code.
        /// </param>
        /// <returns>
        ///     The Bank Code.
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be throwed.
        /// </exception>
        /// <exception cref="BbanSplitterException">
        ///     If the BBAN is not valid for the Country or if it is no possible to extract the Bank Code from the BBAN, a
        ///     <see cref="BbanSplitterException" /> will be throwed.
        /// </exception>
        public string GetBankCode(ICountry country, string bban)
        {
            CheckCountry(country);
            CheckBban(country, bban);

            try
            {
                return bban.Substring(
                    country.BankCodePosition - CharsRemovedFromIban,
                    country.BankCodeLength);
            }
            catch (Exception e)
            {
                throw new BbanSplitterException(GetErrorMessage(Bban, bban, "Bank Identifier"), e);
            }
        }

        /// <summary>
        ///     The method gets a BBAN in input and returns an eventually Branch Code how it is defined into the Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the BBAN and to extract the Branch Code.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Branch Code.
        /// </param>
        /// <returns>
        ///     The Branch Code or null.
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be throwed.
        /// </exception>
        /// <exception cref="BbanSplitterException">
        ///     If the BBAN is not valid for the Country or if it is no possible to extract the Branch Code from the BBAN, a
        ///     <see cref="BbanSplitterException" /> will be throwed.
        /// </exception>
        public string GetBranchCode(ICountry country, string bban)
        {
            CheckCountry(country);
            CheckBban(country, bban);

            try
            {
                return country.BranchCodePosition.HasValue
                    ? bban.Substring(
                        country.BranchCodePosition.Value - CharsRemovedFromIban,
                        country.BranchCodeLength)
                    : null;
            }
            catch (Exception e)
            {
                throw new BbanSplitterException(GetErrorMessage(Bban, bban, "Branch Identifier"), e);
            }
        }

        /// <summary>
        ///     The method gets a BBAN in input and returns an eventually Check2 how it is defined into the Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the BBAN and to extract the Check2.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Check2.
        /// </param>
        /// <returns>
        ///     The Check2 or null.
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be throwed.
        /// </exception>
        /// <exception cref="BbanSplitterException">
        ///     If the BBAN is not valid for the Country or if it is no possible to extract the Check2 from the BBAN, a
        ///     <see cref="BbanSplitterException" /> will be throwed.
        /// </exception>
        public string GetCheck2(ICountry country, string bban)
        {
            CheckCountry(country);
            CheckBban(country, bban);

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
        ///     The method gets a BBAN in input and returns the Account Numbers how it is defined into the Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the BBAN and to extract the Account Number.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Account Number.
        /// </param>
        /// <returns>
        ///     The Account Number.
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be throwed.
        /// </exception>
        /// <exception cref="BbanSplitterException">
        ///     If the BBAN is not valid for the Country or if it is no possible to extract the Account Number from the BBAN, a
        ///     <see cref="BbanSplitterException" /> will be throwed.
        /// </exception>
        public string GetAccountNumber(ICountry country, string bban)
        {
            CheckCountry(country);
            CheckBban(country, bban);

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
        ///     The method gets a BBAN in input and returns an eventually Check3 how it is defined into the Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the BBAN and to extract the Check3.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Check3.
        /// </param>
        /// <returns>
        ///     The Check3 or null.
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be throwed.
        /// </exception>
        /// <exception cref="BbanSplitterException">
        ///     If the BBAN is not valid for the Country or if it is no possible to extract the Check3 from the BBAN, a
        ///     <see cref="BbanSplitterException" /> will be throwed.
        /// </exception>
        public string GetCheck3(ICountry country, string bban)
        {
            CheckCountry(country);
            CheckBban(country, bban);

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
        ///     The method throws a <see cref="BbanSplitterException" /> if the BBAN is not valid for the Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the BBAN.
        /// </param>
        /// <param name="bban">
        ///     BBAN to check.
        /// </param>
        /// <exception cref="BbanSplitterException">
        ///     If the BBAN is not valid for the Country, a <see cref="BbanSplitterException" /> will be throwed.
        /// </exception>
        private void CheckBban(ICountry country, string bban)
        {
            if (!_bbanValidator.IsValid(country, bban))
            {
                throw new BbanSplitterException(
                    string.Format(
                        "Parameter BBAN '{0}' for country '{1}' is not valid.",
                        bban,
                        country.Iso3166));
            }
        }
    }
}