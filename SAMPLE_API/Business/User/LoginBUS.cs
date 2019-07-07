using SAMPLE_API.Common;
using SAMPLE_API.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SAMPLE_API.Models.UserDTO;
using SAMPLE_API.Models.ResponseDTO;

using static SAMPLE_API.Utils.Logger;

namespace SAMPLE_API.Business.User
{
    public class LoginBUS
    {

        private SqlConnection con;
        private static Connection connection = new Connection();

        public static ResponseDTO CheckUserLogin(string username, string password, string page, int typeSearch)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            LoginResponseDTO DataResponse = new LoginResponseDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchUserData";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "UserName";
            param1.SqlDbType = SqlDbType.NVarChar;
            if (username != null && username != "")
            {
                param1.Value = username;
            }
            else
            {
                param1.Value = DBNull.Value;
            }
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "Password";
            param2.SqlDbType = SqlDbType.NVarChar;
            if (password != null && password != "")
            {
                param2.Value = password;
            }
            else
            {
                param2.Value = DBNull.Value;
            }
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "TypeSearch";
            param3.SqlDbType = SqlDbType.Int;
            param3.Value = typeSearch;
            cmd.Parameters.Add(param3);
            List<UserDTO> ListUsers = new List<UserDTO>();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserDTO userModel = new UserDTO();
                        userModel.ID = Convert.ToInt16(reader["ID"].ToString());
                        userModel.UserName = reader["username"].ToString();
                        userModel.FirstName = reader["first_name"].ToString();
                        userModel.LastName = reader["last_name"].ToString();
                        userModel.Password = reader["password"].ToString();
                        userModel.Email = reader["email"].ToString();
                        userModel.Role = reader["ROLES"].ToString();
                        userModel.Permission = reader["PERMISSTION"].ToString();
                        ListUsers.Add(userModel);
                    }
                }

                if(ListUsers.Count > 0)
                {
                    if((ListUsers[0].Role.ToUpper() != "PAID USER" && ListUsers[0].Role.ToUpper() != "FREE USER" && page == "admin") || (page == "front"))
                    {
                        DataResponse.id = ListUsers[0].ID;
                        DataResponse.token = JwtAuthProvider.GenerateToken(ListUsers[0].UserName, ListUsers[0].Password);

                        Response.Data = DataResponse;
                    }
                    else
                    {
                        ErrorResponse.Code = 404;
                        ErrorResponse.Message = "Authenticate Error";

                        Response.Error = ErrorResponse;
                    }

                    return Response;

                }
                else
                {
                    ErrorResponse.Code = 404;
                    ErrorResponse.Message = "Authenticate Error";

                    Response.Error = ErrorResponse;

                    return Response;
                }
                
            }
            catch (Exception ex)
            {
                Logger.Error("", ex, Level.ERROR);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static ErrorDTO CheckSignature(string timestamp, string signature)
        {

            ErrorDTO error = new ErrorDTO();

            string signatureGen = Signature.GenerateSignature(timestamp);
                // check user login
            if (signature == signatureGen)
            {
               
                return error = null;
            }
            else
            {
                error.Code = Constans.INVALID_DATA_CODE;
                error.Message = Constans.INVALID_DATA_MSG;

                Logger.Info(error.Code + " || " + error.Message + " || Timestamp :" + timestamp + " || Signature :" + signature, Level.ERROR);

                return error;
            }

        }
    }
}