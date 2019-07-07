using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SAMPLE_API.Models.RequestDTO;
using SAMPLE_API.Models.ResponseDTO;
using SAMPLE_API.Common;
using SAMPLE_API.Utils;

using SAMPLE_API.Business.User;
using System.Web;
using Newtonsoft.Json;
using static SAMPLE_API.Utils.JwtAuthProvider;
using static SAMPLE_API.Utils.Logger;
using System.Web.Http.Cors;

namespace SAMPLE_API.Controllers
{
    public class UserController : ApiController
    {
        // USER LOGIN
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login([FromBody] UserRequestDTO user)
        {
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(user), Level.INFO);

            ResponseDTO RES = new ResponseDTO();
            ErrorDTO error = new ErrorDTO();
            LoginResponseDTO LoginRes = new LoginResponseDTO();

            //string email = user.username != null ? user.username : "";
            //string password = user.password != null ? user.password : "";
            //string page = user.page != null ? user.page : "";
            //string signature = user.signature != null ? user.signature : "";

            RES = LoginBUS.CheckUserLogin(user.username, user.password, user.page, 1);
            if(RES.Error == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, RES);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, RES);

            }
        }

        // GET USER INFO
        [HttpGet]
        [Route("api/user/{id}")]
        public object GetUserData(int id)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            //Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), id.ToString(), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();


            // CHECK token
            //if (ValidateToken(token))
            //{
            //    Response = UserBUS.GetUserInfo(id);
            //}
            //else
            //{
            //    ErrorResponse.Code = 403;
            //    ErrorResponse.Message = "Invalid Token";

            //    Response.Error = ErrorResponse;
            //}
            
            Response = UserBUS.GetUserInfo(id);


            return Response;
        }

        // GET USER INFO
        [HttpGet]
        [Route("api/account")]
        public object GetAccountLogin()
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            int id = ValidateToken(token);
            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();

            Response = UserBUS.GetUserInfo(id);

            if (Response.Error == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Response);

            }
        }

        // GET ALL USER INFO
        [HttpGet]
        [Route("api/users")]
        public object GetAllUserData(string username = "", string email = "", int typesearch = 0)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();


            Response = UserBUS.GetAllUserInfo(username, email, typesearch);


            return Response;
        }

        [HttpGet]
        [Route("api/users/roles")]
        public object GetAllRoleData()
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            //Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), null, Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();


            Response = UserBUS.GetAllRole();


            return Response;
        }

        // CREATE  USER
        [HttpPost]
        [Route("api/user/create")]
        public object CreateNewUser([FromBody]UserRequestDTO userData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(userData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            UserResponseDTO UserResponse = new UserResponseDTO();

            Response = UserBUS.GetAllUserInfo(userData.username, "", 0);

            if(Response.Data == null)
            {
                Response = UserBUS.AddOrUpdateUser(userData);
            }
            else{
                ErrorResponse.Code = 400;
                ErrorResponse.Message = "Tài khoản đã tồn tại";
                Response.Error = ErrorResponse;
                Response.Data = null;
            }


            return Response;
        }

        // CREATE  USER
        [HttpPost]
        [Route("api/user/update")]
        public object UpdateUser([FromBody]UserRequestDTO userData)
        {
            string token = Request.Headers.Authorization == null ? "" : Request.Headers.Authorization.ToString();
            Logger.Info(Request.RequestUri + "  ||  Method: " + Request.Method, Request.Headers.ToString(), JsonConvert.SerializeObject(userData), Level.INFO);

            ResponseDTO Response = new ResponseDTO();
            ErrorDTO ErrorResponse = new ErrorDTO();
            UserResponseDTO UserResponse = new UserResponseDTO();

            Response = UserBUS.AddOrUpdateUser(userData);


            return Response;
        }

    }
}
