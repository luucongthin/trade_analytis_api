using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.RequestDTO
{
    public class NTMRequestDTO
    {
        public string reporter { get; set; }
        public string reporter_code { get; set; }
        public string partner { get; set; }
        public string partner_code { get; set; }
        public string partner_comment { get; set; }
        public string product_code { get; set; }
        public string product_coverage { get; set; }
        public string hs_revision { get; set; }
        public string product_comment { get; set; }
        public string ntm_code { get; set; }
        public string ntm_revision { get; set; }
        public string ntm_comment { get; set; }
        public string category_code { get; set; }
    }
}