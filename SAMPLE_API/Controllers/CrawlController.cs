using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage ExportPDF()
        {
            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();

            // New instance of HtmlToPdf
            var htmlToPdf = new HtmlToPdf();
            string fileName = "Report_Temperature_Demo.Pdf";
            // Get path
            string host = HttpContext.Current.Request.Url.Host;
            string port = HttpContext.Current.Request.Url.Port.ToString();
            string scheme = HttpContext.Current.Request.Url.Scheme;

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);

            string pathServer = scheme + "://" + host + ":" + port + "/";
            string pathExportFolder = pathServer + "Export/";

            var uri = new Uri(pathServer + Constans.REPORT_1);

            Logger.Info(pathServer, null, Level.INFO);
            try
            {
                // turn page into pdf
                PdfDocument pdf = htmlToPdf.RenderUrlAsPdf(uri);
                httpResponseMessage.Content = new StreamContent(pdf.Stream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = fileName;
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            }
            catch (Exception e)
            {
                Logger.Error(e.ToString(), null, null, Level.ERROR);
                ErrorResponse.Code = 400;
                ErrorResponse.Message = e.ToString();
                Response.Error = ErrorResponse;
            }

            return httpResponseMessage;
        }
    }
}
