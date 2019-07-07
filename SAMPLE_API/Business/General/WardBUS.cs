using SAMPLE_API.Common;
using SAMPLE_API.Models.General;
using SAMPLE_API.Models.RequestDTO;
using SAMPLE_API.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace SAMPLE_API.Business.General
{
    public class WardBUS
    {
        private SqlConnection con;
        private static Connection connection = new Connection();


        public static ResponseDTO GetAllWard(string city_code, string district_code, string ward_name, int page, int size)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<WardDTO> ListWardData = new List<WardDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchWardData";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "CityCode";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = city_code;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "DistrictCode";
            param2.SqlDbType = SqlDbType.VarChar;
            param2.Value = district_code;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "WardName";
            param3.SqlDbType = SqlDbType.NVarChar;
            param3.Value = ward_name;
            cmd.Parameters.Add(param3);


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
                        WardDTO WardData = new WardDTO();

                        WardData.ID = Convert.ToInt64(reader["ID"].ToString());
                        WardData.WardCode = reader["ward_code"].ToString();
                        WardData.WardName = reader["ward_name"].ToString();
                        WardData.Type = reader["type"].ToString();
                        WardData.DistrictCode = reader["district_code"].ToString();
                        WardData.DistrictName = reader["district_name"].ToString();
                        WardData.CityCode = reader["city_code"].ToString();
                        WardData.CityName = reader["city_name"].ToString();
                        WardData.Population = Convert.ToInt64(reader["population"].ToString());
                        WardData.Area = Convert.ToInt64(reader["area"].ToString());
                        WardData.CreateAt = reader["create_at"].ToString();
                        WardData.UpdateAt = reader["update_at"].ToString();

                        ListWardData.Add(WardData);

                        ErrorResponse.Code = Convert.ToInt64(reader["Total"].ToString());
                    }
                }

                Response.Data = ListWardData;
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


        public static ResponseDTO GetWardByID(int id)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<WardDTO> ListWardData = new List<WardDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchWardDataByID";

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
                        WardDTO WardData = new WardDTO();

                        WardData.ID = Convert.ToInt16(reader["ID"].ToString());
                        WardData.WardCode = reader["ward_code"].ToString();
                        WardData.WardName = reader["ward_name"].ToString();
                        WardData.Type = reader["type"].ToString();
                        WardData.DistrictCode = reader["district_code"].ToString();
                        WardData.DistrictName = reader["district_name"].ToString();
                        WardData.CityCode = reader["city_code"].ToString();
                        WardData.CityName = reader["city_name"].ToString();
                        WardData.Population = Convert.ToInt64(reader["population"].ToString());
                        WardData.Area = Convert.ToInt64(reader["area"].ToString());
                        WardData.CreateAt = reader["create_at"].ToString();
                        WardData.UpdateAt = reader["update_at"].ToString();

                        ListWardData.Add(WardData);
                    }
                }

                Response.Data = ListWardData;
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


        public static ResponseDTO GetCity(string city_name)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<CityDTO> ListCityData = new List<CityDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchCityData";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "CityName";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = city_name;
            cmd.Parameters.Add(param1);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CityDTO CityData = new CityDTO();


                        CityData.CityCode = reader["city_code"].ToString();
                        CityData.CityName = reader["city_name"].ToString();

                        ListCityData.Add(CityData);
                    }
                }

                Response.Data = ListCityData;
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

        public static ResponseDTO GetDistrict(string city_code, string district_name)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<DistrictDTO> ListDistrictData = new List<DistrictDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchDistrictData";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "CityCode";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = city_code;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "DistrictName";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = district_name;
            cmd.Parameters.Add(param2);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DistrictDTO DistrictData = new DistrictDTO();

                        DistrictData.DistrictCode = reader["district_code"].ToString();
                        DistrictData.DistrictName = reader["district_name"].ToString();

                        ListDistrictData.Add(DistrictData);
                    }
                }

                Response.Data = ListDistrictData;
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

        public static ResponseDTO ImportWard(XElement WardData)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ImportWard";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "Data";
            param1.SqlDbType = SqlDbType.Xml;
            param1.Value = new SqlXml(WardData.CreateReader());
            cmd.Parameters.Add(param1);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Data ="IMPORTED";
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

        public static ResponseDTO AddOrUpdateWard(WardRequestDTO WardData)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = WardData.id == null ? "AddWardData" : "UpdateWardData";

            if (WardData.id != null)
            {
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "ID";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = WardData.id;
                cmd.Parameters.Add(param1);
            }

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "WardCode";
            param6.SqlDbType = SqlDbType.NVarChar;
            param6.Value = WardData.ward_code != "" ? WardData.ward_code : "";
            cmd.Parameters.Add(param6);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "WardName";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = WardData.ward_name != "" ? WardData.ward_name : "";
            cmd.Parameters.Add(param2);

            SqlParameter param10 = new SqlParameter();
            param10.ParameterName = "Type";
            param10.SqlDbType = SqlDbType.NVarChar;
            param10.Value = WardData.type != "" ? WardData.type : "";
            cmd.Parameters.Add(param10);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "DistrictCode";
            param3.SqlDbType = SqlDbType.NVarChar;
            param3.Value = WardData.district_code != "" ? WardData.district_code : "";
            cmd.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "DistrictName";
            param4.SqlDbType = SqlDbType.NVarChar;
            param4.Value = WardData.district_name != "" ? WardData.district_name : "";
            cmd.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "CityCode";
            param5.SqlDbType = SqlDbType.NVarChar;
            param5.Value = WardData.city_code != "" ? WardData.city_code : "";
            cmd.Parameters.Add(param5);

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "CityName";
            param7.SqlDbType = SqlDbType.NVarChar;
            param7.Value = WardData.city_name != "" ? WardData.city_name : "";
            cmd.Parameters.Add(param7);

            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "Population";
            param8.SqlDbType = SqlDbType.NChar;
            param8.Value = WardData.population != "" ? WardData.population : "";
            cmd.Parameters.Add(param8);

            SqlParameter param9 = new SqlParameter();
            param9.ParameterName = "Area";
            param9.SqlDbType = SqlDbType.NChar;
            param9.Value = WardData.area != "" ? WardData.area : "";
            cmd.Parameters.Add(param9);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Data = WardData.id == null ? "CREATED" : "UPDATED";
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

        public static ResponseDTO DeleteWard(int id)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteWardData";

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