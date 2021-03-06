﻿using IbanLib.Countries;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Validators
{
    /// <summary>
    ///     BbanValidator class that permits to validate a BBAN.
    /// </summary>
    public class BbanValidator : ADetailValidator, IBbanValidator
    {
        /// <summary>
        ///     The method returns true or false if the BBAN is valid or not for the specified Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the BBAN.
        /// </param>
        /// <param name="bban">
        ///     BBAN to validate.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        public override bool IsValid(ICountry country, string bban)
        {
            CheckNotNullCountry(country);

            return IsValidDetailLenght(bban, country.BbanLength)
                   && IsValidDetailStructure(bban, country.BbanStructure);
        }
    }
}