using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AucService.Model
{
    public class User
    {
        [JsonIgnore] public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Lot> Lots { get; set; }
    }
}