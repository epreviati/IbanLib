using IbanLib.Countries;
using IbanLib.Domain.Splitters;

namespace IbanLib.Domain
{
    /// <summary>
    ///     IBban interface that determines the structrue of the BBAN.
    /// </summary>
    public interface IBban
    {
        /// <summary>
        ///     Check Digits 1 of the BBAN.
        /// </summary>
        string CheckDigits1 { get; set; }

        /// <summary>
        ///     Bank Code of the BBAN.
        /// </summary>
        string BankCode { get; set; }

        /// <summary>
        ///     Branch Code of the BBAN.
        /// </summary>
        string BranchCode { get; set; }

        /// <summary>
        ///     Check Digits 2 of the BBAN.
        /// </summary>
        string CheckDigits2 { get; set; }

        /// <summary>
        ///     Account Number of the BBAN.
        /// </summary>
        string AccountNumber { get; set; }

        /// <summary>
        ///     Check Digits 3 of the BBAN.
        /// </summary>
        string CheckDigits3 { get; set; }

        /// <summary>
        ///     Return the rappresentation of the BBAN in a string.
        /// </summary>
        /// <returns>
        ///     The BBAN.
        /// </returns>
        string Value();

        /// <summary>
        ///     The methods try to split the string BBAN paramente to the corrispondent IBBAN object.
        /// </summary>
        /// <param name="country">
        ///     Country of the BBAN.
        /// </param>
        /// <param name="bban">
        ///     Rappresenation in string of the BBAN.
        /// </param>
        /// <param name="validators">
        ///     Aggregation of all validators required.
        /// </param>
        /// <param name="bbanSplitter">
        ///     Splitter object that permits to split the BBAN string in the IBBAN object.
        /// </param>
        /// <returns>
        ///     The IBBAN splitted object.
        /// </returns>
        IBban SplitBban(ICountry country, string bban, IValidators validators, IBbanSplitter bbanSplitter);
    }
}