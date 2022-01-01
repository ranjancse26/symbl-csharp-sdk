using System.Collections.Generic;

namespace SymblAISharp.Conversation.SpeakerEvent
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Offset
    {
        public int seconds { get; set; }
        public object nanos { get; set; }
    }

    public class SpeakerEvent
    {
        public string type { get; set; }
        public User user { get; set; }
        public Offset offset { get; set; }
    }

    public class SpeakerEventPutRequest
    {
        public List<SpeakerEvent> speakerEvents { get; set; }
    }

    public class SpeakerEventPutResponse
    {
        public string message { get; set; }
    }
}
