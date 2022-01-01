using System;
using System.Collections.Generic;

namespace SymblAISharp.Conversation.SpeechToText
{
    public class From
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Phrase
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Polarity
    {
        public double score { get; set; }
    }

    public class Sentiment
    {
        public Polarity polarity { get; set; }
        public string suggested { get; set; }
    }

    public class Word
    {
        public string word { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }

    public class Message
    {
        public string id { get; set; }
        public string text { get; set; }
        public From from { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string conversationId { get; set; }
        public List<Phrase> phrases { get; set; }
        public Sentiment sentiment { get; set; }
        public List<Word> words { get; set; }
    }

    public class SpeechToTextResponse
    {
        public List<Message> messages { get; set; }
    }
}
