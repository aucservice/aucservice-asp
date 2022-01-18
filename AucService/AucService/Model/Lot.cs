using System;

namespace AucService.Model
{
    public class Lot
    {
        public string id { get; set; }
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string description { get; set; }
        public long bidding_end { get; set; }
    }
}