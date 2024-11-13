using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class CompatibilityRequest
    {
        public string UserElementName { get; set; }
        public string TankElement { get; set; }
        public HashSet<HashSet<string>> FishElements { get; set; }

        public CompatibilityRequest(string userElementName, string tankElement, HashSet<HashSet<string>> fishElements)
        {
            UserElementName = userElementName;
            TankElement = tankElement;
            FishElements = fishElements;
        }

        public CompatibilityRequest()
        {
            FishElements = new HashSet<HashSet<string>>();
        }
    }
}
