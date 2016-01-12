using System;
using Castle.Windsor;
using IbanLib.DependenciesResolver;
using IbanLib.Domain;

namespace IbanLib.Sample.IbanGeneration.Constructors
{
    public abstract class AIban
    {
        protected static IWindsorContainer Container = Bootstrapper.Boot();

        protected AIban(string title)
        {
            WriteLine(title, 0, 1);
        }

        protected static void PrintComparison(IIban iban, BankAccount bankAccount)
        {
            const string format = "{0} == {1} -> {2}";
            WriteLine("iban.ToString()");
            WriteLine(iban.ToString());

            WriteLine("IBAN", 1);
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.Value()),
                GetFieldValue(bankAccount.Iban()),
                iban.Value() == bankAccount.Iban()));

            WriteLine("BBAN");
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.Bban.Value()),
                GetFieldValue(bankAccount.Bban()),
                iban.Bban.Value() == bankAccount.Bban()));

            WriteLine("Country Code");
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.Country.Iso3166),
                GetFieldValue(bankAccount.CountryCode),
                iban.Country.Iso3166 == bankAccount.CountryCode));

            WriteLine("National Check Digits");
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.NationalCheckDigits),
                GetFieldValue(bankAccount.NationalCheckDigits),
                iban.NationalCheckDigits == bankAccount.NationalCheckDigits));

            WriteLine("Check Digits 1");
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.Bban.CheckDigits1),
                GetFieldValue(bankAccount.CheckDigits1),
                iban.Bban.CheckDigits1 == bankAccount.CheckDigits1));

            WriteLine("Bank Code");
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.Bban.BankCode),
                GetFieldValue(bankAccount.BankCode),
                iban.Bban.BankCode == bankAccount.BankCode));

            WriteLine("Branch Code");
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.Bban.BranchCode),
                GetFieldValue(bankAccount.BranchCode),
                iban.Bban.BranchCode == bankAccount.BranchCode));

            WriteLine("Check Digits 2");
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.Bban.CheckDigits2),
                GetFieldValue(bankAccount.CheckDigits2),
                iban.Bban.CheckDigits2 == bankAccount.CheckDigits2));

            WriteLine("Account Number");
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.Bban.AccountNumber),
                GetFieldValue(bankAccount.AccountNumber),
                iban.Bban.AccountNumber == bankAccount.AccountNumber));

            WriteLine("Check Digits 3");
            WriteLine(string.Format(
                format,
                GetFieldValue(iban.Bban.CheckDigits3),
                GetFieldValue(bankAccount.CheckDigits3),
                iban.Bban.CheckDigits3 == bankAccount.CheckDigits3));

            ReadLine();
            Console.Clear();
        }

        protected static void WriteLine(string msg, int spacesHead = 0, int spacesTail = 0)
        {
            NewLine(spacesHead);
            Console.WriteLine(GetFieldValue(msg));
            NewLine(spacesTail);
        }

        protected static void ReadLine(string msg = null, int spacesHead = 0, int spacesTail = 0)
        {
            NewLine(spacesHead);
            if (!string.IsNullOrWhiteSpace(msg))
            {
                Console.WriteLine(msg);
            }
            Console.ReadLine();
            NewLine(spacesTail);
        }

        protected static void NewLine(int newLines = 0)
        {
            while (newLines > 0)
            {
                Console.WriteLine();
                newLines--;
            }
        }

        private static string GetFieldValue(string str)
        {
            return string.IsNullOrWhiteSpace(str) ? "null" : str;
        }
    }
}