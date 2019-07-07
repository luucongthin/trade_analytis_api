using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SAMPLE_API.Models.ResponseDTO;
using Newtonsoft.Json;
using log4net.Core;
using SAMPLE_API.Utils;
using SAMPLE_API.Common;
using System.Data.SqlClient;
using System.Data;
using SAMPLE_API.Models.UserDTO;
using SAMPLE_API.Models.RequestDTO;

namespace SAMPLE_API.Business.User
{
    public class UserBUS
    {
        private SqlConnection con;
        private static Connection connection = new Connection();


        public static bool CheckExistUser(string email)
        {
            // check exist user
            if(email == "admin@gmail.com")
            {
                return true;
            }else
            {
                return false;
            }
        }

        //public static UserResponseDTO CreateUser(string email, string password, string timestamp, string signature)
        //{
        //    UserResponseDTO UserResponse = new UserResponseDTO();

        //    // insert user to database
            

        //    // get user info
        //    UserResponse.email = email;
        //    UserResponse.id = GetUserInfo(email).id;

        //    return UserResponse;
        //}

        public static ResponseDTO GetUserInfo(int id)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            UserDTO UserData = new UserDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetUserData";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "ID";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = id;
            cmd.Parameters.Add(param1);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserData.ID = Convert.ToInt16(reader["ID"].ToString());
                        UserData.UserName = reader["username"].ToString();
                        UserData.FirstName = reader["first_name"].ToString();
                        UserData.LastName = reader["last_name"].ToString();
                        UserData.Password = reader["password"].ToString();
                        UserData.Email = reader["email"].ToString();
                        UserData.Role = reader["ROLES"].ToString();
                        UserData.Permission = reader["PERMISSTION"].ToString();
                    }

                    Response.Data = UserData;
                }
                else
                {
                    ErrorResponse.Code = 404;
                    ErrorResponse.Message = "Authenticate Error";
                    Response.Error = ErrorResponse;
                }

                return Response;

            }
            catch (Exception ex)
            {
                Logger.Error("", ex, Level.Error);

                ErrorResponse.Code = 404;
                ErrorResponse.Message = "Authenticate Error";
                Response.Error = ErrorResponse;

                return Response;

            }
            finally
            {
                con.Close();
            }
        }

        public static ResponseDTO GetAllUserInfo(string username, string email, int typeSearch)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<UserDTO> ListUserData = new List<UserDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchLikeUserData";

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
            param2.ParameterName = "Email";
            param2.SqlDbType = SqlDbType.NVarChar;
            if (email != null && email != "")
            {
                param2.Value = email;
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

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserDTO UserData = new UserDTO();
                        UserData.ID = Convert.ToInt16(reader["ID"].ToString());
                        UserData.UserName = reader["username"].ToString();
                        UserData.FirstName = reader["first_name"].ToString();
                        UserData.LastName = reader["last_name"].ToString();
                        UserData.Password = reader["password"].ToString();
                        UserData.Email = reader["email"].ToString();
                        UserData.RoleID = reader["role_id"].ToString();
                        UserData.Role = reader["role_name"].ToString();
                        //UserData.Permission = reader["PERMISSTION"].ToString();
                        ListUserData.Add(UserData);
                    }
                }

                Response.Data = ListUserData.Count() > 0 ? ListUserData : null ;
            }
            catch (Exception ex)
            {
                ErrorResponse.Code = 400;
                ErrorResponse.Message = "Not found";

                Response.Error = ErrorResponse;
            }
            finally
            {
                con.Close();
            }

            return Response;
        }

        public static ResponseDTO GetAllRole()
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<RoleDTO> ListUserData = new List<RoleDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetRole";

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RoleDTO UserData = new RoleDTO();
                        UserData.ID = Convert.ToInt16(reader["ID"].ToString());
                        UserData.RoleName = reader["name"].ToString();
                        UserData.RoleDes = reader["des"].ToString();
                        ListUserData.Add(UserData);
                    }
                }

                Response.Data = ListUserData;
            }
            catch (Exception ex)
            {
                ErrorResponse.Code = 400;
                ErrorResponse.Message = "Not found";

                Response.Error = ErrorResponse;
            }
            finally
            {
                con.Close();
            }

            return Response;
        }

        public static UserDTO CheckUserLogin(string username, string password, int typeSearch)
        {
            UserDTO UserData = new UserDTO();

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
                        UserData.ID = Convert.ToInt16(reader["ID"].ToString());
                        UserData.UserName = reader["username"].ToString();
                        UserData.FirstName = reader["first_name"].ToString();
                        UserData.LastName = reader["last_name"].ToString();
                        UserData.Password = reader["password"].ToString();
                        UserData.Email = reader["email"].ToString();
                        UserData.Role = reader["ROLES"].ToString();
                        UserData.Permission = reader["PERMISSTION"].ToString();
                    }
                }

                return UserData;

            }
            catch (Exception ex)
            {
                Logger.Error("", ex, Level.Error);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static ResponseDTO AddOrUpdateUser(UserRequestDTO userData)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<UserDTO> ListUserData = new List<UserDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = userData.id == null ? "AddUserData" : "UpdateUserData";

            if(userData.id != null)
            {
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "ID";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = userData.id;
                cmd.Parameters.Add(param1);
            }
            else
            {
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "UserName";
                param6.SqlDbType = SqlDbType.NVarChar;
                param6.Value = userData.username;
                cmd.Parameters.Add(param6);
            }

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "FirstName";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = userData.first_name;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "LastName";
            param3.SqlDbType = SqlDbType.NVarChar;
            param3.Value = userData.last_name;
            cmd.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "Password";
            param4.SqlDbType = SqlDbType.NVarChar;
            param4.Value = userData.password;
            cmd.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "Email";
            param5.SqlDbType = SqlDbType.NVarChar;
            param5.Value = userData.email;
            cmd.Parameters.Add(param5);

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "Role";
            param7.SqlDbType = SqlDbType.NVarChar;
            param7.Value = userData.role;
            cmd.Parameters.Add(param7);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Data = userData.id == null ? "CREATED" : "UPDATED";
            }
            catch (Exception ex)
            {
                ErrorResponse.Code = 400;
                ErrorResponse.Message = ex.ToString();
                Response.Error = ErrorResponse;

            }
            finally
            {
                con.Close();
            }

            return Response;
        }
    }
}