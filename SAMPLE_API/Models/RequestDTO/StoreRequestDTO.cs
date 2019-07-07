using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.RequestDTO
{
    public class StoreRequestDTO
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public string information { get; set; }
        public string ward_code { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string category_code { get; set; }
        public string type { get; set; }
        public string note { get; set; }
    }
}