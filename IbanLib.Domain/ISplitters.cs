using IbanLib.Domain.Splitters;

namespace IbanLib.Domain
{
    /// <summary>
    /// </summary>
    public interface ISplitters
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        IIbanSplitter GetIbanSplitter();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IBbanSplitter GetBbanSplitter();
    }
}