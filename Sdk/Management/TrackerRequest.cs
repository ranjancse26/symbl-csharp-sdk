using System.Collections.Generic;

namespace SymblAISharp.TrackerApi
{
    public class TrackerRequest
    {
        public TrackerRequest()
        {
            vocabulary = new List<string>();
        }

        public string name { get; set; }
        public List<string> vocabulary { get; set; }
    }
}
