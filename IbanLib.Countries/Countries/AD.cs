namespace IbanLib.Countries.Countries
{
    public class AD : ACountry
    {
        public override string Name
        {
            get { return "Andorra"; }
        }

        public override string ISO3166
        {
            get { return "AD"; }
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
            get { return "[0-9A-Z]{12}"; }
        }

        public override int BBANLength
        {
            get { return 20; }
        }

        public override int IBANLength
        {
            get { return 24; }
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
    }
}