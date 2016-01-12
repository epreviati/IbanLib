namespace IbanLib.Countries.Countries
{
    public class AL : ACountry
    {
        public override string Name
        {
            get { return "Albania"; }
        }

        public override string Iso3166
        {
            get { return "AL"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{3}"; }
        }

        public override string BranchCodeStructure
        {
            get { return "[0-9]{4}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{16}"; }
        }

        public override string BbanStructure
        {
            get
            {
                return string.Format(
                    "{0}{1}{2}{3}",
                    BankCodeStructure,
                    BranchCodeStructure,
                    "[0-9]{1}",
                    AccountNumberStructure);
            }
        }

        public override int BbanLength
        {
            get { return 24; }
        }

        public override int IbanLength
        {
            get { return 28; }
        }

        public override int BankCodeLength
        {
            get { return 3; }
        }

        public override int? BranchCodePosition
        {
            get { return 7; }
        }

        public override int BranchCodeLength
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