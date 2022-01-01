using System.Collections.Generic;

namespace SymblAISharp.Conversation.AbstractTopic
{
    public class AbstractTopic
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public double score { get; set; }
        public List<string> messageIds { get; set; }
    }

    public class AbstractTopicResponse
    {
        public List<AbstractTopic> abstractTopics { get; set; }
    }
}
