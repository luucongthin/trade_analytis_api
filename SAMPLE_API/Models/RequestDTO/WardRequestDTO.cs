using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.RequestDTO
{
    public class WardRequestDTO
    {
        public string id { get; set; }
        public string ward_code { get; set; }
        public string ward_name { get; set; }
        public string type { get; set; }
        public string district_code { get; set; }
        public string district_name { get; set; }
        public string city_code { get; set; }
        public string city_name { get; set; }
        public string population { get; set; }
        public string area { get; set; }
    }
}