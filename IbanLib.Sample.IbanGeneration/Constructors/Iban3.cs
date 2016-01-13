using IbanLib.Domain;
using IbanLib.Domain.Splitters;

namespace IbanLib.Sample.IbanGeneration.Constructors
{
    public class Iban3 : AIban
    {
        public Iban3(string title) : base(title)
        {
            ClassName = typeof (Iban3).Name;

            Iban3Ad();
            Iban3Ae();
            Iban3At();
            Iban3Az();
            Iban3Be();
            Iban3Bh();
            Iban3Gb();
        }

        private static void Iban3Gb()
        {
            WriteTitle("Iban3Gb()");

            var bankAccount = new BankAccount
            {
                CountryCode = "GB",
                NationalCheckDigits = "80",
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var iban = GenerateIban("GB80NWBK50000020504063");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban3Ad()
        {
            WriteTitle("Iban3Ad()");

            var bankAccount = new BankAccount
            {
                CountryCode = "AD",
                NationalCheckDigits = "12",
                BankCode = "0001",
                BranchCode = "2030",
                AccountNumber = "200359100100"
            };

            var iban = GenerateIban("AD1200012030200359100100");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban3Ae()
        {
            WriteTitle("Iban3Ae()");

            var bankAccount = new BankAccount
            {
                CountryCode = "AE",
                NationalCheckDigits = "07",
                BankCode = "033",
                AccountNumber = "1234567890123456"
            };

            var iban = GenerateIban("AE070331234567890123456");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban3At()
        {
            WriteTitle("Iban3At()");

            var bankAccount = new BankAccount
            {
                CountryCode = "AT",
                NationalCheckDigits = "61",
                BankCode = "19043",
                AccountNumber = "00234573201"
            };

            var iban = GenerateIban("AT611904300234573201");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban3Az()
        {
            WriteTitle("Iban3Az()");

            var bankAccount = new BankAccount
            {
                CountryCode = "AZ",
                NationalCheckDigits = "21",
                BankCode = "NABZ",
                AccountNumber = "00000000137010001944"
            };

            var iban = GenerateIban("AZ21NABZ00000000137010001944");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban3Be()
        {
            WriteTitle("Iban3Be()");

            var bankAccount = new BankAccount
            {
                CountryCode = "BE",
                NationalCheckDigits = "68",
                BankCode = "539",
                AccountNumber = "0075470",
                CheckDigits3 = "34"
            };

            var iban = GenerateIban("BE68539007547034");

            PrintComparison(iban, bankAccount);
        }

        private static void Iban3Bh()
        {
            WriteTitle("Iban3Ae()");

            var bankAccount = new BankAccount
            {
                CountryCode = "BH",
                NationalCheckDigits = "67",
                BankCode = "BMAG",
                AccountNumber = "00001299123456"
            };

            var iban = GenerateIban("BH67BMAG00001299123456");

            PrintComparison(iban, bankAccount);
        }

        private static IIban GenerateIban(string iban)
        {
            return new Iban(iban,
                Container.Resolve<ICountryResolver>(),
                Container.Resolve<IBban>(),
                Container.Resolve<IValidators>(),
                Container.Resolve<IIbanSplitter>(),
                Container.Resolve<IBbanSplitter>());
        }
    }
}