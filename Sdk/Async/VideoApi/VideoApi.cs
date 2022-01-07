using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace SymblAISharp.Async.VideoApi
{
    public interface IVideoApi
    {
        Task<VideoResponse> PostVideoUrl(
           VideoRequest videoRequest);
        Task<VideoResponse> PostVideo(byte[] bytes,
            VideoRequest videoRequest,
            string contentType = "video/mp4");
        Task<VideoResponse> PutVideoUrl(
            string conversationId,
            VideoRequest videoRequest);
        Task<VideoResponse> PutVideo(string conversationId,
            byte[] bytes,
            VideoRequest videoRequest,
            string contentType = "video/mp4");
    }

    /// <summary>
    /// The Async Video API allows you to process an audio file.
    // It can be utilized for any use case where you have access to
    // recorded audio and want to extract insights and other
    // conversational attributes supported by Symbl's Conversation API.
    /// </summary>
    public class VideoApi : IVideoApi
    {
        private readonly string token;
        private readonly string baseUrl;
        public VideoApi(string token,
            string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
            this.token = token;
        }

        private static Dictionary<string, string> GetVideoRequestParam(VideoRequest videoRequest)
        {
            var param = new Dictionary<string, string>()
            {
                { "name", videoRequest.name },
                { "enableAllTrackers", videoRequest.enableAllTrackers.ToString().ToLower() },
                { "detectEntities", videoRequest.detectEntities.ToString().ToLower() },
                { "detectPhrases", videoRequest.detectPhrases.ToString().ToLower() },
            };

            if (!string.IsNullOrEmpty(videoRequest.languageCode))
                param.Add("languageCode",
                    videoRequest.languageCode);

            if (videoRequest.customVocabulary.Count > 0)
                param.Add("customVocabulary",
                    JsonConvert.SerializeObject(videoRequest.customVocabulary));

            if (videoRequest.mode != null)
                param.Add("mode", videoRequest.mode);

            if (!string.IsNullOrEmpty(videoRequest.webhookUrl))
            {
                param.Add("webhookUrl", videoRequest.webhookUrl);
            }

            if (videoRequest.confidenceThreshold > 0)
            {
                param.Add("confidenceThreshold",
                    videoRequest.confidenceThreshold.ToString());
            }

            if (videoRequest.trackers.Count > 0)
            {
                param.Add("trackers",
                    JsonConvert.SerializeObject(
                        videoRequest.trackers.ToArray()));
            }

            return param;
        }

        /// <summary>
        /// Perform an Http Post with the ConversationId and VideoUrlRequest
        /// </summary>
        /// <param name="conversationId"></param>
        /// <param name="videoUrlRequest"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<VideoResponse> PostVideoUrl(
           VideoRequest videoRequest)
        {
            var url = $"{baseUrl}/v1/process/video/url";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(videoRequest)
                            .Replace("\"webhookUrl\":null,", "")
                            .Replace("\"languageCode\":null,", "")
                            .Replace("\"mode\":null,", "")
                            .Replace("\"name\":null,", "")
                            .Replace("\"diarizationSpeakerCount\":null,", "")
                            .Replace("\"confidenceThreshold\":0.0,", ""));
                }

                var httpResponse = await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (((HttpWebResponse)httpResponse).StatusCode == HttpStatusCode.Created)
                        return JsonConvert.DeserializeObject<VideoResponse>(
                            streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<VideoResponse> PostVideo(byte[] bytes,
            VideoRequest videoRequest,
            string contentType = "video/mp4")
        {
            var url = $"{baseUrl}/v1/process/video";

            Dictionary<string, string> param = GetVideoRequestParam(videoRequest);

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            var httpRequest = (HttpWebRequest)WebRequest.Create(newUrl);
            httpRequest.Method = "POST";

            httpRequest.Headers["Content-Type"] = contentType;
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            httpRequest.ContentLength = bytes.Length;
            Stream dataStream = httpRequest.GetRequestStream();
            dataStream.Write(bytes, 0, bytes.Length);
            dataStream.Close();

            try
            {
                using (WebResponse response = await httpRequest.GetResponseAsync())
                {
                    if (((HttpWebResponse)response).StatusCode == HttpStatusCode.Created)
                    {
                        using (dataStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseFromServer = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<VideoResponse>(responseFromServer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }

        /// <summary>
        /// Perform an Http Put with the ConversationId and VideoUrlRequest
        /// </summary>
        /// <param name="conversationId"></param>
        /// <param name="videoUrlRequest"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<VideoResponse> PutVideoUrl(
            string conversationId,
            VideoRequest videoRequest)
        {
            var url = $"{baseUrl}/v1/process/video/url/{conversationId}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(videoRequest)
                            .Replace("\"webhookUrl\":null,", "")
                            .Replace("\"languageCode\":null,", "")
                            .Replace("\"mode\":null,", "")
                            .Replace("\"name\":null,", "")
                            .Replace("\"diarizationSpeakerCount\":null,", "")
                            .Replace("\"confidenceThreshold\":0.0,", ""));
                }

                var httpResponse = await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (((HttpWebResponse)httpResponse).StatusCode == HttpStatusCode.Created)
                        return JsonConvert.DeserializeObject<VideoResponse>(
                            streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<VideoResponse> PutVideo(string conversationId,
            byte[] bytes,
            VideoRequest videoRequest,
            string contentType = "video/mp4")
        {
            var url = $"{baseUrl}/v1/process/video/{conversationId}";

            Dictionary<string, string> param = GetVideoRequestParam(videoRequest);

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            var httpRequest = (HttpWebRequest)WebRequest.Create(newUrl);
            httpRequest.Method = "PUT";

            httpRequest.ContentType = "x-www-form-urlencoded";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.Headers["Content-Type"] = contentType;

            httpRequest.ContentLength = bytes.Length;
            Stream dataStream = httpRequest.GetRequestStream();
            dataStream.Write(bytes, 0, bytes.Length);
            dataStream.Close();

            try
            {
                using (WebResponse response = await httpRequest.GetResponseAsync())
                {
                    if (((HttpWebResponse)response).StatusCode == HttpStatusCode.Created)
                    {
                        using (dataStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseFromServer = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<VideoResponse>(responseFromServer);
                        }
                    }
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
