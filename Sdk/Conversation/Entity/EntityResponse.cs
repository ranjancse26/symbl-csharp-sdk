using System.Collections.Generic;

namespace SymblAISharp.Conversation.Entity
{
    public class MessageRef
    {
        public string id { get; set; }
        public string text { get; set; }
        public int offset { get; set; }
    }

    public class EntityResponse
    {
        public string type { get; set; }
        public string customType { get; set; }
        public string value { get; set; }
        public string text { get; set; }
        public List<MessageRef> messageRefs { get; set; }
    }
}
