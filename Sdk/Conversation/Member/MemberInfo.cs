using System.Collections.Generic;

namespace SymblAISharp.Conversation.Member
{
    public class Member
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class MemberInfoGetResponse
    {
        public List<Member> members { get; set; }
    }

    public class MemberInfoPutResponse
    {
        public string message { get; set; }
    }
}
