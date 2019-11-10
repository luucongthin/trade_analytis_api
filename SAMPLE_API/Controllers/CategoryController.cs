using Newtonsoft.Json;
using SAMPLE_API.Business.General;
using SAMPLE_API.Common;
using SAMPLE_API.Models.General;
using SAMPLE_API.Models.RequestDTO;
using SAMPLE_API.Utils;
using System.Web.Http;
using static SAMPLE_API.Utils.Logger;

namespace SAMPLE_API.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/categories")]
        public object Get(string name = "", string title = "", string code = "")
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();

            Response = CategoryBUS.GetAllCategory(name, title, code);

            return Response;
        }

        [HttpPost]
        [Route("api/categories/create")]
        public object CreateNewCategory([FromBody]CategoryRequestDTO categoryData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(categoryData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            CategoryDTO UserResponse = new CategoryDTO();

            Response = CategoryBUS.AddOrUpdateCategory(categoryData);


            return Response;
        }

        [HttpPost]
        [Route("api/categories/update")]
        public object UpdateCategory([FromBody]CategoryRequestDTO categoryData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(categoryData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            CategoryDTO UserResponse = new CategoryDTO();

            Response = CategoryBUS.AddOrUpdateCategory(categoryData);


            return Response;
        }

        [HttpPost]
        [Route("api/categories/delete")]
        public object Delete(int id, string category_code)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(id), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ResponseDTO ResponseStore = new ResponseDTO();
            ResponseDTO ResponseLegislation = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            CategoryDTO UserResponse = new CategoryDTO();

            ResponseStore = StoreBUS.GetAllStore("", category_code, "", "", 1, 100);
            ResponseLegislation = LegislationBUS.GetAllLegislation("", "", category_code, 1, 100);

            if(ResponseStore.Data == null && ResponseLegislation.Data == null)
            {
                Response = CategoryBUS.DeleteCategory(id);
            }
            else
            {
                ErrorResponse.Code = 400;
                ErrorResponse.Message = "Industry being used";
                Response.Error = ErrorResponse;
            }

            return Response;
        }
    }
}
