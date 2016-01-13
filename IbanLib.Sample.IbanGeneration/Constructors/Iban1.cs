using IbanLib.Countries;
using IbanLib.Countries.Countries;
using IbanLib.Domain;

namespace IbanLib.Sample.IbanGeneration.Constructors
{
    public class Iban1 : AIban
    {
        public Iban1(string title) : base(title)
        {
            ClassName = typeof(Iban1).Name;

            Iban1Ad();
            Iban1Ae();
            Iban1At();
            Iban1Az();
            Iban1Be();
            Iban1Bh();
            Iban1Gb();
        }

        private static void Iban1Gb()
        {
            WriteTitle("Iban1Gb");

            var bankAccount = new BankAccount
            {
                CountryCode = "GB",
                NationalCheckDigits = "80",
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var iban = GenerateIban(
                new GB(),
                "80",
                "NWBK",
                "50-00-00",
                "20504063");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban1Ad()
        {
            WriteTitle("Iban1Ad");

            var bankAccount = new BankAccount
            {
                CountryCode = "AD",
                NationalCheckDigits = "12",
                BankCode = "0001",
                BranchCode = "2030",
                AccountNumber = "200359100100"
            };

            var iban = GenerateIban(
                new AD(),
                "12",
                "0001",
                "2030",
                "200359100100");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban1Ae()
        {
            WriteTitle("Iban1Ae");

            var bankAccount = new BankAccount
            {
                CountryCode = "AE",
                NationalCheckDigits = "07",
                BankCode = "033",
                AccountNumber = "1234567890123456"
            };

            var iban = GenerateIban(
                new AE(),
                "07",
                "033",
                null,
                "1234567890123456");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban1At()
        {
            WriteTitle("Iban1At");

            var bankAccount = new BankAccount
            {
                CountryCode = "AT",
                NationalCheckDigits = "61",
                BankCode = "19043",
                AccountNumber = "00234573201"
            };

            var iban = GenerateIban(
                new AT(),
                "61",
                "19043",
                null,
                "00234573201");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban1Az()
        {
            WriteTitle("Iban1Az");

            var bankAccount = new BankAccount
            {
                CountryCode = "AZ",
                NationalCheckDigits = "21",
                BankCode = "NABZ",
                AccountNumber = "00000000137010001944"
            };

            var iban = GenerateIban(
                new AZ(),
                "21",
                "NABZ",
                null,
                "00000000137010001944");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban1Be()
        {
            WriteTitle("Iban1Be");

            var bankAccount = new BankAccount
            {
                CountryCode = "BE",
                NationalCheckDigits = "68",
                BankCode = "539",
                AccountNumber = "0075470",
                CheckDigits3 = "34"
            };

            var iban = GenerateIban(
                new BE(),
                "68",
                "539",
                null,
                "0075470",
                null,
                null,
                "34");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban1Bh()
        {
            WriteTitle("Iban1Bh");

            var bankAccount = new BankAccount
            {
                CountryCode = "BH",
                NationalCheckDigits = "67",
                BankCode = "BMAG",
                AccountNumber = "00001299123456"
            };

            var iban = GenerateIban(
                new BH(),
                "67",
                "BMAG",
                null,
                "00001299123456");

            PrintComparison(iban, bankAccount);
        }

        private static IIban GenerateIban(
            ICountry country, string nationalCheckDigits,
            string bankCode, string branchCode, string accountNumber,
            string check1 = null, string check2 = null, string check3 = null)
        {
            return new Iban
            {
                Country = country,
                NationalCheckDigits = nationalCheckDigits,
                Bban = new Bban
                {
                    CheckDigits1 = check1,
                    BankCode = bankCode,
                    BranchCode = branchCode,
                    CheckDigits2 = check2,
                    AccountNumber = accountNumber,
                    CheckDigits3 = check3
                }
            };
        }
    }
}