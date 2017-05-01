using System.Collections.Generic;

namespace BuckarooSdk.Services
{
    internal class Service
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public string Version { get; set; }
        public List<RequestParameter> Parameters { get; set; } 
    }
}
