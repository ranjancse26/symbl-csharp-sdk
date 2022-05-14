using System.Collections.Generic;

namespace SymblAISharp.Async.TextApi
{
    public class TextPutRequest
    {
        public TextPutRequest()
        {
            entities = new List<Entity>();
            trackers = new List<Tracker.Tracker>();
        }

        public List<Entity> entities { get; set; }
        public bool detectPhrases { get; set; }
        public List<Message> messages { get; set; }
        public List<Tracker.Tracker> trackers { get; set; }
    }
}
