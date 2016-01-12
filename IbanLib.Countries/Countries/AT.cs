namespace IbanLib.Countries.Countries
{
    public class AT : ACountry
    {
        public override string Name
        {
            get { return "Austria"; }
        }

        public override string Iso3166
        {
            get { return "AT"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{5}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{11}"; }
        }

        public override int BbanLength
        {
            get { return 16; }
        }

        public override int IbanLength
        {
            get { return 20; }
        }

        public override bool IsSepa
        {
            get { return true; }
        }

        public override int BankCodeLength
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