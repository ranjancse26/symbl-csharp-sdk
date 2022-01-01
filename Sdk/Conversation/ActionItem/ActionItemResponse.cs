using System;
using System.Collections.Generic;

namespace SymblAISharp.Conversation.ActionItem
{
    public class Entity
    {
        public string type { get; set; }
        public string text { get; set; }
        public int offset { get; set; }
        public object value { get; set; }
    }

    public class From
    {
        public string id { get; set; }
        public string name { get; set; }
        public string userId { get; set; }
    }

    public class Assignee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class ActionItem
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public double score { get; set; }
        public List<string> messageIds { get; set; }
        public List<Entity> entities { get; set; }
        public List<object> phrases { get; set; }
        public From from { get; set; }
        public bool definitive { get; set; }
        public Assignee assignee { get; set; }
        public DateTime dueBy { get; set; }
    }

    public class ActionItemResponse
    {
        public List<ActionItem> actionItems { get; set; }
    }
}
