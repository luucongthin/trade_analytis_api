using SAMPLE_API.Common;
using SAMPLE_API.Models.General;
using SAMPLE_API.Models.RequestDTO;
using SAMPLE_API.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Business.General
{

    public class CrawBUS
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
            SqlCommand cmd = new SqlCommand("SearchCategoryData", con, null);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("Name", SqlDbType.NVarChar, 0, name);
            cmd.Parameters.Add("Title", SqlDbType.NVarChar, 0, title);
            cmd.Parameters.Add("Code", SqlDbType.NVarChar, 0, code);

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

    }
}