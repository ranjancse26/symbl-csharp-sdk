using System;
using System.Threading.Tasks;
using SymblAISharp.Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Test.Management
{
    [TestClass]
    public class UnitTest_TrackerManagement : BaseTest
    {
        private readonly string trackerId = "5256880910761984";
        private readonly string trackerName = "Promotion Mention - a2779cfd-9539-43c8-a9c5-795282e0103d";

        [TestMethod]
        public async Task TestMethod_Get_TrackerCreate_Success()
        {
            var response = GetAuthToken();

            ITrackerApi trackerApi = new TrackerApi(response.accessToken);
            var trackerResponse = await trackerApi.CreateTrackers(new System.Collections.Generic.List<SymblAISharp.TrackerApi.TrackerRequest>()
            {
                new SymblAISharp.TrackerApi.TrackerRequest
                {
                    name = $"Promotion Mention - {Guid.NewGuid()}",
                    vocabulary = new System.Collections.Generic.List<string>
                    {
                        "We have a special promotion going on if you " +
                        "book this before"
                    }
                }
            });

            Assert.IsTrue(trackerResponse != null);
        }

        [TestMethod]
        public async Task TestMethod_Get_TrackerById_Success()
        {
            var response = GetAuthToken();

            ITrackerApi trackerApi = new TrackerApi(response.accessToken);
            var trackerResponse = await trackerApi.GetAllTrackersById(trackerId);

            Assert.IsTrue(trackerResponse != null);
        }

        [TestMethod]
        public async Task TestMethod_Get_TrackerByName_Success()
        {
            var response = GetAuthToken();

            ITrackerApi trackerApi = new TrackerApi(response.accessToken);
            var trackerResponse = await trackerApi.GetAllTrackersByName(trackerName);

            Assert.IsTrue(trackerResponse != null);
        }

        [TestMethod]
        public async Task TestMethod_Get_TrackerDelete_Success()
        {
            var response = GetAuthToken();

            ITrackerApi trackerApi = new TrackerApi(response.accessToken);
            var trackerResponse = await trackerApi.DeleteTracker(trackerId);

            Assert.IsTrue(trackerResponse != null);
        }
    }
}
