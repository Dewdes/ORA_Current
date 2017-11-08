using System;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class AccountDAL
    {

        public static void DeleteEmployeeRecords(long emp_ID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_EMPLOYEE_RECORDS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", emp_ID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                //Write to error log
                throw ex;
            }
        }
    }
}
