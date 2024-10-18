using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace rku_system
{
    public class DB
    {
        SqlConnection conn;
        SqlCommand cmd;
        protected void dbconn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
    }
}