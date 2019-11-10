using Newtonsoft.Json;
using SAMPLE_API.Business.General;
using SAMPLE_API.Common;
using SAMPLE_API.Models.General;
using SAMPLE_API.Models.RequestDTO;
using SAMPLE_API.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Xml.Linq;
using static SAMPLE_API.Utils.Logger;

namespace SAMPLE_API.Controllers
{
    public class StoreController : ApiController
    {
        // GET: api/Ward
        [HttpGet]
        [Route("api/store")]
        public object Get(string name = "", string category_code = "", string address = "", string ward_code = "", int page = 1, int size = 12)
        {
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = StoreBUS.GetAllStore( name, category_code, address, ward_code, page, size);

            return Response;
        }

        [HttpGet]
        [Route("api/store/front")]
        public object GetFront(string category_code = "", string city_code = "", string district_code = "", string ward_code = "", int page = 1, int size = 10000)
        {
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = StoreBUS.GetAllStoreFront(category_code, city_code, district_code, ward_code, page, size);

            return Response;
        }

        [HttpGet]
        [Route("api/store/count")]
        public object Count(string category_code = "", string city_code = "", string district_code = "", string ward_code = "", int page = 1, int size = 12)
        {
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = StoreBUS.CountStore(category_code, city_code, district_code, ward_code, page, size);

            return Response;
        }


        [HttpGet]
        [Route("api/store/search")]
        public object GetByID(int id)
        {
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = StoreBUS.GetStoreByID(id);

            return Response;
        }

        [HttpPost]
        [Route("api/store/create")]
        public object CreateNewStore([FromBody]StoreRequestDTO storeData)
        {
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(storeData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();

            Response = StoreBUS.AddOrUpdateStore(storeData);


            return Response;
        }


        [HttpPost]
        [Route("api/store/import")]
        public object ImportStore([FromBody]List<StoreRequestDTO> StoreData)
        {
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(StoreData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            WardDTO UserResponse = new WardDTO();

            var xmlElements = new XElement("Data",
            from item in StoreData
            select new XElement("Item",
                               new XElement("Code", item.code),
                               new XElement("Name", item.name),
                               new XElement("Adress", item.adress),
                               new XElement("Information", item.information),
                               new XElement("WardCode", item.ward_code),
                               new XElement("Latitude", item.latitude),
                               new XElement("Longitude", item.longitude),
                               new XElement("CategoryCode", item.category_code),
                               new XElement("Type", item.type),
                               new XElement("Note", item.note)
                           ));

            string data = xmlElements.ToString();

            Response = StoreBUS.ImportStore(xmlElements);

            return Response;
        }

        [HttpPost]
        [Route("api/store/update")]
        public object UpdateStore([FromBody]StoreRequestDTO storeData)
        {
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(storeData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();

            Response = StoreBUS.AddOrUpdateStore(storeData);


            return Response;
        }

        [HttpPost]
        [Route("api/store/delete")]
        public object Delete(int id)
        {
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(id), Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = StoreBUS.DeleteStore(id);


            return Response;
        }
    }
}
