using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SymblAISharp.JobApi;

namespace SymblAISharp.Async.JobApi
{
    public interface IJobApi
    {
        Task<JobResponse> GetJobResponse(string jobId);
    }

    public class JobApi : IJobApi
    {
        private readonly string token;
        private readonly string baseUrl;
        public JobApi(string token,
            string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
            this.token = token;
        }

        public async Task<JobResponse> GetJobResponse(string jobId)
        {
            var url = $"{baseUrl}/v1/job/{jobId}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = await httpRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (((HttpWebResponse)httpResponse).StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<JobResponse>(
                        streamReader.ReadToEnd());
            }

            return null;
        }
    }
}
