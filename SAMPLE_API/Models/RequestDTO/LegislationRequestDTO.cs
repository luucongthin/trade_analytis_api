using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.RequestDTO
{
    public class LegislationRequestDTO
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string summary { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string category_code { get; set; }
        public string reporter { get; set; }
        public string implementing_authority { get; set; }
        public string is_importing_country { get; set; }
        public string agency { get; set; }
    }
}