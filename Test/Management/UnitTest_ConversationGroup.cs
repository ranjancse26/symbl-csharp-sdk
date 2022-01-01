using System;
using System.Threading.Tasks;
using SymblAISharp.Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Test.Management
{
    [TestClass]
    public class UnitTest_ConversationGroup : BaseTest
    {
        // TODO - Replace with your conversation group id
        private readonly string conversationGroupId = "5014114125479936";

        [TestMethod]
        public async Task TestMethod_CreateNewGroup_Success()
        {
            string newGuid = Guid.NewGuid().ToString();
            var response = GetAuthToken();

            IConversationGroupApi conversationGroupApi = new ConversationGroupApi(response.accessToken);
            var conversationGroupResponse = await conversationGroupApi.CreateConversationGroup(new ConversationCreateGroupRequest
            {
                name = $"Calls made by John {newGuid}",
                description = "All the conversations made by the agent John Doe are captured in this Group.",
                criteria = "conversation.metadata.agentId==johndoe"
            });

            Assert.IsTrue(conversationGroupResponse != null);
        }

        [TestMethod]
        public async Task TestMethod_UpdateGroup_Success()
        {
            string newGuid = Guid.NewGuid().ToString();
            var response = GetAuthToken();

            IConversationGroupApi conversationGroupApi = new ConversationGroupApi(response.accessToken);
            var conversationGroupResponse = await conversationGroupApi.UpdateConversationGroup(new ConversationUpdateGroupRequest
            {
                id = conversationGroupId,
                name = $"Calls made by John {newGuid}",
                description = "All the conversations made by the agent John Doe are captured in this Group.",
                criteria = "conversation.metadata.agentId==johndoe"
            });

            Assert.IsTrue(conversationGroupResponse != null);
        }

        [TestMethod]
        public async Task TestMethod_DeleteGroup_Success()
        {
            var response = GetAuthToken();

            IConversationGroupApi conversationGroupApi = new ConversationGroupApi(response.accessToken);
            var conversationGroupResponse = await conversationGroupApi.DeleteConversationGroup(conversationGroupId);

            Assert.IsTrue(conversationGroupResponse != null);
        }
    }
}
