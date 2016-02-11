using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppliedTestware.Libre.Test.Unit
{
    using AppliedTestware;

    [TestClass]
    public class LibreTests
    {
        [TestMethod]
        public void TestStdOutSync()
        {
            for (int i = 0; i < 10; ++i)
            {
                Libre.LogToConsole("Hello console! {0}", i);
            }

            Thread.Sleep(2000);
        }

        [TestMethod]
        public void TestStdOutAsync()
        {
        }
    }
}
