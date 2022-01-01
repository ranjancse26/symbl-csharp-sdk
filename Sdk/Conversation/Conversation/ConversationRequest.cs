namespace SymblAISharp.Conversation.Conversation
{
    public class MetadataPut
    {
        public string key { get; set; }
        public string agentId { get; set; }
    }

    public class ConversationPutRequest
    {
        public MetadataPut metadata { get; set; }
    }
}
