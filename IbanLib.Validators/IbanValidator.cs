using System.Numerics;
using IbanLib.Countries;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Validators
{
    /// <summary>
    ///     IbanValidator class that permits to validate an IBAN.
    /// </summary>
    public class IbanValidator : ADetailValidator, IIbanValidator
    {
        private static readonly string[] From =
        {
            "A", "B", "C", "D", "E", "F",
            "G", "H", "I", "J", "K", "L",
            "M", "N", "O", "P", "Q", "R",
            "S", "T", "U", "V", "W", "X",
            "Y", "Z"
        };

        private static readonly string[] To =
        {
            "10", "11", "12", "13", "14", "15",
            "16", "17", "18", "19", "20", "21",
            "22", "23", "24", "25", "26", "27",
            "28", "29", "30", "31", "32", "33",
            "34", "35"
        };

        /// <summary>
        ///     The method returns true or false if the IBAN is valid or not.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the IBAN.
        /// </param>
        /// <param name="iban">
        ///     IBAN to validate.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        public override bool IsValid(ICountry country, string iban)
        {
            CheckCountry(country);

            return IsValidDetailLenght(iban, country.IbanLength)
                   && IsValidDetailStructure(iban, country.IbanStructure)
                   && IsValidStructure(iban);
        }

        /// <summary>
        ///     The method returns true or false if the structure of the IBAN is valid or not following those four steps:
        ///     1. Move the four initial characters to the end of the string;
        ///     2. Replace each letter in the string with two digits, thereby expanding the string, where A = 10, ..., Z = 35;
        ///     3. Interpret the string as a decimal integer and compute the remainder of that number on division by 97;
        ///     4. If the remainder is 1, the check digit test is passed and the IBAN might be valid.
        /// </summary>
        /// <param name="iban">
        ///     Iban to validate.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        public static bool IsValidStructure(string iban)
        {
            var truncated = iban.Substring(0, 4);
            var tmp = string.Concat(iban.Substring(4), truncated);

            for (var i = 0; i < From.Length; i++)
            {
                tmp = tmp.Replace(From[i], To[i]);
            }

            BigInteger n;
            BigInteger.TryParse(tmp, out n);

            return (n%97) == 1;
        }
    }
}