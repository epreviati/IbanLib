namespace IbanLib.Countries.Countries
{
    public class MD : ACountry
    {
        public override string Name
        {
            get { return "Moldova"; }
        }

        public override string ISO3166
        {
            get { return "MD"; }
        }

        public override string BankIdentifierStructure
        {
            get { return "[0-9A-Z]{2}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{18}"; }
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
            get { return 2; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 6; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 18; }
        }
    }
}