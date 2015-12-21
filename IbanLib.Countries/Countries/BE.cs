namespace IbanLib.Countries.Countries
{
    public class BE : ACountry
    {
        public override string Name
        {
            get { return "Belgium"; }
        }

        public override string ISO3166
        {
            get { return "BE"; }
        }

        public override string BankIdentifierStructure
        {
            get { return "[0-9]{3}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{7}"; }
        }

        public override string BBANStructure
        {
            get { return string.Format("{0}{1}{2}", BankIdentifierStructure, AccountNumberStructure, "[0-9]{2}"); }
        }

        public override int BBANLength
        {
            get { return 12; }
        }

        public override int IBANLength
        {
            get { return 16; }
        }

        public override bool IsSEPA
        {
            get { return true; }
        }

        public override int BankIdentifierLength
        {
            get { return 3; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 7; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 9; }
        }

        public override int? Check3Position
        {
            get { return AccountNumberPosition + AccountNumberLength; }
        }

        public override int Check3Length
        {
            get { return 2; }
        }

        public override int AccountNumberLength
        {
            get { return 7; }
        }
    }
}