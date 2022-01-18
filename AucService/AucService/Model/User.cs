using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AucService.Model
{
    public class User
    {
        public string username { get; set; }
        public string password_hash { get; set; }
    }
}