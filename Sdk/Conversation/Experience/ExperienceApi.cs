using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SymblAISharp.Conversation.Experience
{
    public interface IExperienceApi
    {
        Task<TextExperienceResponse> GetTextExperience(
            string conversationId,
            TextExperienceRequest textExperienceRequest);
        Task<VideoExperienceResponse> GetVideoExperience(
            string conversationId,
            VideoExperienceRequest videoExperienceRequest);
        Task<AudioExperienceResponse> GetAudioExperience(
            string conversationId,
            AudioExperienceRequest audioExperienceRequest);
    }

    /// <summary>
    /// Returns the Experience UI by the Conversation Id
    /// </summary>
    public class ExperienceApi : IExperienceApi
    {
        private readonly string token;
        private readonly string baseUrl;
        public ExperienceApi(string token,
            string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
            this.token = token;
        }

        public async Task<TextExperienceResponse> GetTextExperience(
            string conversationId,
            TextExperienceRequest textExperienceRequest)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/experiences";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(textExperienceRequest));
                }

                var httpResponse = await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (((HttpWebResponse)httpResponse).StatusCode == HttpStatusCode.OK)
                        return JsonConvert.DeserializeObject<TextExperienceResponse>(
                            streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<VideoExperienceResponse> GetVideoExperience(
            string conversationId,
            VideoExperienceRequest videoExperienceRequest)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/experiences";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(videoExperienceRequest));
                }

                var httpResponse = await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (((HttpWebResponse)httpResponse).StatusCode == HttpStatusCode.OK)
                        return JsonConvert.DeserializeObject<VideoExperienceResponse>(
                            streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<AudioExperienceResponse> GetAudioExperience(
            string conversationId,
            AudioExperienceRequest trackerAnalyticsExperienceRequest)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/experiences";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(trackerAnalyticsExperienceRequest));
                }

                var httpResponse = await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (((HttpWebResponse)httpResponse).StatusCode == HttpStatusCode.OK)
                        return JsonConvert.DeserializeObject<AudioExperienceResponse>(
                            streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }
    }
}
