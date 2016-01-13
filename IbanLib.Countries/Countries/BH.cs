namespace IbanLib.Countries.Countries
{
    public class BH : ACountry
    {
        public override string Name
        {
            get { return "Bahrain"; }
        }

        public override string Iso3166
        {
            get { return "BH"; }
        }

        public override string BankCodeStructure
        {
            get { return "[A-Z]{4}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{14}"; }
        }

        public override int BbanLength
        {
            get { return 18; }
        }

        public override int IbanLength
        {
            get { return 22; }
        }

        public override int BankCodeLength
        {
            get { return 4; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 8; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 14; }
        }
    }
}