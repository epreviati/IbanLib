using IbanLib.Splitters;

namespace IbanLib
{
    public interface ISplitter
    {
        IIbanSplitter GetIbanSplitter();

        IBbanSplitter GetBbanSplitter();
    }
}