using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using IronPdf;
using SAMPLE_API.Common;
using SAMPLE_API.Utils;
using static SAMPLE_API.Utils.Logger;

namespace SAMPLE_API.Controllers
{
    public class CrawlController : ApiController
    {
        // Get list url crawl
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/crawl/export")]
        public object ExportPDF()
        {
            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();

            string fileName = "UrlToPdf.Pdf";
            // Get path
            string host = HttpContext.Current.Request.Url.Host;
            string port = HttpContext.Current.Request.Url.Port.ToString();
            string scheme = HttpContext.Current.Request.Url.Scheme;
            string pathServer = scheme + "://" + host + ":" + port + "/";

            Logger.Info(pathServer, null, Level.INFO);
            try
            {
                string pathReport = "";
                // New instance of HtmlToPdf
                var htmlToPdf = new HtmlToPdf();
                string pathExportFolder = pathServer + "Export/";

                var uri = new Uri(pathServer + "Home/Index");

                // turn page into pdf
                var pdf = htmlToPdf.RenderUrlAsPdf(uri);

                // save resulting pdf into file
                pdf.SaveAs(Path.Combine(Constans.BASE_URL, fileName));
                pathReport = pathExportFolder + fileName;
                Response.Data = pathReport;
            }
            catch (Exception e)
            {
                Logger.Error(e.ToString(), null, null, Level.ERROR);
                ErrorResponse.Code = 400;
                ErrorResponse.Message = e.ToString();
                Response.Error = ErrorResponse;
            }
            return Response;
        }
    }
}
