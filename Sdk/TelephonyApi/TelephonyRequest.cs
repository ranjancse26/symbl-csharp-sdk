using System.Collections.Generic;

namespace SymblAISharp.TelephonyApi
{
    public class Endpoint
    {
        public string type { get; set; }
        public string phoneNumber { get; set; }
    }

    public class Parameters
    {
        public List<string> emails { get; set; }
    }

    public class Action
    {
        public string invokeOn { get; set; }
        public string name { get; set; }
        public Parameters parameters { get; set; }
    }

    public class Session
    {
        public string name { get; set; }
    }

    public class Data
    {
        public Session session { get; set; }
    }

    public class TelephonyRequest
    {
        public string operation { get; set; }
        public Endpoint endpoint { get; set; }
        public List<Action> actions { get; set; }
        public Data data { get; set; }
    }
}
