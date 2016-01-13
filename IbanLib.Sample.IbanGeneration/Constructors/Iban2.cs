using IbanLib.Countries;
using IbanLib.Countries.Countries;
using IbanLib.Domain;

namespace IbanLib.Sample.IbanGeneration.Constructors
{
    public class Iban2 : AIban
    {
        public Iban2(string title) : base(title)
        {
            ClassName = typeof (Iban2).Name;

            Iban2Ad();
            Iban2Ae();
            Iban2At();
            Iban2Az();
            Iban2Be();
            Iban2Bh();
            Iban2Gb();
        }

        private static void Iban2Gb()
        {
            WriteTitle("Iban2Gb()");

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
                "NWBK",
                "500000",
                "20504063");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban2Ad()
        {
            WriteTitle("Iban2Ad");

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
                "0001",
                "2030",
                "200359100100");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban2Ae()
        {
            WriteTitle("Iban2Ae");

            var bankAccount = new BankAccount
            {
                CountryCode = "AE",
                NationalCheckDigits = "07",
                BankCode = "033",
                AccountNumber = "1234567890123456"
            };

            var iban = GenerateIban(
                new AE(),
                "033",
                null,
                "1234567890123456");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban2At()
        {
            WriteTitle("Iban2At");

            var bankAccount = new BankAccount
            {
                CountryCode = "AT",
                NationalCheckDigits = "61",
                BankCode = "19043",
                AccountNumber = "00234573201"
            };

            var iban = GenerateIban(
                new AT(),
                "19043",
                null,
                "00234573201");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban2Az()
        {
            WriteTitle("Iban2Az");

            var bankAccount = new BankAccount
            {
                CountryCode = "AZ",
                NationalCheckDigits = "21",
                BankCode = "NABZ",
                AccountNumber = "00000000137010001944"
            };

            var iban = GenerateIban(
                new AZ(),
                "NABZ",
                null,
                "00000000137010001944");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban2Be()
        {
            WriteTitle("Iban2Be");

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
                "539",
                null,
                "0075470",
                null,
                null,
                "34");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban2Bh()
        {
            WriteTitle("Iban2Bh");

            var bankAccount = new BankAccount
            {
                CountryCode = "BH",
                NationalCheckDigits = "67",
                BankCode = "BMAG",
                AccountNumber = "00001299123456"
            };

            var iban = GenerateIban(
                new BH(),
                "BMAG",
                null,
                "00001299123456");

            PrintComparison(iban, bankAccount);
        }

        private static IIban GenerateIban(
            ICountry country,
            string bankCode, string branchCode, string accountNumber,
            string check1 = null, string check2 = null, string check3 = null)
        {
            var bban = new Bban
            {
                CheckDigits1 = check1,
                BankCode = bankCode,
                BranchCode = branchCode,
                CheckDigits2 = check2,
                AccountNumber = accountNumber,
                CheckDigits3 = check3
            };
            return new Iban(country, bban);
        }
    }
}