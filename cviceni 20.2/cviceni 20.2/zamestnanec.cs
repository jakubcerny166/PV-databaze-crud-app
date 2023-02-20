using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cviceni_20._2
{
    public class zamestnanec
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public int id { get; set; }
        public string jmeno { get; set; }
        public int vek { get; set; }
        public DateTime datum { get; set; }

        private const string SelectQuery = "Select * from zam";
        private const string InsertQuery = "Insert Into zam(jmeno, vek, datum) Values (@jmeno, @vek, @datum)";
        private const string UpdateQuery = "Update zam set jmeno=@jmeno, vek=@vek, datum=@datum";
        private const string DeleteQuery = "Delete from zam where zam.id=@id";


        public bool InsertEmployee(zamestnanec zam)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@jmeno", zam.jmeno);
                    com.Parameters.AddWithValue("@vek", zam.vek);
                    com.Parameters.AddWithValue("@datum", zam.datum);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public bool UpdateEmployee(zamestnanec zam)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@jmeno", zam.jmeno);
                    com.Parameters.AddWithValue("@vek", zam.vek);
                    com.Parameters.AddWithValue("@datum", zam.datum);
             
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public bool DeleteEmployee(zamestnanec zam)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@id", zam.id);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public DataTable GetEmployees()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
    }
}
