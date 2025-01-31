using System.Collections.Generic;

namespace EasyLOB.Environment
{
    public class ResourcesJSON
    {
        public string Culture { get; set; }

        public Dictionary<string, string> Resources { get; set; }

        public ResourcesJSON()
        {
            Resources = new Dictionary<string, string>();
        }
    }
}
