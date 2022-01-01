using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SymblAISharp.Async.TextApi
{
    public interface ITextApi
    {
        Task<TextResponse> Post(
            TextPostRequest processText);
        Task<TextResponse> Put(TextPutRequest textPutRequest,
            string conversationId);
    }

    /// <summary>
    /// The Async Text API allows you to process any text payload. 
    /// This API is useful for when you want to extract Conversation Insights
    /// from textual content.
    /// </summary>
    public class TextApi : ITextApi
    {
        private readonly string token;
        private readonly string baseUrl;
        public TextApi(string token,
            string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
            this.token = token;
        }

        /// <summary>
        /// Extract Conversation Insights from textual content
        /// </summary>
        /// <param name="textRequest"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<TextResponse> Post(
            TextPostRequest textRequest)
        {
            string url = $"{baseUrl}/v1/process/text";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {                
                streamWriter.Write(
                    JsonConvert.SerializeObject(textRequest)
                    .Replace("\"duration\":null,","")
                    .Replace("\"webhookUrl\":\"\",", "")
                    .Replace("\"confidenceThreshold\":0.0,", "")
                    .Replace("True", "true")
                    .Replace("False", "false"));
            }

            var httpResponse = await httpRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (((HttpWebResponse)httpResponse).StatusCode == HttpStatusCode.Created)
                    return JsonConvert.DeserializeObject<TextResponse>(
                        streamReader.ReadToEnd());
            }

            return null;
        }

        /// <summary>
        /// The PUT Async Text API allows you to process any text payload to append the transcription of the previous conversation.
        /// </summary>
        /// <param name="textPutRequest"></param>
        /// <param name="conversationId"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<TextResponse> Put(TextPutRequest textPutRequest,
            string conversationId)
        {
            string url = $"{baseUrl}/v1/process/text/{conversationId}";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(
                    JsonConvert.SerializeObject(textPutRequest)
                    .Replace("\"duration\":null,", "")
                    .Replace("\"webhookUrl\":\"\",", "")
                    .Replace("\"confidenceThreshold\":0.0,", "")
                    .Replace("True", "true")
                    .Replace("False", "false"));
            }

            var httpResponse = await httpRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (((HttpWebResponse)httpResponse).StatusCode == HttpStatusCode.Created)
                    return JsonConvert.DeserializeObject<TextResponse>(
                        streamReader.ReadToEnd());
            }

            return null;
        }
    }
}
