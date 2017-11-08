using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class Work_StatusDAL
    {
       
        #region STATUS DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();

        /// <summary>
        /// CreateStatus: Creates a work status for the employee when a new employee is created. Can be updated to reflect the current or former employees working status
        /// Uses the CREATE_WORK_STATUS stored procedure
        /// </summary>
        /// <param name="_status"></param>
        /// <param name="empID"></param>
        public static void CreateStatus(StatusDM _status, long empID)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_WORK_STATUS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", empID);
                    cmd.Parameters.AddWithValue("@Employee_Status", _status.EmployeeStatus);
                    cmd.Parameters.AddWithValue("@Hire_Date", _status.HireDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Pay_Type", _status.PayType);
                    cmd.Parameters.AddWithValue("@Service_Length", _status.ServiceLength);
                    cmd.Parameters.AddWithValue("@Employment_Type", _status.EmploymentType);
                    cmd.Parameters.AddWithValue("@Office_Location", _status.OfficeLocation);
                    cmd.Parameters.AddWithValue("@Termination_Date", _status.TerminationDate.ToShortDateString());
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateWorkStatus", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// ReadAllStatus: Reads all the working status's for all current and former employees.
        /// Uses the READ_WORK_STATUS stored procedure
        /// </summary>
        /// <returns></returns>
        public static List<StatusDM> ReadAllStatus()
        {
            List<StatusDM> customerList = new List<StatusDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_WORK_STATUS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var _status = new StatusDM();
                                _status.StatusId = (Int64)reader["Work_Status_ID"];
                                _status.EmployeeStatus = (string)reader["Employee_Status"];
                                _status.HireDate = (DateTime)reader["Hire_Date"];
                                _status.PayType = (string)reader["Pay_Type"];
                                _status.ServiceLength = (string)reader["Service_Length"];
                                _status.EmploymentType = (string)reader["Employement_Type"];
                                _status.OfficeLocation = (string)reader["Office_Location"];
                                _status.TerminationDate = (DateTime)reader["Termination_Date"];
                                customerList.Add(_status);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (customerList);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadAllStatus", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// ReadStatusById: Reads the working status for the given individual using the statusId as a parameter
        /// Uses the READ_WORK_STATUS_BY_ID stored procedure.
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        public static StatusDM ReadStatusById(string statusId)
        {
            StatusDM _status = new StatusDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_WORK_STATUS_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Status_ID", statusId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _status.StatusId = (Int64)reader["Work_Status_ID"];
                                _status.EmployeeStatus = (string)reader["Employee_Status"];
                                _status.HireDate = (DateTime)reader["Hire_Date"];
                                _status.PayType = (string)reader["Pay_Type"];
                                _status.ServiceLength = (string)reader["Service_Length"];
                                _status.EmploymentType = (string)reader["Employement_Type"];
                                _status.OfficeLocation = (string)reader["Office_Location"];
                                _status.TerminationDate = (DateTime)reader["Termination_Date"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_status);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadStatusById", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// UpdateStatus: Using this method allows you to update a current or former employees work status.
        /// Uses the UPDATE_WORK_STATUS stored procedure
        /// </summary>
        /// <param name="_status"></param>
        public static void UpdateStatus(StatusDM _status)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_WORK_STATUS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_Status", _status.EmployeeStatus);
                    cmd.Parameters.AddWithValue("@Hire_Date", _status.HireDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Pay_Type", _status.PayType);
                    cmd.Parameters.AddWithValue("@Service_Length", _status.ServiceLength);
                    cmd.Parameters.AddWithValue("@Employment_Type", _status.EmploymentType);
                    cmd.Parameters.AddWithValue("@Office_Location", _status.OfficeLocation);
                    cmd.Parameters.AddWithValue("@Termination_Date", _status.TerminationDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Work_Status_ID", _status.StatusId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateStatus", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// DeleteStatus: Deletes a work status for a given employee
        /// Uses the DELETE_WORK_STATUS stored procedure
        /// </summary>
        /// <param name="_status"></param>
        public static void DeleteStatus(StatusDM _status)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_WORK_STATUS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Work_Status_ID", _status.StatusId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("DeleteWorkStatus", DateTime.Now, ex.Message);
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