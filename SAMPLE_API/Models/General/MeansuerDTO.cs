using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.General
{
    public class MeansuerDTO
    {
        public string ID { get; set; }
        public string Reporter { get; set; }
        public string ReporterCode { get; set; }
        public string Partner { get; set; }
        public string PartnerCode { get; set; }
        public string PartnerComment { get; set; }
        public string ProductCode { get; set; }
        public string ProductCoverage { get; set; }
        public string HSRevision { get; set; }
        public string ProductComment { get; set; }
        public string NTMCode { get; set; }
        public string NTMRevision { get; set; }
        public string NTMComment { get; set; }
        public string CategoryCode { get; set; }
    }
}