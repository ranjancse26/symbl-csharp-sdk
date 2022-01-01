using System.Collections.Generic;

namespace SymblAISharp.Async.TextApi
{
    public class Tracker
    {
        public string name { get; set; }
        public List<string> vocabulary { get; set; }
    }

    public class TextPutRequest
    {
        public TextPutRequest()
        {
            entities = new List<Entity>();
            trackers = new List<Tracker>();
        }

        public List<Entity> entities { get; set; }
        public bool detectPhrases { get; set; }
        public List<Message> messages { get; set; }
        public List<Tracker> trackers { get; set; }
    }
}
