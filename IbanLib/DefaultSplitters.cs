using IbanLib.Domain;
using IbanLib.Domain.Splitters;

namespace IbanLib
{
    public class DefaultSplitters : ISplitters
    {
        private readonly IBbanSplitter _bbanSplitter;
        private readonly IIbanSplitter _ibanSplitter;

        public DefaultSplitters(IIbanSplitter ibanSplitter, IBbanSplitter bbanSplitter)
        {
            _ibanSplitter = ibanSplitter;
            _bbanSplitter = bbanSplitter;
        }

        public IIbanSplitter GetIbanSplitter()
        {
            return _ibanSplitter;
        }

        public IBbanSplitter GetBbanSplitter()
        {
            return _bbanSplitter;
        }
    }
}