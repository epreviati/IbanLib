using IbanLib.Domain.Splitters;

namespace IbanLib.Domain
{
    public interface ISplitters
    {
        IIbanSplitter GetIbanSplitter();

        IBbanSplitter GetBbanSplitter();
    }
}