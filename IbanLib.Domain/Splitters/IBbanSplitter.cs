using IbanLib.Countries;

namespace IbanLib.Domain.Splitters
{
    public interface IBbanSplitter
    {
        string GetCheck1(ICountry country, string bban);

        string GetBankCode(ICountry country, string bban);

        string GetBranchCode(ICountry country, string bban);

        string GetCheck2(ICountry country, string bban);

        string GetAccountNumber(ICountry country, string bban);

        string GetCheck3(ICountry country, string bban);
    }
}