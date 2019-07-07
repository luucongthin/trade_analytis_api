using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SAMPLE_API.Common;

namespace SAMPLE_API.Common
{
    public class ResponseDTO
    {
        public ErrorDTO Error { get; set; }

        public object Data { get; set; }
    }
}