using IbanLib.Domain;
using IbanLib.Domain.Splitters;

namespace IbanLib
{
    /// <summary>
    /// </summary>
    public class DefaultSplitters : ISplitters
    {
        private readonly IBbanSplitter _bbanSplitter;
        private readonly IIbanSplitter _ibanSplitter;

        /// <summary>
        /// </summary>
        /// <param name="ibanSplitter"></param>
        /// <param name="bbanSplitter"></param>
        public DefaultSplitters(IIbanSplitter ibanSplitter, IBbanSplitter bbanSplitter)
        {
            _ibanSplitter = ibanSplitter;
            _bbanSplitter = bbanSplitter;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IIbanSplitter GetIbanSplitter()
        {
            return _ibanSplitter;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IBbanSplitter GetBbanSplitter()
        {
            return _bbanSplitter;
        }
    }
}