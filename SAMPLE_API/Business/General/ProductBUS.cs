using SAMPLE_API.Common;
using SAMPLE_API.Models.General;
using SAMPLE_API.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Business.General
{
    public class ProductBUS
    {
        private SqlConnection con;
        private static Connection connection = new Connection();


        public static ResponseDTO GetAllProduct(string name)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<ProductDTO> ListProductData = new List<ProductDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchProductData";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "Name";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = name;
            cmd.Parameters.Add(param1);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductDTO ProductData = new ProductDTO();

                        ProductData.Code = reader["code"].ToString();
                        ProductData.Name = reader["name"].ToString();

                        ListProductData.Add(ProductData);

                        //ErrorResponse.Code = Convert.ToInt64(reader["Total"].ToString());
                    }
                }

                if (ListProductData.Count != 0)
                {
                    Response.Data = ListProductData;
                }
                else
                {
                    Response.Data = null;
                }
                Response.Error = ErrorResponse;
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