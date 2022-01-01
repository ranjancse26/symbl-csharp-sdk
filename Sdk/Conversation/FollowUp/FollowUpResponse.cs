using System;
using System.Collections.Generic;

namespace SymblAISharp.Conversation.FollowUp
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Entity
    {
        public string type { get; set; }
        public string text { get; set; }
        public int offset { get; set; }
        public object value { get; set; }
    }

    public class From
    {
    }

    public class Assignee
    {
    }

    public class FollowUp
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public double score { get; set; }
        public List<string> messageIds { get; set; }
        public List<Entity> entities { get; set; }
        public From from { get; set; }
        public Assignee assignee { get; set; }
        public DateTime dueBy { get; set; }
    }

    public class FollowUpResponse
    {
        public List<FollowUp> followUps { get; set; }
    }
}
