using System.Configuration;
using System.Data.SqlClient;

namespace ORA_Data
{
    public class SqlConnect
    {
        public static SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
    }
}
