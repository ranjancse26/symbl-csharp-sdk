using SymblAI.Test;
using System.Threading.Tasks;
using SymblAISharp.Conversation.Experience;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Async.Test
{
    [TestClass]
    public class UnitTest_Experience : BaseTest
    {
        private readonly string conversationId = "5185464127455232";

        [TestMethod]
        public async Task TestMethod_Get_TextExperience_Success()
        {
            var response = GetAuthToken();
     
            IExperienceApi experienceApi = new ExperienceApi(response.accessToken);
            var textExperienceResponse = await experienceApi.GetTextExperience(conversationId, new TextExperienceRequest
            {
                name = "verbose-text-summary"
            });

            Assert.IsTrue(textExperienceResponse != null);
        }

        [TestMethod]
        public async Task TestMethod_Get_VideoExperience_Success()
        {
            var response = GetAuthToken();

            IExperienceApi experienceApi = new ExperienceApi(response.accessToken);
            var videoExperienceResponse = await experienceApi.GetVideoExperience(conversationId, 
                new VideoExperienceRequest
            {
                name = "video-summary",
                videoUrl = "https://storage.googleapis.com/rammer-transcription-bucket/small.mp4"
            });

            Assert.IsTrue(videoExperienceResponse != null);
        }

        [TestMethod]
        public async Task TestMethod_Get_TrackerAnalyticsExperience_Success()
        {
            var response = GetAuthToken();

            IExperienceApi experienceApi = new ExperienceApi(response.accessToken);
            var trackerAnalyticsExperienceResponse = await experienceApi.GetTrackerAnalyticsExperience(conversationId, 
                new TrackerAnalyticsExperienceRequest
            {
                name = "audio-summary",
                audioUrl = "https://symbltestdata.s3.us-east-2.amazonaws.com/sample_audio_file.wav"
            });

            Assert.IsTrue(trackerAnalyticsExperienceResponse != null);
        }
    }
}
