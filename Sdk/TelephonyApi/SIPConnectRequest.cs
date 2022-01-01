using System.Collections.Generic;

namespace SymblAISharp.TelephonyApi.SIP
{
    public class AudioConfig
    {
        public int sampleRate { get; set; }
        public string encoding { get; set; }
        public int sampleSize { get; set; }
    }

    public class Endpoint
    {
        public string providerName { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public AudioConfig audioConfig { get; set; }
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
        public List<User> user { get; set; }
    }

    public class Data
    {
        public Session session { get; set; }
    }

    public class User
    {
        public string userId { get; set; }
        public string name { get; set; }
    }

    public class SIPConnectRequestWithUser
    {
        public string operation { get; set; }
        public Endpoint endpoint { get; set; }
        public List<Action> actions { get; set; }
        public Data data { get; set; }
    }

    public class SIPConnectRequest
    {
        public string operation { get; set; }
        public Endpoint endpoint { get; set; }
        public List<Action> actions { get; set; }
        public Data data { get; set; }
    }
}
