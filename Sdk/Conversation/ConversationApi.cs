using System.IO;
using System.Net;
using Newtonsoft.Json;

using SymblAISharp.Conversation.Topic;
using SymblAISharp.Conversation.Member;
using SymblAISharp.Conversation.Entity;
using SymblAISharp.Conversation.FollowUp;
using SymblAISharp.Conversation.Question;
using SymblAISharp.Conversation.Analytics;
using SymblAISharp.Conversation.ActionItem;
using SymblAISharp.Conversation.Sentiment;
using SymblAISharp.Conversation.SpeakerEvent;
using SymblAISharp.Conversation.Conversation;
using SymblAISharp.Conversation.SpeechToText;
using SymblAISharp.Conversation.AbstractTopic;
using SymblAISharp.Conversation.ConversationData;
using SymblAISharp.Conversation.FormattedTranscript;
using SymblAISharp.Async.Tracker;
using System.Collections.Generic;

namespace SymblAISharp.Conversation
{
    public interface IConversationApi
    {
        SentimentResponse GetSentiments(string conversationId);
        SpeechToTextResponse GetSpeechToText(string conversationId);
        ActionItemResponse GetActionItem(string conversationId);
        FollowUpResponse GetFollowUps(string conversationId);
        TopicResponse GetTopics(string conversationId);
        AbstractTopicResponse GetAbstractTopics(string conversationId);
        QuestionResponse GetQuestions(string conversationId);
        EntityResponse GetEntities(string conversationId);
        AnalyticsResponse GetAnalytics(string conversationId);
        ConversationDataResponse GetConversationData(string conversationId);
        MemberInfoGetResponse GetMemberInfo(string conversationId);
        MemberInfoPutResponse UpdateMemberInfo(
           Member.Member member, string conversationId);
        SpeakerEventPutResponse UpdateSpeakerEvents(string conversationId,
            SpeakerEventPutRequest speakerEventPutRequest);
        ConversationResponse GetAllConversations();
        ConversationPutResponse UpdateConversation(string conversationId,
            ConversationPutRequest conversationPutRequest);
        ConversationDeleteResponse DeleteConversation(string conversationId);
        TranscriptResponse GetTranscriptResponse(string conversationId,
                TranscriptRequest transcriptRequest);
        List<TrackerDetectedResponse> GetTrackerDetectedResponse(string conversationId);
    }

    /// <summary>
    /// The Conversation API provides a REST API interface for getting your processed Speech to Text data(also known as Transcripts) and Conversational Insights.
    /// To view insights about a conversion, you must provide the API with a Conversation ID.
    /// </summary>
    public class ConversationApi : IConversationApi
    {
        private readonly string token;
        private readonly string baseUrl;
        public ConversationApi(string token,
            string baseUrl = "https://api.symbl.ai")
        {
            this.baseUrl = baseUrl;
            this.token = token;
        }

        public SpeechToTextResponse GetSpeechToText(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/messages";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<SpeechToTextResponse>(result);
                }
            }

            return null;
        }

        public ActionItemResponse GetActionItem(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/action-items";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<ActionItemResponse>(result);
                }                   
            }

            return null;
        }

        public FollowUpResponse GetFollowUps(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/follow-ups";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<FollowUpResponse>(result);
                }

                return null;
            }
        }

        public TopicResponse GetTopics(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/topics";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<TopicResponse>(result);
                }
            }

            return null;
        }

        public AbstractTopicResponse GetAbstractTopics(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/abstract-topics";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<AbstractTopicResponse>(result);
                }
            }

            return null;
        }

        public QuestionResponse GetQuestions(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/questions";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<QuestionResponse>(result);
                }
            }

            return null;
        }

        public EntityResponse GetEntities(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/entities";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<EntityResponse>(result);
                }
            }

            return null;
        }

        public AnalyticsResponse GetAnalytics(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/analytics";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<AnalyticsResponse>(result);
                }
            }

            return null;
        }

        public ConversationDataResponse GetConversationData(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<ConversationDataResponse>(result);
                }
            }

            return null;
        }

        public MemberInfoGetResponse GetMemberInfo(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/members";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<MemberInfoGetResponse>(result);
                }
            }

            return null;
        }

        public MemberInfoPutResponse UpdateMemberInfo(
            Member.Member member,
            string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/members/{member.id}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(member));
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<MemberInfoPutResponse>(response);
            }
        }

        public SpeakerEventPutResponse UpdateSpeakerEvents(string conversationId,
            SpeakerEventPutRequest speakerEventPutRequest)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/speakers";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(speakerEventPutRequest));
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if(httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var response = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<SpeakerEventPutResponse>(response);
                }
            }

            return null;
        }

        public ConversationResponse GetAllConversations()
        {
            var url = $"{baseUrl}/v1/conversations";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<ConversationResponse>(result);
                }
            }

            return null;
        }

        public List<TrackerDetectedResponse> GetTrackerDetectedResponse(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/trackers-detected";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "GET";

            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var response = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<
                        List<TrackerDetectedResponse>>(response);
                }
            }

            return null;
        }

        public TranscriptResponse GetTranscriptResponse(string conversationId,
            TranscriptRequest transcriptRequest)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/transcript";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(transcriptRequest));
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var response = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<TranscriptResponse>(response);
                }
            }

            return null;
        }

        public ConversationPutResponse UpdateConversation(string conversationId,
            ConversationPutRequest conversationPutRequest)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(
                    JsonConvert.SerializeObject(conversationPutRequest));
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<ConversationPutResponse>(response);
            }
        }

        public ConversationDeleteResponse DeleteConversation(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "DELETE";

            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<ConversationDeleteResponse>(response);
            }
        }

        public SentimentResponse GetSentiments(string conversationId)
        {
            var url = $"{baseUrl}/v1/conversations/{conversationId}/messages?sentiment=true";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "GET";

            httpRequest.Headers["Authorization"] = $"Bearer {token}";
            httpRequest.ContentType = "application/json";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var response = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<SentimentResponse>(response);
                }
            }

            return null;
        }
    }
}
