using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace regpol
{
    public class SqlFasade
    {
        private SqlConnection con;
        private Dictionary<string, string[]> tables = new Dictionary<string, string[]> () 
        { 
           
        };

        public SqlFasade(string connection)
        {
            con = new SqlConnection(connection);
        }

        public SqlFasade(SqlConnectionStringBuilder connection)
        {
            con = new SqlConnection(connection.ConnectionString); 
        }

        private bool Exec(SqlCommand com)
        {
            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception) { }
            return false;
        }
        public bool TestConnection()
        {
            SqlCommand com = con.CreateCommand();
            com.CommandText = "SELECT * FROM information_schema.tables";
            return Exec(com);
        }

        public List<string> GetTableCol(string table, string ColomnName = "id")
        {
            List<string> list = new List<string>();
            SqlCommand com = con.CreateCommand();
            com.CommandText = $"Select * from {table}";
            try
            {
                con.Open();
                using (SqlDataReader oReader = com.ExecuteReader())
                {
                    while(oReader.Read())
                    {
                        list.Add(oReader[ColomnName].ToString());
                    }
                }
                con.Close();
            }
            catch (Exception) { }
            return list;
        }

        private bool DelRow(string table, string wher, string val)
        {
            SqlCommand com = con.CreateCommand();
            com.CommandText = $"DELETE FROM {table} WHERE {wher}=@id";
            com.Parameters.AddWithValue("@id", val);
            return Exec(com);
        }
        
        public DataSet GetDataSet(string db)
        {
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                new SqlDataAdapter($"SELECT * FROM {db}", con).Fill(ds);
                con.Close();
            }
            catch (Exception) { }
            return ds;
        }
    }
}
