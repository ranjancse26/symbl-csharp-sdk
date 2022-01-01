namespace SymblAISharp.Management
{
    public class Group
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string criteria { get; set; }
    }

    public class ConversationGroupResponse
    {
        public Group group { get; set; }
    }

    public class ConversationDeleteResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public bool deleted { get; set; }
    }
}
