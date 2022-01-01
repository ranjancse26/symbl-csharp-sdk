using System.Collections.Generic;

namespace SymblAISharp.TrackerApi
{
    public class Tracker
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> vocabulary { get; set; }
    }

    public class TrackerCreateResponse
    {
        public List<Tracker> trackers { get; set; }
    }

    public class TrackerResponse
    {
        public Tracker tracker { get; set; }
    }

    public class TrackerByNameResponse
    {
        public List<Tracker> trackers { get; set; }
    }

    public class TrackerDeleteResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public bool deleted { get; set; }
    }
}
