using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SymblAISharp.TelephonyApi.SIP;

namespace SymblAISharp.TelephonyApi
{
	public interface ITelephonyApi
    {
		Task<TelephonyResponse> StartPSTNConnection(
			TelephonyRequest telephonyRequest);
		Task<TelephonyResponse> StartSIPConnection(
			SIPConnectRequest sipConnectRequest);
		Task<TelephonyResponse> StopConnection(
		   StopTelephonyRequest stopTelephonyRequest);
	}

	/// <summary>
	/// The Telephony API provides an interface for the developers 
	/// to have Symbl bridge/join VoIP calls and get the results back in real-time as well.
	/// </summary>
	public class TelephonyApi : ITelephonyApi
	{
        private readonly string token;
        private readonly string baseUrl;
        public TelephonyApi(string token,
            string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
            this.token = token;
        }

        public async Task<TelephonyResponse> StartPSTNConnection(
			TelephonyRequest telephonyRequest)
        {
			var url = $"{baseUrl}/v1/endpoint:connect";

			var httpRequest = (HttpWebRequest)WebRequest.Create(url);
			httpRequest.Method = "POST";

			httpRequest.Headers["x-api-key"] = token;
			httpRequest.ContentType = "application/json";
			httpRequest.Headers["Authorization"] = token;

			var data = JsonConvert.SerializeObject(telephonyRequest);

            try
            {
				using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
				{
					streamWriter.Write(data);
				}

				var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
				using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
						var result = streamReader.ReadToEnd();
						return JsonConvert.DeserializeObject<TelephonyResponse>(result);
					}
				}
			}
			catch(Exception ex)
            {
				throw;
            }

			return null;
		}

        public async Task<TelephonyResponse> StartSIPConnection(SIPConnectRequest sipConnectRequest)
        {
			var url = $"{baseUrl}/v1/endpoint:connect";

			var httpRequest = (HttpWebRequest)WebRequest.Create(url);
			httpRequest.Method = "POST";

			httpRequest.Headers["x-api-key"] = token;
			httpRequest.ContentType = "application/json";
			httpRequest.Headers["Authorization"] = token;

			var data = JsonConvert.SerializeObject(sipConnectRequest);

            try
            {
				using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
				{
					streamWriter.Write(data);
				}

				var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
				using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
						var result = streamReader.ReadToEnd();
						return JsonConvert.DeserializeObject<TelephonyResponse>(result);
					}
				}
			}
			catch(Exception ex)
            {
				throw;
            }

			return null;
		}

        public async Task<TelephonyResponse> StopConnection(
			StopTelephonyRequest stopTelephonyRequest)
		{
			var url = $"{baseUrl}/v1/endpoint:connect";

			var httpRequest = (HttpWebRequest)WebRequest.Create(url);
			httpRequest.Method = "POST";

			httpRequest.Headers["x-api-key"] = token;
			httpRequest.ContentType = "application/json";
			httpRequest.Headers["Authorization"] = token;

			var data = JsonConvert.SerializeObject(stopTelephonyRequest);

            try
            {
				using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
				{
					streamWriter.Write(data);
				}

				var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
				using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
						var result = streamReader.ReadToEnd();
						return JsonConvert.DeserializeObject<TelephonyResponse>(result);
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
