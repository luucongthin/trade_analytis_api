using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.General
{
    public class WardDTO
    {
        public long ID { get; set; }
        public string WardCode { get; set; }
        public string WardName { get; set; }
        public string Type { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public long Population { get; set; }
        public long Area { get; set; }
        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }


    }
}