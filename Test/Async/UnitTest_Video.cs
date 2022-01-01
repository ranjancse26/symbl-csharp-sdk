using System.IO;
using SymblAI.Test;
using System.Reflection;
using System.Threading.Tasks;
using SymblAISharp.Async.VideoApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Async.Test
{
    [TestClass]
    public class UnitTest_Video : BaseTest
    {
        [TestMethod]
        public async Task TestMethod_VideoApi_WithUrl_POST_Success()
        {
            var response = GetAuthToken();
            IVideoApi videoApi = new VideoApi(response.accessToken);

            var videoResponse = await videoApi.PostVideoUrl(new VideoRequest
            {
                url = "https://symbltestdata.s3.us-east-2.amazonaws.com/sample_video_file.mp4",
            });

            Assert.IsTrue(videoResponse != null);
            Assert.IsTrue(videoResponse.conversationId != "");
            Assert.IsTrue(videoResponse.jobId != "");
        }

        [TestMethod]
        public async Task TestMethod_VideoApi_Bytes_POST_Success()
        {
            var response = GetAuthToken();
            IVideoApi videoApi = new VideoApi(response.accessToken);

            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string sampleVideoPath = string.Format("{0}\\Uploads\\{1}",
                exePath, "sample_video_file.mp4");

            var sampleFileBytes = File.ReadAllBytes(sampleVideoPath);

            var videoResponse = await videoApi.PostVideo(sampleFileBytes,
                new VideoRequest
                {
                    name = "Test Video"
                });

            Assert.IsTrue(videoResponse != null);
            Assert.IsTrue(videoResponse.conversationId != "");
            Assert.IsTrue(videoResponse.jobId != "");
        }
    }
}
