using SymblAI.Test;
using System.Threading.Tasks;
using SymblAISharp.Async.JobApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Async.Test
{
    [TestClass]
    public class UnitTest_Job : BaseTest
    {
        [TestMethod]
        public async Task TestMethod_JobApi_Get_Success()
        {
            string jobId = "0124c042-cc20-4f02-85ab-f8b0e3434827";
            var response = GetAuthToken();
            IJobApi jobApi = new JobApi(response.accessToken);

            var jobResponse = await jobApi.GetJobResponse(jobId);
            Assert.IsTrue(jobResponse != null);
            Assert.IsTrue(jobResponse.id != "");
            Assert.IsTrue(jobResponse.status != "");
        }
    }
}
