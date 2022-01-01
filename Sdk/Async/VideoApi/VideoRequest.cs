using System.Collections.Generic;

namespace SymblAISharp.Async.VideoApi
{
    public class Entity
    {
        public string customType { get; set; }
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Speaker
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class ChannelMetadata
    {
        public int channel { get; set; }
        public Speaker speaker { get; set; }
    }

    public class VideoRequest
    {
        public VideoRequest()
        {
            customVocabulary = new List<string>();
            trackers = new List<string>();
            entities = new List<Entity>();
            channelMetadata = new List<ChannelMetadata>();
        }

        public string url { get; set; }
        public string name { get; set; }
        public double confidenceThreshold { get; set; }
        public bool detectPhrases { get; set; }
        public string webhookUrl { get; set; }
        public bool detectEntities { get; set; }
        public string languageCode { get; set; }
        public string mode { get; set; }
        public bool enableSeparateRecognitionPerChannel { get; set; }
        public bool enableAllTrackers { get; set; }
        public bool enableSpeakerDiarization { get; set; }
        public string diarizationSpeakerCount { get; set; }
        public List<string> customVocabulary { get; set; }
        public List<string> trackers { get; set; }
        public List<Entity> entities { get; set; }
        public List<ChannelMetadata> channelMetadata { get; set; }
    }
}
