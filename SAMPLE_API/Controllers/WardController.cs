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
    public class WardController : ApiController
    {
        // GET: api/Ward
        [HttpGet]
        [Route("api/ward")]
        public object Get(string city_code = "", string district_code = "", string ward_name = "", int page = 1, int size = 12)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = WardBUS.GetAllWard(city_code, district_code, ward_name, page, size);

            return Response;
        }

        [HttpGet]
        [Route("api/ward/suggestcity")]
        public object GetCity(string city_name = "")
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = WardBUS.GetCity(city_name);

            return Response;
        }

        [HttpGet]
        [Route("api/ward/suggestdistrict")]
        public object GetDistrict(string city_code = "", string district_name = "")
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = WardBUS.GetDistrict(city_code, district_name);

            return Response;
        }

        [HttpGet]
        [Route("api/ward/suggestward")]
        public object GetWard(string city_code = "", string district_code = "", string ward_name = "")
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = WardBUS.GetAllWard(city_code, district_code, ward_name, 1, 1000);

            return Response;
        }

        [HttpGet]
        [Route("api/ward/{id}")]
        public object GetWardByID(int id)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = WardBUS.GetWardByID(id);

            return Response;
        }

        [HttpPost]
        [Route("api/ward/create")]
        public object CreateNewWard([FromBody]WardRequestDTO WardData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(WardData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            WardDTO UserResponse = new WardDTO();

            Response = WardBUS.AddOrUpdateWard(WardData);


            return Response;
        }

        [HttpPost]
        [Route("api/ward/import")]
        public object ImportWard([FromBody]List<WardRequestDTO> WardData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(WardData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            WardDTO UserResponse = new WardDTO();

            var xmlElements = new XElement("Data",
            from item in WardData
            select new XElement("Item",
                               new XElement("WardCode", item.ward_code),
                               new XElement("WardName", item.ward_name),
                               new XElement("Type", item.type),
                               new XElement("DistrictCode", item.district_code),
                               new XElement("DistrictName", item.district_name),
                               new XElement("CityCode", item.city_code),
                               new XElement("CityName", item.city_name),
                               new XElement("Population", item.population),
                               new XElement("Area", item.area)
                           ));

            string data = xmlElements.ToString();

            Response = WardBUS.ImportWard(xmlElements);

            return Response;
        }

        [HttpPost]
        [Route("api/ward/update")]
        public object UpdateWard([FromBody]WardRequestDTO WardData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(WardData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            CategoryDTO UserResponse = new CategoryDTO();

            Response = WardBUS.AddOrUpdateWard(WardData);


            return Response;
        }

        [HttpPost]
        [Route("api/ward/delete")]
        public object Delete(int id)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(id), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            CategoryDTO UserResponse = new CategoryDTO();

            Response = WardBUS.DeleteWard(id);


            return Response;
        }
    }
}
