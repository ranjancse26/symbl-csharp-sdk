using System.Collections.Generic;

namespace SymblAISharp.Async.Tracker
{
    public class Match
    {
        public string type { get; set; }
        public string value { get; set; }
        public List<MessageRef> messageRefs { get; set; }
        public List<InsightRefs> insightRefs { get; set; }
    }

    public class InsightRefs
    {
        public string id { get; set; }
        public string text { get; set; }
        public int offset { get; set; }
    }

    public class MessageRef
    {
        public string id { get; set; }
        public string text { get; set; }
        public int offset { get; set; }
    }

    public class TrackerDetectedResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Match> matches { get; set; }
    }
}
