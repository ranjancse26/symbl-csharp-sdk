using SymblAI.Test;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SymblAISharp.Async.JobApi;

namespace SymblAI.Async.Test
{
    [TestClass]
    public class UnitTest_Job : BaseTest
    {
        [TestMethod]
        public async Task TestMethod_JobApi_Get_Success()
        {
            string jobId = "5b01cf88-3608-48bc-b441-9589a6b8a745";
            var response = GetAuthToken();
            IJobApi jobApi = new JobApi(response.accessToken);

            var jobResponse = await jobApi.GetJobResponse(jobId);
            Assert.IsTrue(jobResponse != null);
            Assert.IsTrue(jobResponse.id != "");
            Assert.IsTrue(jobResponse.status != "");
        }
    }
}
