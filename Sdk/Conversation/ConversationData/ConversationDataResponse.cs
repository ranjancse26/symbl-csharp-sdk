using System;
using System.Collections.Generic;

namespace SymblAISharp.Conversation.ConversationData
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Member
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Metadata
    {
        public string label { get; set; }
    }

    public class ConversationDataResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public List<Member> members { get; set; }
        public Metadata metadata { get; set; }
    }
}
