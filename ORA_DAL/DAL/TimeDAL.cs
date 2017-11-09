using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class TimeDAL
    {

        #region TIME DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();

        /// <summary>
        /// CreateTime: On employee creation this is called to create a basic employee time (think PTO and OTO)
        /// Uses the CREATE_EMPLOYEE_TIME stored procedure
        /// </summary>
        /// <param name="time"></param>
        public static void CreateTime(EmployeeTimeDM time)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_EMPLOYEE_TIME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Other_Total", time.Other_Total);
                    cmd.Parameters.AddWithValue("@Other_Available", time.Other_Available);
                    cmd.Parameters.AddWithValue("@Other_Used", time.Other_Used);
                    cmd.Parameters.AddWithValue("@Payed_Total", time.Payed_Total);
                    cmd.Parameters.AddWithValue("@Payed_Available", time.Payed_Available);
                    cmd.Parameters.AddWithValue("@Payed_Used", time.Payed_Used);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("ReadAllAddress", DateTime.Now, e.Message);
                throw e;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        public static void CreateEmptyTime(long employeeId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_EMPTY_EMPLOYEE_TIME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", employeeId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateEmptyTime", DateTime.Now, e.Message);
                throw e;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Reads all times for employees. Could be used in the future to see cumulative times accrued by all employees.
        /// Uses the READ_ALL_TIME stored procedure
        /// </summary>
        /// <returns></returns>
        public static List<EmployeeTimeDM> ReadAllTime()
        {
            List<EmployeeTimeDM> timeList = new List<EmployeeTimeDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_ALL_TIME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return (timeList);
                        while (reader.Read())
                        {
                            var time = new EmployeeTimeDM
                            {
                                Time_ID = (Int64)reader["Time_ID"],
                                Other_Total = (decimal)reader["Other_Total"],
                                Other_Available = (decimal)reader["Other_Available"],
                                Other_Used = (decimal)reader["Other_Used"],
                                Payed_Total = (decimal)reader["Payed_Total"],
                                Payed_Available = (decimal)reader["Payed_Available"],
                                Payed_Used = (decimal)reader["Payed_Used"]
                            };
                            timeList.Add(time);
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (timeList);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadAllTime", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// ReadTimeByID: Reads times for the where the timeID matches the timeID in the database
        /// Uses the READ_TIME_BY_ID stored procedure
        /// </summary>
        /// <param name="timeId"></param>
        /// <returns></returns>
        public static EmployeeTimeDM ReadTimeByID(string timeId)
        {
            try
            {
                EmployeeTimeDM time = new EmployeeTimeDM();
                using (SqlCommand cmd = new SqlCommand("READ_TIME_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Time_ID", timeId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return (time);
                        while (reader.Read())
                        {
                            time.Time_ID = (Int64)reader["Time_ID"];
                            time.Other_Total = (decimal)reader["Other_Total"];
                            time.Other_Available = (decimal)reader["Other_Available"];
                            time.Other_Used = (decimal)reader["Other_Used"];
                            time.Payed_Total = (decimal)reader["Payed_Total"];
                            time.Payed_Available = (decimal)reader["Payed_Available"];
                            time.Payed_Used = (decimal)reader["Payed_Used"];
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (time);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadTimeById", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// UpdateTime: Updates the time for a given employee
        /// Uses the UPDATE_EMPLOYEE_TIME stored procedure
        /// </summary>
        /// <param name="time"></param>
        public static void UpdateTime(EmployeeTimeDM time)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_EMPLOYEE_TIME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Time_ID", time.Time_ID);
                    cmd.Parameters.AddWithValue("@Other_Total", time.Other_Total);
                    cmd.Parameters.AddWithValue("@Other_Available", time.Other_Available);
                    cmd.Parameters.AddWithValue("@Other_Used", time.Other_Used);
                    cmd.Parameters.AddWithValue("@Payed_Total", time.Payed_Total);
                    cmd.Parameters.AddWithValue("@Payed_Available", time.Payed_Available);
                    cmd.Parameters.AddWithValue("@Payed_Used", time.Payed_Used);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateTime", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// DeleteTime: Deletes Time for an employee
        /// Uses the DELETE_TIME stored procedure
        /// </summary>
        /// <param name="time"></param>
        public static void DeleteTime(EmployeeTimeDM time)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_TIME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Time_ID", time.Time_ID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("DeleteTime", DateTime.Now, ex.Message);
                //Write to error log
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }
        #endregion
    }
}

