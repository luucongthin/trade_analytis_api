
using IronPdf;
using SAMPLE_API.Common;
using SAMPLE_API.Utils;
using System;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using static SAMPLE_API.Utils.Logger;

namespace SAMPLE_API.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
    }
}