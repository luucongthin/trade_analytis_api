using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.RequestDTO
{
    public class CategoryRequestDTO
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string code { get; set; }
    }
}