namespace IbanLib.Countries.Countries
{
    public class ES : ACountry
    {
        public override string Name
        {
            get { return "Spain"; }
        }

        public override string ISO3166
        {
            get { return "ES"; }
        }

        public override string BankIdentifierStructure
        {
            get { return "[0-9]{4}"; }
        }

        public override string BranchIdentifierStructure
        {
            get { return "[0-9]{4}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{10}"; }
        }

        public override string BBANStructure
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", BankIdentifierStructure, BranchIdentifierStructure,
                    "[0-9]{1}[0-9]{1}", AccountNumberStructure);
            }
        }

        public override int BBANLength
        {
            get { return 20; }
        }

        public override int IBANLength
        {
            get { return 24; }
        }

        public override bool IsSEPA
        {
            get { return true; }
        }

        public override int BankIdentifierLength
        {
            get { return 4; }
        }

        public override int? BranchIdentifierPosition
        {
            get { return 8; }
        }

        public override int BranchIdentifierLength
        {
            get { return 4; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 12; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 12; }
        }

        public override int AccountNumberLength
        {
            get { return 10; }
        }

        public override int Check2Length
        {
            get { return 2; }
        }

        public override int? Check2Position
        {
            get { return SwiftAccountNumberPosition; }
        }

        public override int AccountNumberPosition
        {
            get { return SwiftAccountNumberPosition + Check2Length; }
        }
    }
}