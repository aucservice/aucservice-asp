using System;

namespace AucService.Model
{
    public class Bid
    {
        public string lot_id { get; set; }
        public string username { get; set; }
        public int amount { get; set; }
        public long timestamp { get; set; }
    }
}
