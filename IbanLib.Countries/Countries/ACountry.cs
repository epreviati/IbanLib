using System;

namespace IbanLib.Countries.Countries
{
    public abstract class ACountry : ICountry
    {
        public virtual string Name
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string ISO3166
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string BankIdentifierStructure
        {
            get { return null; }
        }

        public virtual string BranchIdentifierStructure
        {
            get { return null; }
        }

        public virtual string AccountNumberStructure
        {
            get { return null; }
        }

        public virtual string BBANStructure
        {
            get
            {
                return string.Format(
                    "{0}{1}{2}",
                    BankIdentifierStructure,
                    BranchIdentifierStructure,
                    AccountNumberStructure);
            }
        }

        public virtual int BBANLength
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string IBANStructure
        {
            get
            {
                return string.Format(
                    "{0}{1}{2}",
                    ISO3166,
                    "[0-9]{2}",
                    BBANStructure);
            }
        }

        public virtual int IBANLength
        {
            get { throw new NotImplementedException(); }
        }

        public virtual bool IsSEPA
        {
            get { return false; }
        }

        public virtual int BankIdentifierPosition
        {
            get { return 4; }
        }

        public virtual int BankIdentifierLength
        {
            get { throw new NotImplementedException(); }
        }

        public virtual int? DifferentBankIdentifierLengthForPayment
        {
            get { return null; }
        }

        public virtual int? BranchIdentifierPosition
        {
            get { return null; }
        }

        public virtual int BranchIdentifierLength
        {
            get { return 0; }
        }

        public virtual int IbanNationalIdLength
        {
            get { return BankIdentifierLength + BranchIdentifierLength; }
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
                "ISO3166", ISO3166,
                "BankIdentifierStructure", BankIdentifierStructure,
                "BranchIdentifierStructure", BranchIdentifierStructure,
                "AccountNumberStructure", AccountNumberStructure,
                "BBANStructure", BBANStructure,
                "BBANLength", BBANLength,
                "IBANStructure", IBANStructure,
                "IBANLength", IBANLength,
                "IsSEPA", IsSEPA,
                "BankIdentifierPosition", BankIdentifierPosition,
                "BankIdentifierLength", BankIdentifierLength,
                "DifferentBankIdentifierLengthForPayment", DifferentBankIdentifierLengthForPayment,
                "BranchIdentifierPosition", BranchIdentifierPosition,
                "BranchIdentifierLength", BranchIdentifierLength,
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
    }
}