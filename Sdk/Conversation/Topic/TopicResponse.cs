using System.Collections.Generic;

namespace SymblAISharp.Conversation.Topic
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ParentRef
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Topic
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public double score { get; set; }
        public List<string> messageIds { get; set; }
        public List<ParentRef> parentRefs { get; set; }
    }

    public class TopicResponse
    {
        public List<Topic> topics { get; set; }
    }
}
