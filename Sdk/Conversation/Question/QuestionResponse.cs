using System.Collections.Generic;

namespace SymblAISharp.Conversation.Question
{
    public class From
    {
        public string id { get; set; }
        public string name { get; set; }
        public string userId { get; set; }
    }

    public class Question
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public double score { get; set; }
        public List<string> messageIds { get; set; }
        public From from { get; set; }
    }

    public class QuestionResponse
    {
        public List<Question> questions { get; set; }
    }
}
