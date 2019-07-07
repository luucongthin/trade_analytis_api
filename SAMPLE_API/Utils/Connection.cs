using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Utils
{
    public class Connection
    {
        public SqlConnection conn;
        public SqlConnection loadDB()
        {
            string constr = ConfigurationManager.ConnectionStrings["ToolReport"].ToString();
            conn = new SqlConnection(constr);
            return conn;
        }
        public void open(SqlConnection conn)
        {
            conn.Open();
        }
        public void close(SqlConnection conn)
        {
            conn.Close();
        }
        public double GetNextValueSeq(String seqName)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.loadDB();
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetNextValueSeq";

            cmd.Parameters.Add(new SqlParameter("@Name", seqName));

            //var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            //returnParameter.Direction = ParameterDirection.ReturnValue;

            double count = 0;
            try
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        // read the values from the data reader, e.g.
                        // adapt to match your actual query! You didn't mentioned *what columns*
                        // are being returned, and what data type they are
                        count = rdr.GetInt64(0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return count;
        }
    }
}