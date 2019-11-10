using SAMPLE_API.Common;
using SAMPLE_API.Models.General;
using SAMPLE_API.Models.RequestDTO;
using SAMPLE_API.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SAMPLE_API.Business.General
{

    public class CategoryBUS
    {

        private SqlConnection con;                  
        private static Connection connection = new Connection();

        public static ResponseDTO GetAllCategory(string name, string title, string code)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<CategoryDTO> ListCategoryData = new List<CategoryDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchCategoryData";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "Name";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = name;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "Title";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = title;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "Code";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = code;
            cmd.Parameters.Add(param3);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CategoryDTO CategoryData = new CategoryDTO();
                        CategoryData.ID = Convert.ToInt16(reader["ID"].ToString());
                        CategoryData.Name = reader["name"].ToString();
                        CategoryData.Title = reader["title"].ToString();
                        CategoryData.Code = reader["code"].ToString();
                        ListCategoryData.Add(CategoryData);
                    }
                }

                Response.Data = ListCategoryData;
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

        public static ResponseDTO AddOrUpdateCategory(CategoryRequestDTO categoryData)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = categoryData.id == null ? "AddCategoryData" : "UpdateCategoryData";

            if (categoryData.id != null)
            {
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "ID";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = categoryData.id;
                cmd.Parameters.Add(param1);
            }

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "Name";
            param6.SqlDbType = SqlDbType.NVarChar;
            param6.Value = categoryData.name != "" ? categoryData.name : "";
            cmd.Parameters.Add(param6);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "Title";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = categoryData.title != "" ? categoryData.title : "";
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "Code";
            param3.SqlDbType = SqlDbType.NVarChar;
            param3.Value = categoryData.code != "" ? categoryData.code : "";
            cmd.Parameters.Add(param3);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Data = categoryData.id == null ? "CREATED" : "UPDATED";
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

        public static ResponseDTO DeleteCategory(int id)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteCategoryData";
            
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "ID";
            param1.SqlDbType = SqlDbType.Int;
            param1.Value = id;
            cmd.Parameters.Add(param1);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Data = "DELETED";
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