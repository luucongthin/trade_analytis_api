using SAMPLE_API.Common;
using SAMPLE_API.Models.General;
using SAMPLE_API.Models.RequestDTO;
using SAMPLE_API.Models.ResponseDTO;
using SAMPLE_API.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SAMPLE_API.Business.General
{
    public class StoreBUS
    {
        private SqlConnection con;
        private static Connection connection = new Connection();


        public static ResponseDTO GetAllStore(string name, string category_code, string address, string ward_code, int page, int size)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<StoreDTO> ListStoreData = new List<StoreDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchStoreData";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "Name";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = name;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "CategoryCode";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = category_code;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "Adress";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = address;
            cmd.Parameters.Add(param3);

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "WardCode";
            param6.SqlDbType = SqlDbType.VarChar;
            param6.Value = ward_code;
            cmd.Parameters.Add(param6);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "Page";
            param4.SqlDbType = SqlDbType.Int;
            param4.Value = page;
            cmd.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "Size";
            param5.SqlDbType = SqlDbType.Int;
            param5.Value = size;
            cmd.Parameters.Add(param5);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StoreDTO StoreData = new StoreDTO();

                        StoreData.ID = reader["ID"].ToString();
                        StoreData.WardCode = reader["ward_code"].ToString();
                        StoreData.Code = reader["code"].ToString();
                        StoreData.Type = reader["type"].ToString();
                        StoreData.Adress = reader["adress"].ToString();
                        StoreData.CategoryCode = reader["category_code"].ToString();
                        StoreData.Latitude = reader["latitude"].ToString();
                        StoreData.Longitude = reader["longitude"].ToString();
                        StoreData.Information = reader["information"].ToString();
                        StoreData.Name = reader["name"].ToString();
                        StoreData.Note = reader["note"].ToString();

                        ListStoreData.Add(StoreData);

                        ErrorResponse.Code = Convert.ToInt64(reader["Total"].ToString());
                    }
                }

                if(ListStoreData.Count != 0)
                {
                    Response.Data = ListStoreData;
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


        public static ResponseDTO GetAllStoreFront(string category_code, string city_code, string district_code, string ward_code, int page, int size)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<StoreDTO> ListStoreData = new List<StoreDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchStoreFrontData";

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "CategoryCode";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = category_code;
            cmd.Parameters.Add(param2);

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "WardCode";
            param6.SqlDbType = SqlDbType.VarChar;
            param6.Value = ward_code;
            cmd.Parameters.Add(param6);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "CityCode";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = city_code;
            cmd.Parameters.Add(param3);

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "DistrictCode";
            param7.SqlDbType = SqlDbType.VarChar;
            param7.Value = district_code;
            cmd.Parameters.Add(param7);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "Page";
            param4.SqlDbType = SqlDbType.Int;
            param4.Value = page;
            cmd.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "Size";
            param5.SqlDbType = SqlDbType.Int;
            param5.Value = size;
            cmd.Parameters.Add(param5);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StoreDTO StoreData = new StoreDTO();

                        StoreData.ID = reader["ID"].ToString();
                        StoreData.WardCode = reader["ward_code"].ToString();
                        StoreData.Code = reader["code"].ToString();
                        StoreData.Type = reader["type"].ToString();
                        StoreData.Adress = reader["adress"].ToString();
                        StoreData.CategoryCode = reader["category_code"].ToString();
                        StoreData.Latitude = reader["latitude"].ToString();
                        StoreData.Longitude = reader["longitude"].ToString();
                        StoreData.Information = reader["information"].ToString();
                        StoreData.Name = reader["name"].ToString();
                        StoreData.Note = reader["note"].ToString();

                        ListStoreData.Add(StoreData);

                        ErrorResponse.Code = Convert.ToInt64(reader["Total"].ToString());
                    }
                }

                if (ListStoreData.Count != 0)
                {
                    Response.Data = ListStoreData;
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

        public static ResponseDTO CountStore(string category_code, string city_code, string district_code, string ward_code, int page, int size)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<CountStoreDTO> ListStoreData = new List<CountStoreDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "CountStoreData";

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "CategoryCode";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = category_code;
            cmd.Parameters.Add(param2);

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "WardCode";
            param6.SqlDbType = SqlDbType.VarChar;
            param6.Value = ward_code;
            cmd.Parameters.Add(param6);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "CityCode";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = city_code;
            cmd.Parameters.Add(param3);

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "DistrictCode";
            param7.SqlDbType = SqlDbType.VarChar;
            param7.Value = district_code;
            cmd.Parameters.Add(param7);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "Page";
            param4.SqlDbType = SqlDbType.Int;
            param4.Value = page;
            cmd.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "Size";
            param5.SqlDbType = SqlDbType.Int;
            param5.Value = size;
            cmd.Parameters.Add(param5);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CountStoreDTO counta = new CountStoreDTO();
                        counta.CT = reader["CT"].ToString();
                        counta.Total = reader["Total"].ToString();
                        counta.City = reader["City"].ToString();
                        counta.District = reader["District"].ToString();
                        counta.Ward = reader["Ward"].ToString();

                        ListStoreData.Add(counta);
                    }
                }

                Response.Data = ListStoreData;
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


        public static ResponseDTO GetStoreByID(int id)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<StoreDTO> ListStoreData = new List<StoreDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchStoreDataByID";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "ID";
            param1.SqlDbType = SqlDbType.Int;
            param1.Value = id;
            cmd.Parameters.Add(param1);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StoreDTO StoreData = new StoreDTO();

                        StoreData.ID = reader["ID"].ToString();
                        StoreData.WardCode = reader["ward_code"].ToString();
                        StoreData.Code = reader["code"].ToString();
                        StoreData.Type = reader["type"].ToString();
                        StoreData.Adress = reader["adress"].ToString();
                        StoreData.CategoryCode = reader["category_code"].ToString();
                        StoreData.Latitude = reader["latitude"].ToString();
                        StoreData.Longitude = reader["longitude"].ToString();
                        StoreData.Information = reader["information"].ToString();
                        StoreData.Name = reader["name"].ToString();
                        StoreData.Note = reader["note"].ToString();

                        ListStoreData.Add(StoreData);
                    }
                }

                Response.Data = ListStoreData;
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

        public static ResponseDTO AddOrUpdateStore(StoreRequestDTO StoreData)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = StoreData.id == null ? "AddStoreData" : "UpdateStoreData";

            if (StoreData.id != null)
            {
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "ID";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = StoreData.id;
                cmd.Parameters.Add(param1);
            }

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "WardCode";
            param6.SqlDbType = SqlDbType.NVarChar;
            param6.Value = StoreData.ward_code != "" ? StoreData.ward_code : "";
            cmd.Parameters.Add(param6);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "Code";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = StoreData.code != "" ? StoreData.code : "";
            cmd.Parameters.Add(param2);

            SqlParameter param10 = new SqlParameter();
            param10.ParameterName = "Adress";
            param10.SqlDbType = SqlDbType.NVarChar;
            param10.Value = StoreData.adress != "" ? StoreData.adress : "";
            cmd.Parameters.Add(param10);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "Name";
            param3.SqlDbType = SqlDbType.NVarChar;
            param3.Value = StoreData.name != "" ? StoreData.name : "";
            cmd.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "Information";
            param4.SqlDbType = SqlDbType.NVarChar;
            param4.Value = StoreData.information != "" ? StoreData.information : "";
            cmd.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "Latitude";
            param5.SqlDbType = SqlDbType.NVarChar;
            param5.Value = StoreData.latitude != "" ? StoreData.latitude : "";
            cmd.Parameters.Add(param5);

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "Longitude";
            param7.SqlDbType = SqlDbType.NVarChar;
            param7.Value = StoreData.longitude != "" ? StoreData.longitude : "";
            cmd.Parameters.Add(param7);

            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "Note";
            param8.SqlDbType = SqlDbType.NChar;
            param8.Value = StoreData.note != "" ? StoreData.note : "";
            cmd.Parameters.Add(param8);

            SqlParameter param9 = new SqlParameter();
            param9.ParameterName = "Type";
            param9.SqlDbType = SqlDbType.NChar;
            param9.Value = StoreData.type != "" ? StoreData.type : "";
            cmd.Parameters.Add(param9);

            SqlParameter param11= new SqlParameter();
            param11.ParameterName = "CategoryCode";
            param11.SqlDbType = SqlDbType.NChar;
            param11.Value = StoreData.category_code != "" ? StoreData.category_code : "";
            cmd.Parameters.Add(param11);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Data = StoreData.id == null ? "CREATED" : "UPDATED";
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


        public static ResponseDTO ImportStore(XElement StoreData)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ImportStore";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "Data";
            param1.SqlDbType = SqlDbType.Xml;
            param1.Value = new SqlXml(StoreData.CreateReader());
            cmd.Parameters.Add(param1);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Data = "IMPORTED";
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

        public static ResponseDTO DeleteStore(int id)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteStoreData";

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