namespace IbanLib.Countries.Countries
{
    public class AT : ACountry
    {
        public override string Name
        {
            get { return "Austria"; }
        }

        public override string ISO3166
        {
            get { return "AT"; }
        }

        public override string BankIdentifierStructure
        {
            get { return "[0-9]{5}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{11}"; }
        }

        public override int BBANLength
        {
            get { return 16; }
        }

        public override int IBANLength
        {
            get { return 20; }
        }

        public override bool IsSEPA
        {
            get { return true; }
        }

        public override int BankIdentifierLength
        {
            get { return 5; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 9; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 11; }
        }
    }
}