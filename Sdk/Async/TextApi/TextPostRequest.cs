using System.Collections.Generic;

namespace SymblAISharp.Async.TextApi
{
    public class TextPostRequest
    {
        public TextPostRequest()
        {
            name = "";
            webhookUrl = "";
            trackers = new List<Tracker>();
        }

        public string name { get; set; }
        public bool detectPhrases { get; set; }
        public double confidenceThreshold { get; set; }
        public string webhookUrl { get; set; }
        public bool enableAllTrackers { get; set; }
        public bool detectEntities { get; set; }
        public List<Message> messages { get; set; }
        public List<Tracker> trackers { get; set; }
    }
}
