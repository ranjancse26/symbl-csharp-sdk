namespace SymblAISharp.Management
{
    public class ConversationCreateGroupRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public string criteria { get; set; }
    }

    public class ConversationUpdateGroupRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string criteria { get; set; }
    }
}
