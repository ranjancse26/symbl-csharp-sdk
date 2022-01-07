using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace SymblAISharp.Async.AudioApi
{
    public interface IAudioApi
    {
        Task<AudioResponse> PostAudioUrl(
           AudioRequest audioRequest);
        Task<AudioResponse> PostAudio(byte[] bytes,
            AudioRequest audioRequest);
        Task<AudioResponse> PutAudioUrl(
            string conversationId,
            AudioRequest audioRequest);
        Task<AudioResponse> PutAudio(string conversationId,
            byte[] bytes,
            AudioRequest audioRequest);
    }

    /// <summary>
    /// The Async Audio API allows you to process an audio file.
    // It can be utilized for any use case where you have access to
    // recorded audio and want to extract insights and other
    // conversational attributes supported by Symbl's Conversation API.
    public class AudioApi : IAudioApi
    {
        private readonly string token;
        private readonly string baseUrl;
        public AudioApi(string token,
            string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
            this.token = token;
        }

        /// <summary>
        /// Perform an Http Post with the ConversationId and VideoUrlRequest
        /// </summary>
        /// <param name="conversationId"></param>
        /// <param name="audioUrlRequest"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<AudioResponse> PostAudioUrl(
           AudioRequest audioRequest)
        {
            var url = $"{baseUrl}/v1/process/audio/url";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(audioRequest)
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
                        return JsonConvert.DeserializeObject<AudioResponse>(
                            streamReader.ReadToEnd());
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return null;
        }

        private static Dictionary<string, string> GetAudioRequestParam(AudioRequest audioRequest)
        {
            var param = new Dictionary<string, string>()
            {
                { "name", audioRequest.name },
                { "enableAllTrackers", audioRequest.enableAllTrackers.ToString().ToLower() },
                { "detectEntities", audioRequest.detectEntities.ToString().ToLower() },
                { "detectPhrases", audioRequest.detectPhrases.ToString().ToLower() },
            };

            if (!string.IsNullOrEmpty(audioRequest.languageCode))
                param.Add("languageCode",
                    audioRequest.languageCode);
                 
            if (audioRequest.customVocabulary.Count > 0)
                param.Add("customVocabulary",
                    JsonConvert.SerializeObject(audioRequest.customVocabulary));

            if (audioRequest.mode != null)
                param.Add("mode", audioRequest.mode);

            if (!string.IsNullOrEmpty(audioRequest.webhookUrl))
            {
                param.Add("webhookUrl", audioRequest.webhookUrl);
            }

            if (audioRequest.confidenceThreshold > 0)
            {
                param.Add("confidenceThreshold",
                    audioRequest.confidenceThreshold.ToString());
            }

            if(audioRequest.trackers.Count > 0)
            {
                param.Add("trackers",
                    JsonConvert.SerializeObject(
                        audioRequest.trackers.ToArray()));
            }

            return param;
        }

        public async Task<AudioResponse> PostAudio(byte[] bytes,
            AudioRequest audioRequest)
        {
            var url = $"{baseUrl}/v1/process/audio";

            Dictionary<string, string> param = GetAudioRequestParam(audioRequest);

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            var httpRequest = (HttpWebRequest)WebRequest.Create(newUrl);
            httpRequest.Method = "POST";
      
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
                            return JsonConvert.DeserializeObject<AudioResponse>(responseFromServer);
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
        /// <param name="audioUrlRequest"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<AudioResponse> PutAudioUrl(
            string conversationId,
            AudioRequest audioRequest)
        {
            var url = $"{baseUrl}/v1/process/audio/url/{conversationId}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(audioRequest)
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
                        return JsonConvert.DeserializeObject<AudioResponse>(
                            streamReader.ReadToEnd());
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<AudioResponse> PutAudio(string conversationId,
            byte[] bytes, AudioRequest audioRequest)
        {
            var url = $"{baseUrl}/v1/process/audio/{conversationId}";
           
            Dictionary<string, string> param = GetAudioRequestParam(audioRequest);

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            var httpRequest = (HttpWebRequest)WebRequest.Create(newUrl);
            httpRequest.Method = "PUT";

            httpRequest.ContentType = "x-www-form-urlencoded";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            httpRequest.ContentLength = bytes.Length;
            Stream dataStream = httpRequest.GetRequestStream();
            dataStream.Write(bytes, 0, bytes.Length);
            dataStream.Close();

            try
            {
                using (WebResponse response = await httpRequest.GetResponseAsync())
                {
                    if(((HttpWebResponse)response).StatusCode == HttpStatusCode.Created)
                    {
                        using (dataStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseFromServer = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<AudioResponse>(responseFromServer);
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
