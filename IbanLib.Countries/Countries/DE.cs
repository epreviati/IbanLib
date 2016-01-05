namespace IbanLib.Countries.Countries
{
    public class DE : ACountry
    {
        public override string Name
        {
            get { return "Germany"; }
        }

        public override string Iso3166
        {
            get { return "DE"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{8}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{10}"; }
        }

        public override int BbanLength
        {
            get { return 18; }
        }

        public override int IbanLength
        {
            get { return 22; }
        }

        public override bool IsSepa
        {
            get { return true; }
        }

        public override int BankCodeLength
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