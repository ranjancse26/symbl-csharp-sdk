using System;
using System.Collections.Generic;

namespace SymblAISharp.Conversation.Conversation
{
    public class Member
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Metadata
    {
        public string key { get; set; }
        public string agentId { get; set; }
    }

    public class Conversation
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public List<Member> members { get; set; }
        public Metadata metadata { get; set; }
    }

    public class ConversationResponse
    {
        public List<Conversation> conversations { get; set; }
    }

    public class ConversationPutResponse
    {
        public string id { get; set; }
        public Metadata metadata { get; set; }
    }

    public class ConversationDeleteResponse
    {
        public string message { get; set; }
    }
}
