using IbanLib.Countries;

namespace IbanLib.Domain.Splitters
{
    /// <summary>
    ///     IBbanSplitter interface that defines the actions to split a BBAN.
    /// </summary>
    public interface IBbanSplitter
    {
        /// <summary>
        ///     The method gets Country and a BBAN and extracts the Check1.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information about the BBAN.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Check1.
        /// </param>
        /// <returns>
        ///     The Check1.
        /// </returns>
        string GetCheck1(ICountry country, string bban);

        /// <summary>
        ///     The method gets Country and a BBAN and extracts the Bank Code.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information about the BBAN.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Bank Code.
        /// </param>
        /// <returns>
        ///     The Bank Code.
        /// </returns>
        string GetBankCode(ICountry country, string bban);

        /// <summary>
        ///     The method gets Country and a BBAN and extracts the Branch Code.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information about the BBAN.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Branch Code.
        /// </param>
        /// <returns>
        ///     The Branch Code.
        /// </returns>
        string GetBranchCode(ICountry country, string bban);

        /// <summary>
        ///     The method gets Country and a BBAN and extracts the Check2.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information about the BBAN.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Check1.
        /// </param>
        /// <returns>
        ///     The Check2.
        /// </returns>
        string GetCheck2(ICountry country, string bban);

        /// <summary>
        ///     The method gets Country and a BBAN and extracts the Account Number.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information about the BBAN.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Account Number.
        /// </param>
        /// <returns>
        ///     The Account Number.
        /// </returns>
        string GetAccountNumber(ICountry country, string bban);

        /// <summary>
        ///     The method gets Country and a BBAN and extracts the Check3.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information about the BBAN.
        /// </param>
        /// <param name="bban">
        ///     BBAN to extract the Check3.
        /// </param>
        /// <returns>
        ///     The Check3.
        /// </returns>
        string GetCheck3(ICountry country, string bban);
    }
}