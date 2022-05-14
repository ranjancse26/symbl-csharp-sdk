using System.IO;
using SymblAI.Test;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using SymblAISharp.Async.AudioApi;
using System.Threading;
using System.Diagnostics;
using SymblAISharp.JobApi;
using SymblAISharp.Async.JobApi;
using SymblAISharp.Conversation;
using SymblAISharp.Async.Tracker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Async.Test
{
    [TestClass]
    public class UnitTest_Audio : BaseTest
    {
        [TestMethod]
        public async Task TestMethod_AudioApi_WithUrl_With_Trackers_Global_POST_Success()
        {
            // Please make sure to create the tracker via API or from the Platform Portal
            // https://docs.symbl.ai/docs/management-api/trackers/create-tracker
            //  "vocabulary": [
            //    "Get agenda",
            //    "Pull up the gender",
            //    "See agenda or view agenda"
            // ]

            var response = GetAuthToken();
            IAudioApi audioApi = new AudioApi(response.accessToken);

            var audioResponse = await audioApi.PostAudioUrl(new AudioRequest
            {
                enableAllTrackers = true,
                url = "https://audio.jukehost.co.uk/bPOVCMXvJoo7n7CC6BqzuYy6gBALOjBj",
            });

            Assert.IsTrue(audioResponse != null);
            Assert.IsTrue(audioResponse.conversationId != "");
            Assert.IsTrue(audioResponse.jobId != "");

            IJobApi jobApi = new JobApi(response.accessToken);
            JobResponse jobResponse;

            do
            {
                Thread.Sleep(2000);
                jobResponse = await jobApi.GetJobResponse(audioResponse.jobId);
                Debug.WriteLine($"Please wait for the Job to complete." +
                    $" Job Status: {jobResponse.status}");
            }
            while (jobResponse.status != "completed");

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var trackerDetectedResponse = conversationApi.GetTrackerDetectedResponse(audioResponse.conversationId);

            Assert.IsTrue(trackerDetectedResponse.Count > 0);
        }

        [TestMethod]
        public async Task TestMethod_AudioApi_WithUrl_With_Trackers_Inline_POST_Success()
        {
            var response = GetAuthToken();
            IAudioApi audioApi = new AudioApi(response.accessToken);

            var audioResponse = await audioApi.PostAudioUrl(new AudioRequest
            {
                trackers = new List<Tracker>
                {
                    new Tracker
                    {
                        name = "Test Tracker",
                        vocabulary = new List<string>
                        {
                            "get agenda",
                            "pull up the gender"
                        }
                    }
                },
                enableAllTrackers = true,
                url = "https://audio.jukehost.co.uk/bPOVCMXvJoo7n7CC6BqzuYy6gBALOjBj",
            });

            Assert.IsTrue(audioResponse != null);
            Assert.IsTrue(audioResponse.conversationId != "");
            Assert.IsTrue(audioResponse.jobId != "");

            IJobApi jobApi = new JobApi(response.accessToken);
            JobResponse jobResponse;

            do
            {
                Thread.Sleep(2000);
                jobResponse = await jobApi.GetJobResponse(audioResponse.jobId);
                Debug.WriteLine($"Please wait for the Job to complete." +
                    $" Job Status: {jobResponse.status}");
            }
            while (jobResponse.status != "completed");

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var trackerDetectedResponse = conversationApi.GetTrackerDetectedResponse(audioResponse.conversationId);

            Assert.IsTrue(trackerDetectedResponse.Count > 0);
        }


        [TestMethod]
        public async Task TestMethod_AudioApi_WithUrl_With_Trackers_POST_Success()
        {
            var response = GetAuthToken();
            IAudioApi audioApi = new AudioApi(response.accessToken);

            var audioResponse = await audioApi.PostAudioUrl(new AudioRequest
            {
                trackers = new List<Tracker>
                {
                    new Tracker
                    {
                        name = "Demo Tracker",
                        vocabulary = new List<string>
                        {
                            "single self-contained unit",
                            "no dying or waxing or gassing"
                        }
                    }
                },
                enableAllTrackers = true,
                url = "https://symbltestdata.s3.us-east-2.amazonaws.com/sample_audio_file.wav",
            });

            Assert.IsTrue(audioResponse != null);
            Assert.IsTrue(audioResponse.conversationId != "");
            Assert.IsTrue(audioResponse.jobId != "");
        }

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
