namespace IbanLib.Countries
{
    public interface ICountry
    {
        string Name { get; }

        string Iso3166 { get; }

        string BankCodeStructure { get; }

        int BankCodePosition { get; }

        int BankCodeLength { get; }

        int? BankCodeSecondaryLengthForPayment { get; }

        string BranchCodeStructure { get; }

        int? BranchCodePosition { get; }

        int BranchCodeLength { get; }

        string AccountNumberStructure { get; }

        int AccountNumberPosition { get; }

        int AccountNumberLength { get; }

        string BbanStructure { get; }

        int BbanLength { get; }

        string IbanStructure { get; }

        int IbanLength { get; }

        bool IsSepa { get; }

        int IbanNationalIdLength { get; }

        int SwiftAccountNumberPosition { get; }

        int SwiftAccountNumberLength { get; }

        int? Check1Position { get; }

        int Check1Length { get; }

        int? Check2Position { get; }

        int Check2Length { get; }

        int? Check3Position { get; }

        int Check3Length { get; }

        string CalculateNationalCheckDigits(string iban);

        string CalculateCheck1(string bankCode, string branchCode, string accountNumber);

        string CalculateCheck2(string bankCode, string branchCode, string accountNumber);

        string CalculateCheck3(string bankCode, string branchCode, string accountNumber);
    }
}