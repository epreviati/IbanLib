using System;
using System.Numerics;

namespace IbanLib.Countries.Countries
{
    public abstract class ACountry : ICountry
    {
        public virtual string Name
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string Iso3166
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string BankCodeStructure
        {
            get { return null; }
        }

        public virtual string BranchCodeStructure
        {
            get { return null; }
        }

        public virtual string AccountNumberStructure
        {
            get { return null; }
        }

        public virtual string BbanStructure
        {
            get
            {
                return string.Format(
                    "{0}{1}{2}",
                    BankCodeStructure,
                    BranchCodeStructure,
                    AccountNumberStructure);
            }
        }

        public virtual int BbanLength
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string IbanStructure
        {
            get
            {
                return string.Format(
                    "{0}{1}{2}",
                    Iso3166,
                    "[0-9]{2}",
                    BbanStructure);
            }
        }

        public virtual int IbanLength
        {
            get { throw new NotImplementedException(); }
        }

        public virtual bool IsSepa
        {
            get { return false; }
        }

        public virtual int BankCodePosition
        {
            get { return 4; }
        }

        public virtual int BankCodeLength
        {
            get { throw new NotImplementedException(); }
        }

        public virtual int? BankCodeSecondaryLengthForPayment
        {
            get { return null; }
        }

        public virtual int? BranchCodePosition
        {
            get { return null; }
        }

        public virtual int BranchCodeLength
        {
            get { return 0; }
        }

        public virtual int IbanNationalIdLength
        {
            get { return BankCodeLength + BranchCodeLength; }
        }

        public virtual int SwiftAccountNumberPosition
        {
            get { throw new NotImplementedException(); }
        }

        public virtual int SwiftAccountNumberLength
        {
            get { throw new NotImplementedException(); }
        }

        public virtual int AccountNumberPosition
        {
            get { return SwiftAccountNumberPosition; }
        }

        public virtual int AccountNumberLength
        {
            get { return SwiftAccountNumberLength; }
        }

        public virtual int? Check1Position
        {
            get { return null; }
        }

        public virtual int Check1Length
        {
            get { return 0; }
        }

        public virtual int? Check2Position
        {
            get { return null; }
        }

        public virtual int Check2Length
        {
            get { return 0; }
        }

        public virtual int? Check3Position
        {
            get { return null; }
        }

        public virtual int Check3Length
        {
            get { return 0; }
        }

        public override string ToString()
        {
            return string.Format(
                "{00}: {01}\n" +
                "{02}: {03}\n" +
                "{04}: {05}\n" +
                "{06}: {07}\n" +
                "{08}: {09}\n" +
                "{10}: {11}\n" +
                "{12}: {13}\n" +
                "{14}: {15}\n" +
                "{16}: {17}\n" +
                "{18}: {19}\n" +
                "{20}: {21}\n" +
                "{22}: {23}\n" +
                "{24}: {25}\n" +
                "{26}: {27}\n" +
                "{28}: {29}\n" +
                "{30}: {31}\n" +
                "{32}: {33}\n" +
                "{34}: {35}\n" +
                "{36}: {37}\n" +
                "{38}: {39}\n" +
                "{40}: {41}\n" +
                "{42}: {43}\n" +
                "{44}: {45}\n" +
                "{46}: {47}",
                "Name", Name,
                "ISO3166", Iso3166,
                "BankCodeStructure", BankCodeStructure,
                "BranchCodeStructure", BranchCodeStructure,
                "AccountNumberStructure", AccountNumberStructure,
                "BBANStructure", BbanStructure,
                "BBANLength", BbanLength,
                "IBANStructure", IbanStructure,
                "IBANLength", IbanLength,
                "IsSEPA", IsSepa,
                "BankCodePosition", BankCodePosition,
                "BankCodeLength", BankCodeLength,
                "BankCodeSecondaryLengthForPayment", BankCodeSecondaryLengthForPayment,
                "BranchCodePosition", BranchCodePosition,
                "BranchCodeLength", BranchCodeLength,
                "IbanNationalIdLength", IbanNationalIdLength,
                "SwiftAccountNumberPosition", SwiftAccountNumberPosition,
                "AccountNumberLength", AccountNumberLength,
                "Check1Position", Check1Position,
                "Check1Length", Check1Length,
                "Check2Position", Check2Position,
                "Check2Length", Check2Length,
                "Check3Position", Check3Position,
                "Check3Length", Check3Length);
        }

        # region Calculate Check Digits

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

        public virtual string CalculateNationalCheckDigits(string iban)
        {
            if (!IsValidInputToCalculateNationalCheckDigits(iban))
            {
                return null;
            }

            var truncated = iban.Substring(0, 4);
            var tmp = string.Concat(iban.Substring(4), truncated);

            for (var i = 0; i < From.Length; i++)
            {
                tmp = tmp.Replace(From[i], To[i]);
            }

            BigInteger n;
            BigInteger.TryParse(tmp, out n);

            return (98 - (n%97)).ToString("00");
        }

        protected bool IsValidInputToCalculateNationalCheckDigits(string iban)
        {
            return !string.IsNullOrWhiteSpace(iban)
                   && iban.Length == IbanLength
                   && iban.Substring(0, 2).Equals(Iso3166)
                   && iban.Substring(2, 2).Equals("00");
        }

        public virtual string CalculateCheck1(string bankCode, string branchCode, string accountNumber)
        {
            if (Check1Length == 0 || !Check1Position.HasValue)
                return null;

            throw new NotImplementedException();
        }

        public virtual string CalculateCheck2(string bankCode, string branchCode, string accountNumber)
        {
            if (Check2Length == 0 || !Check2Position.HasValue)
                return null;

            throw new NotImplementedException();
        }

        public virtual string CalculateCheck3(string bankCode, string branchCode, string accountNumber)
        {
            if (Check3Length == 0 || !Check3Position.HasValue)
                return null;

            throw new NotImplementedException();
        }

        protected bool IsValidInputToCalculateChekDigits(string bankCode, string branchCode, string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(bankCode)
                || string.IsNullOrWhiteSpace(accountNumber)
                || bankCode.Length != BankCodeLength
                || accountNumber.Length != AccountNumberLength
                || (string.IsNullOrWhiteSpace(branchCode) && BranchCodeLength != 0)
                || (!string.IsNullOrWhiteSpace(branchCode) && branchCode.Length != BranchCodeLength))
            {
                return false;
            }

            return true;
        }

        # endregion
    }
}