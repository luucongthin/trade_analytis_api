using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.ResponseDTO
{
    public class CountStoreDTO
    {
        public string CT { get; set; }
        public string Total{ get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
    }
}