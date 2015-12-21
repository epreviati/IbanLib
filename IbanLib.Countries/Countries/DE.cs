namespace IbanLib.Countries.Countries
{
    public class DE : ACountry
    {
        public override string Name
        {
            get { return "Germany"; }
        }

        public override string ISO3166
        {
            get { return "DE"; }
        }

        public override string BankIdentifierStructure
        {
            get { return "[0-9]{8}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{10}"; }
        }

        public override int BBANLength
        {
            get { return 18; }
        }

        public override int IBANLength
        {
            get { return 22; }
        }

        public override bool IsSEPA
        {
            get { return true; }
        }

        public override int BankIdentifierLength
        {
            get { return 8; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 12; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 10; }
        }
    }
}