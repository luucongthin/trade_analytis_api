using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.RequestDTO
{
    public class UserRequestDTO
    {
        public int? id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string role { get; set; }
        public string page { get; set; }
    }
}