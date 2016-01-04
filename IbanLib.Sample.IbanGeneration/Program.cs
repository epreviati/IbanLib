using IbanLib.DependenciesResolver;
using IbanLib.Sample.IbanGeneration.Constructors;

namespace IbanLib.Sample.IbanGeneration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Iban1("IbanLib.Sample.IbanGeneration -> IBAN 1");
            new Iban2("IbanLib.Sample.IbanGeneration -> IBAN 2");
            new Iban3("IbanLib.Sample.IbanGeneration -> IBAN 3");
        }
    }
}