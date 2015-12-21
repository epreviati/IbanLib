namespace IbanLib.Countries.Countries
{
    public class AL : ACountry
    {
        public override string Name
        {
            get { return "Albania"; }
        }

        public override string ISO3166
        {
            get { return "AL"; }
        }

        public override string BankIdentifierStructure
        {
            get { return "[0-9]{3}"; }
        }

        public override string BranchIdentifierStructure
        {
            get { return "[0-9]{4}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{16}"; }
        }

        public override string BBANStructure
        {
            get
            {
                return string.Format(
                    "{0}{1}{2}{3}",
                    BankIdentifierStructure,
                    BranchIdentifierStructure,
                    "[0-9]{1}",
                    AccountNumberStructure);
            }
        }

        public override int BBANLength
        {
            get { return 24; }
        }

        public override int IBANLength
        {
            get { return 28; }
        }

        public override int BankIdentifierLength
        {
            get { return 3; }
        }

        public override int? BranchIdentifierPosition
        {
            get { return 7; }
        }

        public override int BranchIdentifierLength
        {
            get { return 5; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 12; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 16; }
        }
    }
}