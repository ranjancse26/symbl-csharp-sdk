namespace SymblAISharp.Conversation.FormattedTranscript
{
    public class Transcript
    {
        public string payload { get; set; }
        public string contentType { get; set; }
    }

    public class TranscriptResponse
    {
        public Transcript transcript { get; set; }
    }
}
