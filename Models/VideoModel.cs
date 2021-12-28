using System;

namespace Social_network.Models
{
    public class VideoModel
    {
        public object signal { get; set; }
        public string fromId { get; set; }
        public string toId { get; set; }
        public string name { get; set; }        
    }
}