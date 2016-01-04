using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Splitters;

namespace IbanLib
{
    public class DefaultSplitters : ISplitters
    {
        private static readonly IIbanSplitter IbanSplitter = new IbanSplitter();
        private static readonly IBbanSplitter BbanSplitter = new BbanSplitter();

        public IIbanSplitter GetIbanSplitter()
        {
            return IbanSplitter;
        }

        public IBbanSplitter GetBbanSplitter()
        {
            return BbanSplitter;
        }
    }
}