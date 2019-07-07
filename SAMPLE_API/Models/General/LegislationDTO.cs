using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.General
{
    public class LegislationDTO
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CategoryCode { get; set; }
        public string Reporter { get; set; }
        public string ImplementingAuthority { get; set; }
        public string IsImportingCountry { get; set; }
        public string Agency { get; set; }
    }
}