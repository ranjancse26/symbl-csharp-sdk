using System.IO;
using SymblAI.Test;
using System.Reflection;
using System.Threading.Tasks;
using SymblAISharp.Async.AudioApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Async.Test
{
    [TestClass]
    public class UnitTest_Audio : BaseTest
    {
        [TestMethod]
        public async Task TestMethod_AudioApi_WithUrl_POST_Success()
        {
            var response = GetAuthToken();
            IAudioApi audioApi = new AudioApi(response.accessToken);

            var audioResponse = await audioApi.PostAudioUrl(new AudioRequest
            {
                url = "https://symbltestdata.s3.us-east-2.amazonaws.com/sample_audio_file.wav",
            });

            Assert.IsTrue(audioResponse != null);
            Assert.IsTrue(audioResponse.conversationId != "");
            Assert.IsTrue(audioResponse.jobId != "");
        }

        [TestMethod]
        public async Task TestMethod_AudioApi_Bytes_POST_Success()
        {
            var response = GetAuthToken();
            IAudioApi audioApi = new AudioApi(response.accessToken);

            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string sampleAudioPath = string.Format("{0}\\Uploads\\{1}",
                exePath, "sample_audio_file.wav");

            var sampleFileBytes = File.ReadAllBytes(sampleAudioPath);

            var audioResponse = await audioApi.PostAudio(sampleFileBytes, new AudioRequest
            {
                name = "Test Audio"
            });

            Assert.IsTrue(audioResponse != null);
            Assert.IsTrue(audioResponse.conversationId != "");
            Assert.IsTrue(audioResponse.jobId != "");
        }
    }
}
