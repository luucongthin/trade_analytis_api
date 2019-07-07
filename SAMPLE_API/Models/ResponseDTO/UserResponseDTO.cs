using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Models.ResponseDTO
{
    public class UserResponseDTO
    {
        public string id { get; set; }
        public string token { get; set; }
        public string email { get; set; }
    }
}