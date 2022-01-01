using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using SymblAISharp.TrackerApi;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SymblAISharp.Management
{
    public interface ITrackerApi 
    {
        Task<TrackerCreateResponse> CreateTrackers(List<TrackerRequest> trackerRequests);
        Task<TrackerResponse> UpdateTracker(string trackerId, 
            TrackerRequest trackerRequest);
        Task<TrackerDeleteResponse> DeleteTracker(string trackerId);
        Task<TrackerResponse> GetAllTrackers();
        Task<TrackerResponse> GetAllTrackersById(string trackerId);
        Task<TrackerByNameResponse> GetAllTrackersByName(string trackerName);
    }

    /// <summary>
    /// The Management API allows you to access and manage various 
    /// resources against your Symbl account.
    /// The resources created and managed by this API is maintained 
    /// at the account level.
    /// </summary>
    public class TrackerApi : ITrackerApi
    {
        private readonly string token;
        private readonly string baseUrl;
        public TrackerApi(string token,
            string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
            this.token = token;
        }

        public async Task<TrackerCreateResponse> CreateTrackers(List<TrackerRequest> trackerRequests)
        {
            var url = $"{baseUrl}/v1/manage/trackers";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            try
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(
                        JsonConvert.SerializeObject(trackerRequests));
                }

                var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var response = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<TrackerCreateResponse>(response);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<TrackerDeleteResponse> DeleteTracker(string trackerId)
        {
            var url = $"{baseUrl}/v1/manage/tracker/{trackerId}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "DELETE";

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            try
            {
                var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var response = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<TrackerDeleteResponse>(response);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<TrackerResponse> GetAllTrackers()
        {
            var url = $"{baseUrl}/v1/manage/trackers";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            try
            {
                var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var response = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<TrackerResponse>(response);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<TrackerResponse> GetAllTrackersById(string trackerId)
        {
            var url = $"{baseUrl}/v1/manage/tracker/{trackerId}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            try
            {
                var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var response = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<TrackerResponse>(response);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<TrackerByNameResponse> GetAllTrackersByName(string trackerName)
        {
            var url = $"{baseUrl}/v1/manage/trackers?name={trackerName}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            try
            {
                var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var response = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<TrackerByNameResponse>(response);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<TrackerResponse> UpdateTracker(string trackerId,
            TrackerRequest trackerRequest)
        {
            var url = $"{baseUrl}/v1/conversations/tracker/{trackerId}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            try
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(trackerRequest));
                }

                var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var response = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<TrackerResponse>(response);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return null;
        }
    }
}
