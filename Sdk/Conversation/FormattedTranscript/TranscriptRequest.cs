namespace SymblAISharp.Conversation.FormattedTranscript
{
    public class Phrases
    {
        public bool highlightOnlyInsightKeyPhrases { get; set; }
        public bool highlightAllKeyPhrases { get; set; }
    }

    public class TranscriptRequest
    {
        public TranscriptRequest()
        {
            phrases = new Phrases();
        }

        public string contentType { get; set; }
        public bool createParagraphs { get; set; }
        public Phrases phrases { get; set; }
        public bool showSpeakerSeparation { get; set; }
    }
}
