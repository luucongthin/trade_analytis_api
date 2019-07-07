using Newtonsoft.Json;
using SAMPLE_API.Business.General;
using SAMPLE_API.Common;
using SAMPLE_API.Models.General;
using SAMPLE_API.Models.RequestDTO;
using SAMPLE_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using static SAMPLE_API.Utils.Logger;

namespace SAMPLE_API.Controllers
{
    public class LegislationController : ApiController
    {
        // GET: api/Ward
        [HttpGet]
        [Route("api/legislation")]
        public object Get(string start_date = "", string end_date = "", string category_code = "", int page = 1, int size = 12)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = LegislationBUS.GetAllLegislation( start_date, end_date, category_code, page, size);

            return Response;
        }

        [HttpGet]
        [Route("api/legislation/get")]
        public object GetLegislation(string category_code = "", string reporter = "", int page = 1, int size = 12)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = LegislationBUS.GetLegislation(category_code, reporter, page, size);

            return Response;
        }

        [HttpGet]
        [Route("api/reporter")]
        public object Get(string name = "")
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = LegislationBUS.GetReporterData(name);

            return Response;
        }

        [HttpGet]
        [Route("api/meansuer")]
        public object GetMeansuer(string category_code = "", string reporter = "", string product = "", int page = 1, int size = 12)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = LegislationBUS.GetMeansuer(category_code, reporter, product, page, size);
            
            return Response;
        }

        [HttpGet]
        [Route("api/meansuer/BP")]
        public object GetMeansuerBP(string category_code = "", string reporter = "", string product = "", int page = 1, int size = 1200000)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = LegislationBUS.GetMeansuerBP(category_code, reporter, product, page, size);

            return Response;
        }

        [HttpGet]
        [Route("api/legislation/search")]
        public object GetByID(int id)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = LegislationBUS.GetAllLegislationByID(id);

            return Response;
        }

        [HttpPost]
        [Route("api/legislation/import")]
        public object ImportLegislation([FromBody]List<LegislationRequestDTO> LegislationData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(LegislationData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            WardDTO UserResponse = new WardDTO();

            var xmlElements = new XElement("Data",
            from item in LegislationData
            select new XElement("Item",
                               new XElement("Title", item.title),
                               new XElement("Description", item.description),
                               new XElement("Summary", item.summary),
                               new XElement("StartDate", item.start_date),
                               new XElement("EndDate", item.end_date),
                               new XElement("CategoryCode", item.category_code),
                               new XElement("Reporter", item.reporter),
                               new XElement("ImplementingAuthority", item.implementing_authority),
                               new XElement("IsImportingCountry", item.is_importing_country),
                               new XElement("Agency", item.agency)
                           ));

            string data = xmlElements.ToString();

            Response = LegislationBUS.ImportLegislation(xmlElements);

            return Response;
        }

        [HttpPost]
        [Route("api/legislation/import_NTM")]
        public object ImportNTM([FromBody]List<NTMRequestDTO> NTMData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(NTMData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            WardDTO UserResponse = new WardDTO();

            var xmlElements = new XElement("Data",
            from item in NTMData
            select new XElement("Item",
                                new XElement("Reporter", item.reporter),
                                new XElement("ReporterCode", item.reporter_code),
                                new XElement("Partner", item.partner),
                                new XElement("PartnerCode", item.partner_code),
                                new XElement("PartnerComment", item.partner_comment),
                                new XElement("ProductCode", item.product_code),
                                new XElement("ProductCoverage", item.product_coverage),
                                new XElement("HSRevision", item.hs_revision),
                                new XElement("ProductComment", item.product_comment),
                                new XElement("NTMCode", item.ntm_code),
                                new XElement("NTMRevision", item.ntm_revision),
                                new XElement("NTMComment", item.ntm_comment),
                                new XElement("CategoryCode", item.category_code)
                           ));

            string data = xmlElements.ToString();

            Response = LegislationBUS.ImportNTM(xmlElements);

            return Response;
        }

        [HttpPost]
        [Route("api/legislation/create")]
        public object CreateNewLegislation([FromBody]LegislationRequestDTO legislationData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(legislationData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();

            Response = LegislationBUS.AddOrUpdateLegislation(legislationData);


            return Response;
        }

        [HttpPost]
        [Route("api/legislation/update")]
        public object UpdateLegislation([FromBody]LegislationRequestDTO legislationData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(legislationData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();

            Response = LegislationBUS.AddOrUpdateLegislation(legislationData);


            return Response;
        }

        [HttpPost]
        [Route("api/legislation/delete")]
        public object Delete(int id)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(id), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();

            Response = LegislationBUS.DeleteLegislation(id);


            return Response;
        }
    }
}
