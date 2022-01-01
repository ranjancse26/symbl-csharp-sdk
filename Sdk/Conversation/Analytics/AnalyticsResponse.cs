using System.Collections.Generic;

namespace SymblAISharp.Conversation.Analytics
{
    public class Metric
    {
        public string type { get; set; }
        public double percent { get; set; }
        public double seconds { get; set; }
    }

    public class Pace
    {
        public int wpm { get; set; }
    }

    public class TalkTime
    {
        public double percentage { get; set; }
        public double seconds { get; set; }
    }

    public class ListenTime
    {
        public double percentage { get; set; }
        public double seconds { get; set; }
    }

    public class OverlappingMember
    {
        public string id { get; set; }
        public string name { get; set; }
        public string userId { get; set; }
        public double percent { get; set; }
        public double seconds { get; set; }
    }

    public class Overlap
    {
        public double overlapDuration { get; set; }
        public List<OverlappingMember> overlappingMembers { get; set; }
    }

    public class Member
    {
        public string id { get; set; }
        public string name { get; set; }
        public string userId { get; set; }
        public Pace pace { get; set; }
        public TalkTime talkTime { get; set; }
        public ListenTime listenTime { get; set; }
        public Overlap overlap { get; set; }
    }

    public class AnalyticsResponse
    {
        public List<Metric> metrics { get; set; }
        public List<Member> members { get; set; }
    }
}
