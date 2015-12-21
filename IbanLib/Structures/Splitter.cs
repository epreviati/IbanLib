using IbanLib.Splitters;
using IbanLib.Splitters.Splitters;

namespace IbanLib.Structures
{
    public class Splitter : ISplitter
    {
        public IIbanSplitter GetIbanSplitter()
        {
            return new IbanSplitter();
        }

        public IBbanSplitter GetBbanSplitter()
        {
            return new BbanSplitter();
        }
    }
}