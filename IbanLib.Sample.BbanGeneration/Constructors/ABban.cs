using System;
using IbanLib.Domain;

namespace IbanLib.Sample.BbanGeneration.Constructors
{
    public abstract class AIban
    {
        protected static void PrintComparison(IBban bban, BankAccountDetails bankAccountDetails)
        {
            const string format = "{0} == {1} -> {2}";
            WriteLine("ToString()");
            WriteLine(bban.ToString());

            WriteLine("BBAN", 1);
            WriteLine(string.Format(
                format,
                GetFieldValue(bban.Value()),
                GetFieldValue(bankAccountDetails.Bban()),
                bban.Value() == bankAccountDetails.Bban()));

            WriteLine("Check Digits 1");
            WriteLine(string.Format(
                format,
                GetFieldValue(bban.CheckDigits1),
                GetFieldValue(bankAccountDetails.CheckDigits1),
                bban.CheckDigits1 == bankAccountDetails.CheckDigits1));

            WriteLine("Bank Code");
            WriteLine(string.Format(
                format,
                GetFieldValue(bban.BankCode),
                GetFieldValue(bankAccountDetails.BankCode),
                bban.BankCode == bankAccountDetails.BankCode));

            WriteLine("Branch Code");
            WriteLine(string.Format(
                format,
                GetFieldValue(bban.BranchCode),
                GetFieldValue(bankAccountDetails.BranchCode),
                bban.BranchCode == bankAccountDetails.BranchCode));

            WriteLine("Check Digits 2");
            WriteLine(string.Format(
                format,
                GetFieldValue(bban.CheckDigits2),
                GetFieldValue(bankAccountDetails.CheckDigits2),
                bban.CheckDigits2 == bankAccountDetails.CheckDigits2));

            WriteLine("Account Number");
            WriteLine(string.Format(
                format,
                GetFieldValue(bban.AccountNumber),
                GetFieldValue(bankAccountDetails.AccountNumber),
                bban.AccountNumber == bankAccountDetails.AccountNumber));

            WriteLine("Check Digits 3");
            WriteLine(string.Format(
                format,
                GetFieldValue(bban.CheckDigits3),
                GetFieldValue(bankAccountDetails.CheckDigits3),
                bban.CheckDigits3 == bankAccountDetails.CheckDigits3));

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