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
using System.Xml.Linq;

namespace SAMPLE_API.Business.General
{
    public class LegislationBUS
    {
        private SqlConnection con;
        private static Connection connection = new Connection();


        public static ResponseDTO GetAllLegislation(string start_date, string end_date, string category_code, int page, int size)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<LegislationDTO> ListLegislationData = new List<LegislationDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchLegislationData";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "CategoryCode";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = category_code;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "StartDate";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = start_date;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "EndDate";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = end_date;
            cmd.Parameters.Add(param3);

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "Page";
            param6.SqlDbType = SqlDbType.Int;
            param6.Value = page;
            cmd.Parameters.Add(param6);

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
                        LegislationDTO LegislationData = new LegislationDTO();

                        LegislationData.ID = reader["ID"].ToString();
                        LegislationData.Title = reader["title"].ToString();
                        LegislationData.Description = reader["description"].ToString();
                        LegislationData.Summary = reader["summary"].ToString();
                        LegislationData.StartDate = reader["start_date"].ToString();
                        LegislationData.EndDate = reader["end_date"].ToString();
                        LegislationData.CategoryCode = reader["category_code"].ToString();
                        LegislationData.Reporter = reader["reporter"].ToString();
                        LegislationData.ImplementingAuthority = reader["implementing_authority"].ToString();
                        LegislationData.IsImportingCountry = reader["is_importing_country"].ToString();
                        LegislationData.Agency = reader["agency"].ToString();

                        ListLegislationData.Add(LegislationData);

                        ErrorResponse.Code = Convert.ToInt64(reader["Total"].ToString());
                    }
                }
                
                if (ListLegislationData.Count != 0)
                {
                    Response.Data = ListLegislationData;
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

        public static ResponseDTO GetReporterData(string name)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<ReporterDTO> ListLegislationData = new List<ReporterDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchReporterData";

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
                        ReporterDTO ReporterData = new ReporterDTO();

                        ReporterData.Code = reader["reporter_code"].ToString();
                        ReporterData.Name = reader["reporter"].ToString();

                        ListLegislationData.Add(ReporterData);

                        //ErrorResponse.Code = Convert.ToInt64(reader["Total"].ToString());
                    }
                }

                if (ListLegislationData.Count != 0)
                {
                    Response.Data = ListLegislationData;
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

        public static ResponseDTO GetMeansuer(string category_code, string reporter, string product, int page, int size)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<MeansuerDTO> ListMeansuerData = new List<MeansuerDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetMeansuer";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "CategoryCode";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = category_code;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "Reporter";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = reporter;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "Product";
            param3.SqlDbType = SqlDbType.NVarChar;
            param3.Value = product;
            cmd.Parameters.Add(param3);

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "Page";
            param6.SqlDbType = SqlDbType.Int;
            param6.Value = page;
            cmd.Parameters.Add(param6);

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
                        MeansuerDTO MeansuerData = new MeansuerDTO();

                        MeansuerData.ID = reader["ID"].ToString();
                        MeansuerData.Reporter = reader["reporter"].ToString();
                        MeansuerData.ReporterCode = reader["reporter_code"].ToString();
                        MeansuerData.Partner = reader["partner"].ToString();
                        MeansuerData.PartnerCode = reader["partner_code"].ToString();
                        MeansuerData.PartnerComment = reader["partner_comment"].ToString();
                        MeansuerData.ProductCode = reader["product_code"].ToString();
                        MeansuerData.ProductCoverage = reader["product_coverage"].ToString();
                        MeansuerData.HSRevision = reader["hs_revision"].ToString();
                        MeansuerData.ProductComment = reader["product_comment"].ToString();
                        MeansuerData.NTMCode = reader["ntm_code"].ToString();
                        MeansuerData.NTMRevision = reader["ntm_revision"].ToString();
                        MeansuerData.NTMComment = reader["ntm_comment"].ToString();
                        MeansuerData.CategoryCode = reader["category_code"].ToString();

                        ListMeansuerData.Add(MeansuerData);

                        ErrorResponse.Code = Convert.ToInt64(reader["Total"].ToString());
                    }
                }

                if (ListMeansuerData.Count != 0)
                {
                    Response.Data = ListMeansuerData;
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

        public static ResponseDTO GetMeansuerBP(string category_code, string reporter, string product, int page, int size)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<MeansuerBPDTO> ListMeansuerBPData = new List<MeansuerBPDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetMeansuerBP";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "CategoryCode";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = category_code;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "Reporter";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = reporter;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "Product";
            param3.SqlDbType = SqlDbType.NVarChar;
            param3.Value = product;
            cmd.Parameters.Add(param3);

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "Page";
            param6.SqlDbType = SqlDbType.Int;
            param6.Value = page;
            cmd.Parameters.Add(param6);

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
                        MeansuerBPDTO MeansuerBPData = new MeansuerBPDTO();

                        MeansuerBPData.Code = reader["code"].ToString();
                        MeansuerBPData.Sum = reader["sums"].ToString();

                        ListMeansuerBPData.Add(MeansuerBPData);
                    }
                }

                if (ListMeansuerBPData.Count != 0)
                {
                    Response.Data = ListMeansuerBPData;
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

        public static ResponseDTO GetLegislation(string category_code, string reporter, int page, int size)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<LegislationDTO> ListLegislationData = new List<LegislationDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetLegislation";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "CategoryCode";
            param1.SqlDbType = SqlDbType.NVarChar;
            param1.Value = category_code;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "Reporter";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = reporter;
            cmd.Parameters.Add(param2);

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "Page";
            param6.SqlDbType = SqlDbType.Int;
            param6.Value = page;
            cmd.Parameters.Add(param6);

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
                        LegislationDTO LegislationData = new LegislationDTO();

                        LegislationData.ID = reader["ID"].ToString();
                        LegislationData.Title = reader["title"].ToString();
                        LegislationData.Description = reader["description"].ToString();
                        LegislationData.Summary = reader["summary"].ToString();
                        LegislationData.StartDate = reader["start_date"].ToString();
                        LegislationData.EndDate = reader["end_date"].ToString();
                        LegislationData.CategoryCode = reader["category_code"].ToString();
                        LegislationData.Reporter = reader["reporter"].ToString();
                        LegislationData.ImplementingAuthority = reader["implementing_authority"].ToString();
                        LegislationData.IsImportingCountry = reader["is_importing_country"].ToString();
                        LegislationData.Agency = reader["agency"].ToString();

                        ListLegislationData.Add(LegislationData);

                        ErrorResponse.Code = Convert.ToInt64(reader["Total"].ToString());
                        ErrorResponse.Message = reader["Total_U"].ToString();
                    }
                }

                if (ListLegislationData.Count != 0)
                {
                    Response.Data = ListLegislationData;
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

        public static ResponseDTO GetAllLegislationByID(int id)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();
            List<LegislationDTO> ListLegislationData = new List<LegislationDTO>();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SearchLegislationDataByID";

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
                        LegislationDTO LegislationData = new LegislationDTO();

                        LegislationData.ID = reader["ID"].ToString();
                        LegislationData.Title = reader["title"].ToString();
                        LegislationData.Description = reader["description"].ToString();
                        LegislationData.Summary = reader["summary"].ToString();
                        LegislationData.StartDate = reader["start_date"].ToString();
                        LegislationData.EndDate = reader["end_date"].ToString();
                        LegislationData.CategoryCode = reader["category_code"].ToString();
                        LegislationData.Reporter = reader["reporter"].ToString();
                        LegislationData.ImplementingAuthority = reader["implementing_authority"].ToString();
                        LegislationData.IsImportingCountry = reader["is_importing_country"].ToString();
                        LegislationData.Agency = reader["agency"].ToString();
                        

                        ListLegislationData.Add(LegislationData);
                    }
                }

                Response.Data = ListLegislationData;
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

        public static ResponseDTO AddOrUpdateLegislation(LegislationRequestDTO LegislationData)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = LegislationData.id == null ? "AddLegislationData" : "UpdateLegislationData";

            if (LegislationData.id != null)
            {
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "ID";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = LegislationData.id;
                cmd.Parameters.Add(param1);
            }

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "Title";
            param6.SqlDbType = SqlDbType.NVarChar;
            param6.Value = LegislationData.title != "" ? LegislationData.title : "";
            cmd.Parameters.Add(param6);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "Description";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.Value = LegislationData.description != "" ? LegislationData.description : "";
            cmd.Parameters.Add(param2);

            SqlParameter param10 = new SqlParameter();
            param10.ParameterName = "Summary";
            param10.SqlDbType = SqlDbType.NVarChar;
            param10.Value = LegislationData.summary != "" ? LegislationData.summary : "";
            cmd.Parameters.Add(param10);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "StartDate";
            param3.SqlDbType = SqlDbType.VarChar;
            param3.Value = LegislationData.start_date != "" ? LegislationData.start_date : "";
            cmd.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "EndDate";
            param4.SqlDbType = SqlDbType.VarChar;
            param4.Value = LegislationData.end_date != "" ? LegislationData.end_date : "";
            cmd.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "CategoryCode";
            param5.SqlDbType = SqlDbType.NChar;
            param5.Value = LegislationData.category_code != "" ? LegislationData.category_code : "";
            cmd.Parameters.Add(param5);

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "Reporter";
            param7.SqlDbType = SqlDbType.NChar;
            param7.Value = LegislationData.reporter != "" ? LegislationData.reporter : "";
            cmd.Parameters.Add(param7);

            SqlParameter param9 = new SqlParameter();
            param9.ParameterName = "ImplementingAuthority";
            param9.SqlDbType = SqlDbType.NVarChar;
            param9.Value = LegislationData.implementing_authority != "" ? LegislationData.implementing_authority : "";
            cmd.Parameters.Add(param9);

            SqlParameter param11 = new SqlParameter();
            param11.ParameterName = "IsImportingCountry";
            param11.SqlDbType = SqlDbType.Int;
            param11.Value = LegislationData.is_importing_country != "" ? LegislationData.is_importing_country : "";
            cmd.Parameters.Add(param11);

            SqlParameter param12 = new SqlParameter();
            param12.ParameterName = "Agency";
            param12.SqlDbType = SqlDbType.NChar;
            param12.Value = LegislationData.agency != "" ? LegislationData.agency : "";
            cmd.Parameters.Add(param12);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Data = LegislationData.id == null ? "CREATED" : "UPDATED";
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

        public static ResponseDTO ImportLegislation(XElement LegislationData)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ImportLegislation";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "Data";
            param1.SqlDbType = SqlDbType.Xml;
            param1.Value = new SqlXml(LegislationData.CreateReader());
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


        public static ResponseDTO ImportNTM(XElement NTMData)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ImportNTM";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "Data";
            param1.SqlDbType = SqlDbType.Xml;
            param1.Value = new SqlXml(NTMData.CreateReader());
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

        public static ResponseDTO DeleteLegislation(int id)
        {
            ErrorDTO ErrorResponse = new ErrorDTO();
            ResponseDTO Response = new ResponseDTO();

            SqlConnection con = connection.loadDB();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteLegislationData";

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