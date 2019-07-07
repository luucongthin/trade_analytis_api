using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.General
{
    public class StoreDTO
    {
        public string ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Information { get; set; }
        public string WardCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CategoryCode { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
    }
}