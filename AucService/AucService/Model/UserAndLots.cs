using AucService.Services;
using System.Collections.Generic;

namespace AucService.Model
{
    public class UserAndLots
    {
        public string username { get; set; }
        public IEnumerable<Lot> lots { get; set; }
    }
}
