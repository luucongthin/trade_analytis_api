
using SAMPLE_API.Business.General;
using SAMPLE_API.Common;
using SAMPLE_API.Utils;
using System.Web.Http;
using static SAMPLE_API.Utils.Logger;

namespace SAMPLE_API.Controllers
{
    public class ProductController : ApiController
    {

        // GET: api/Product/5
        [HttpGet]
        [Route("api/product")]
        public object Get(string name)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = ProductBUS.GetAllProduct(name);

            return Response;
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
