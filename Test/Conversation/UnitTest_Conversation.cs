using SymblAI.Test;
using SymblAISharp.Conversation;
using SymblAISharp.Conversation.Conversation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Async.Test
{
    [TestClass]
    public class UnitTest_Conversation : BaseTest
    {
        private readonly string conversationId = "6285417289613312";

        [TestMethod]
        public void TestMethod_Get_TrackerDetected_Success()
        {
            var response = GetAuthToken();

            // TODO - Replace with your own conversation id

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var trackerDetectedResponse = conversationApi.GetTrackerDetectedResponse("4970748065087488");

            Assert.IsTrue(trackerDetectedResponse.Count > 0);
        }

        [TestMethod]
        public void TestMethod_Get_Sentiments_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var speechToTextResponse = conversationApi.GetSentiments(conversationId);

            Assert.IsTrue(speechToTextResponse != null);
        }

        [TestMethod]
        public void TestMethod_Get_SpeechToText_Success()
        {
            var response = GetAuthToken();
     
            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var speechToTextResponse = conversationApi.GetSpeechToText(conversationId);

            Assert.IsTrue(speechToTextResponse != null);
            Assert.IsTrue(speechToTextResponse.messages.Count > 0);
        }

        [TestMethod]
        public void TestMethod_Get_ActionItems_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var actionItemResponse = conversationApi.GetActionItem(conversationId);

            Assert.IsTrue(actionItemResponse != null);
            Assert.IsTrue(actionItemResponse.actionItems.Count > 0);
        }

        [TestMethod]
        public void TestMethod_Get_FollowUps_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var followUpResponse = conversationApi.GetFollowUps(conversationId);

            Assert.IsTrue(followUpResponse != null);
        }

        [TestMethod]
        public void TestMethod_Get_Topics_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var topicResponse = conversationApi.GetTopics(conversationId);

            Assert.IsTrue(topicResponse != null);
            Assert.IsTrue(topicResponse.topics.Count > 0);
        }

        [TestMethod]
        public void TestMethod_Get_AbstractTopics_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken,
                "https://api-labs.symbl.ai");
            var abstractTopicResponse = conversationApi.GetAbstractTopics(conversationId);

            Assert.IsTrue(abstractTopicResponse != null);
            Assert.IsTrue(abstractTopicResponse.abstractTopics.Count > 0);
        }

        [TestMethod]
        public void TestMethod_Get_Questions_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var questionResponse = conversationApi.GetQuestions(conversationId);

            Assert.IsTrue(questionResponse != null);
        }

        [TestMethod]
        public void TestMethod_Get_Entities_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var entityResponse = conversationApi.GetEntities(conversationId);

            Assert.IsTrue(entityResponse != null);
        }

        [TestMethod]
        public void TestMethod_Get_Analytics_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var analyticsResponse = conversationApi.GetAnalytics(conversationId);

            Assert.IsTrue(analyticsResponse != null);
            Assert.IsTrue(analyticsResponse.members.Count > 0);
            Assert.IsTrue(analyticsResponse.metrics.Count > 0);
        }

        [TestMethod]
        public void TestMethod_Get_ConversationData_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var conversationDataResponse = conversationApi.GetConversationData(conversationId);

            Assert.IsTrue(conversationDataResponse != null);
        }

        [TestMethod]
        public void TestMethod_Get_MemberInfo_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var memberInfoResponse = conversationApi.GetMemberInfo(conversationId);

            Assert.IsTrue(memberInfoResponse != null);
        }

        [TestMethod]
        public void TestMethod_Get_AllConversations_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var allConversationResponse = conversationApi.GetAllConversations();

            Assert.IsTrue(allConversationResponse != null);
        }

        [TestMethod]
        public void TestMethod_Get_FormattedTranscript_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var formattedTranscriptResponse = conversationApi.GetTranscriptResponse(conversationId, new SymblAISharp.Conversation.FormattedTranscript.TranscriptRequest
            {
                contentType = "text/markdown"
            });

            Assert.IsTrue(formattedTranscriptResponse != null);
            Assert.IsTrue(formattedTranscriptResponse.transcript != null);
        }

        [TestMethod]
        public void TestMethod_Update_MemberInfo_Success()
        {
            string memberId = "1"; // TODO : Update with the correct Member Id

            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var updateMemberInfoResponse = conversationApi.UpdateMemberInfo(new SymblAISharp.Conversation.Member.Member
            {
                email = "john@example.com",
                name = "John",
                id = memberId
            }, conversationId);

            Assert.IsTrue(updateMemberInfoResponse != null);
        }

        [TestMethod]
        public void TestMethod_Update_Conversation_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
            var updateConversationResponse = conversationApi.UpdateConversation(conversationId, new ConversationPutRequest
            {                
                metadata = new MetadataPut
                {
                    agentId= "johndoe",
                    key = "value"
                }
            });
            
            Assert.IsTrue(updateConversationResponse != null);
        }

        [TestMethod]
        public void TestMethod_Update_SpeakerEvents_Success()
        {
            var response = GetAuthToken();

            IConversationApi conversationApi = new ConversationApi(response.accessToken);
           
            var updateSpeakerEventResponse = conversationApi.UpdateSpeakerEvents(conversationId, new SymblAISharp.Conversation.SpeakerEvent.SpeakerEventPutRequest { 
                speakerEvents = new System.Collections.Generic.List<SymblAISharp.Conversation.SpeakerEvent.SpeakerEvent>
                {
                    new SymblAISharp.Conversation.SpeakerEvent.SpeakerEvent
                    {
                        type= "started_speaking",
                        user = new SymblAISharp.Conversation.SpeakerEvent.User
                        {
                            id = "4194eb50-357d-4712-a02d-94215ead1064",
                            email = "Derek@example.com",
                            name = "Derek"
                        },
                        offset = new SymblAISharp.Conversation.SpeakerEvent.Offset
                        {
                            seconds = 0,
                            nanos = 5000000000
                        }
                    },
                    new SymblAISharp.Conversation.SpeakerEvent.SpeakerEvent
                    {
                        type= "stopped_speaking",
                        user = new SymblAISharp.Conversation.SpeakerEvent.User
                        {
                            id = "4194eb50-357d-4712-a02d-94215ead1064",
                            email = "Derek@example.com",
                            name = "Derek"
                        },
                        offset = new SymblAISharp.Conversation.SpeakerEvent.Offset
                        {
                            seconds = 15,
                            nanos = 5000000000
                        }
                    }
                }
            });

            Assert.IsTrue(updateSpeakerEventResponse != null);
        }
    }
}
