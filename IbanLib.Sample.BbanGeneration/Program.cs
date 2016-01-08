using IbanLib.Sample.BbanGeneration.Constructors;

namespace IbanLib.Sample.BbanGeneration
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Bban1("IbanLib.Sample.BbanGeneration -> BBAN 1");
            new Bban2("IbanLib.Sample.BbanGeneration -> BBAN 2");
            new Bban3("IbanLib.Sample.BbanGeneration -> BBAN 3");
        }
    }
}