namespace IbanLib
{
    public interface IBban
    {
        string CheckDigits1 { get; set; }

        string BankCode { get; set; }

        string BranchCode { get; set; }

        string CheckDigits2 { get; set; }

        string AccountNumber { get; set; }

        string CheckDigits3 { get; set; }

        string Value();
    }
}