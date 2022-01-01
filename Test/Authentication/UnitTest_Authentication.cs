using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Test.Authentication
{
    [TestClass]
    public class UnitTest_Authentication : BaseTest
    {
        [TestMethod]
        public void TestMethod_Auth_Success()
        {
            var response = GetAuthToken();

            Assert.IsTrue(response != null);
            Assert.IsTrue(response.accessToken != "");
            Assert.IsTrue(response.expiresIn > 0);
        }
    }
}
