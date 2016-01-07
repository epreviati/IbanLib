using IbanLib.Test.BbanTests;
using NUnit.Framework;

namespace IbanLib.Test
{
    public class DefaultBbanGeneratorTest : ABbanTest
    {
        [Test]
        public void Constructor_Splitter_Bban()
        {
            var generator = new DefaultBbanGenerator();
            var bbanObj = generator.NewBban(
                Country,
                GetBban(),
                ValidValidators,
                GetBbanSplitter());
            AssertBban(bbanObj);
        }
    }
}