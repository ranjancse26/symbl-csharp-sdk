using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace SymblAISharp.Authentication
{
    public class AuthenticationApi
    {
        private readonly string baseUrl;
        public AuthenticationApi(string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
        }

        public AuthResponse GetAuthToken(AuthRequest authRequest)
        {
            var url = $"{baseUrl}/oauth2/token:generate";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["accept"] = "application/json";
            httpRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(authRequest));
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if(httpResponse.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<AuthResponse>(
                        streamReader.ReadToEnd());
            }

            return null;
        }
    }
}
