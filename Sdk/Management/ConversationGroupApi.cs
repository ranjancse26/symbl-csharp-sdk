using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SymblAISharp.Management
{
    public interface IConversationGroupApi
    {
        Task<ConversationGroupResponse> CreateConversationGroup(ConversationCreateGroupRequest conversationCreateGroupRequest);
        Task<ConversationGroupResponse> UpdateConversationGroup(ConversationUpdateGroupRequest conversationGroupRequest);
        Task<ConversationDeleteResponse> DeleteConversationGroup(string groupId);
    }

    /// <summary>
    /// Conversation Groups allow you to create logical groups
    /// of conversations by setting the grouping criteria that suit your business requirement.
    /// </summary>
    public class ConversationGroupApi : IConversationGroupApi
    {
        private readonly string token;
        private readonly string baseUrl;
        public ConversationGroupApi(string token,
            string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
            this.token = token;
        }

        public async Task<ConversationGroupResponse> CreateConversationGroup(ConversationCreateGroupRequest conversationCreateGroupRequest)
        {
            var url = $"{baseUrl}/v1/manage/group";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(
                    JsonConvert.SerializeObject(conversationCreateGroupRequest));
            }

            try
            {
                var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if(httpResponse.StatusCode == HttpStatusCode.Created)
                    {
                        var response = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<ConversationGroupResponse>(response);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<ConversationGroupResponse> UpdateConversationGroup(ConversationUpdateGroupRequest conversationGroupRequest)
        {
            var url = $"{baseUrl}/v1/manage/group/{conversationGroupRequest.id}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(
                    JsonConvert.SerializeObject(conversationGroupRequest));
            }

            try
            {
                var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var response = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<ConversationGroupResponse>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }

        public async Task<ConversationDeleteResponse> DeleteConversationGroup(string groupId)
        {
            var url = $"{baseUrl}/v1/manage/group/{groupId}";

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
                        return JsonConvert.DeserializeObject<ConversationDeleteResponse>(response);
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
