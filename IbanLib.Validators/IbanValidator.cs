using System.Numerics;
using IbanLib.Countries;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Validators
{
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
        /// </summary>
        /// <param name="country"></param>
        /// <param name="iban"></param>
        /// <returns>true or false</returns>
        /// <exception cref="InvalidCountryException"></exception>
        public override bool IsValid(ICountry country, string iban)
        {
            CheckCountry(country);

            return IsValidDetailLenght(iban, country.IBANLength)
                   && IsValidDetailStructure(iban, country.IBANStructure)
                   && IsValidStructure(iban);
        }

        /// <summary>
        /// </summary>
        /// <param name="iban"></param>
        /// <returns>true or false</returns>
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