using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ORA_Data.Model;

namespace ORA_Data.DAL
{
    public class EmployeeDAL
    {
        #region EMPLOYEE DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();

        ///<summary>
        /// Used to create an employee. Only admins will create new employees.
        /// Uses the CREATE_EMPLOYEE stored procedure.
        /// </summary>
        /// <param name="employee"></param>
        public static void CreateEmployee(EmployeeDM employee)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("CREATE_EMPLOYEE", SqlConnect.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Employee_Number", employee.EmployeeNumber);
                    command.Parameters.AddWithValue("@Employee_Name", employee.EmployeeFirstName + " " + employee.EmployeeMiddle + " " + employee.EmployeeLastName);
                    command.Parameters.AddWithValue("@Employee_FirstName", employee.EmployeeFirstName);
                    command.Parameters.AddWithValue("@Employee_MiddleName", employee.EmployeeMiddle);
                    command.Parameters.AddWithValue("@Employee_LastName", employee.EmployeeLastName);
                    command.Parameters.AddWithValue("@Age", employee.Age);
                    command.Parameters.AddWithValue("@Birth_Date", employee.BirthDate.ToShortDateString());
                    command.Parameters.AddWithValue("@Team_ID", employee.TeamID);
                    command.Parameters.AddWithValue("@Assignment_ID", employee.AssignmentID);
                    command.Parameters.AddWithValue("@Role_ID", employee.RoleID);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("CreateEmployee", DateTime.Now, ex.Message);
                throw (ex);
            }

            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Reads employees by the given employee ID
        /// Uses the READ_EMPLOYEE_BY_ID stored procedure
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static EmployeeDM ReadEmployeeById(long employeeId)
        {
            try
            {
                EmployeeDM employee = new EmployeeDM();
                using (SqlCommand command = new SqlCommand("READ_EMPLOYEE_BY_ID", SqlConnect.Connection))
                {
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Employee_ID", employeeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                employee.EmployeeId = (Int64)reader["Employee_ID"];
                                employee.EmployeeNumber = (string)reader["Employee_Number"];
                                employee.EmployeeName = (string)reader["Employee_Name"];
                                employee.EmployeeFirstName = (string)reader["Employee_FirstName"];
                                employee.EmployeeMiddle = (string)reader["Employee_MiddleName"];
                                employee.EmployeeLastName = (string)reader["Employee_LastName"];
                                employee.Age = (int)reader["Age"];
                                employee.BirthDate = (DateTime)reader["Birth_Date"];
                                employee.TeamID = (Int64)reader["Team_ID"];
                                employee.RoleID = (Int64)reader["Role_ID"];
                                employee.AssignmentID = (Int64)reader["Assignment_ID"];
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return employee;
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadEmployeeByID", DateTime.Now, ex.Message);
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Reads employee by using the given employee number
        /// Uses the READ_EMPLOYEE_ID stored procedure
        /// </summary>
        /// <param name="employeeNum"></param>
        /// <returns></returns>
        public static long ReadEmployeeId(string employeeNum)
        {
            try
            {
                EmployeeDM employee = new EmployeeDM();
                using (SqlCommand command = new SqlCommand("READ_EMPLOYEE_ID", SqlConnect.Connection))
                {
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Employee_Number", employeeNum);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                employee.EmployeeId = (Int64)reader["Employee_ID"];
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return employee.EmployeeId;
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadEmployeeID", DateTime.Now, ex.Message);
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Reads all employees. Pretty simple.
        /// Uses the READ_EMPLOYEES stored procedure.
        /// </summary>
        /// <returns></returns>
        public static List<EmployeeDM> ReadEmployees()
        {
            List<EmployeeDM> employeeList = new List<EmployeeDM>();
            try
            {
                SqlConnect.Connection.Open();
                using (SqlCommand cmd = new SqlCommand("READ_EMPLOYEES", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return (employeeList);
                        while (reader.Read())
                        {
                            //Creating objects of the modals inside the loop so that 
                            //the object can be used for new information every iteration of the loop.
                            EmployeeDM employee = new EmployeeDM();
                            employee.EmployeeId = (Int64)reader["Employee_ID"];
                            employee.EmployeeNumber = (string)reader["Employee_Number"];
                            employee.EmployeeName = (string)reader["Employee_Name"];
                            employee.EmployeeFirstName = (string)reader["Employee_FirstName"];
                            employee.EmployeeMiddle = (string)reader["Employee_MiddleName"];
                            employee.EmployeeLastName = (string)reader["Employee_LastName"];
                            employee.Age = (int)reader["Age"];
                            employee.BirthDate = (DateTime)reader["Birth_Date"];
                            if (reader["Team_ID"] != DBNull.Value)
                                employee.TeamID = (Int64)reader["Team_ID"];
                            if (reader["Role_ID"] != DBNull.Value)
                                employee.RoleID = (Int64)reader["Role_ID"];
                            if (reader["Assignment_ID"] != DBNull.Value)
                                employee.AssignmentID = (Int64)reader["Assignment_ID"];

                            employeeList.Add(employee);
                        }
                    }
                    cmd.Connection.Close();
                }
                return (employeeList);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadEmployees", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// This method is used to update basic employee information from the employee table. This is NOT used to update employee personal bio,
        /// address or anything else.
        /// Uses the UPDATE_EMPLOYEE stored procedure.
        /// </summary>
        /// <param name="employee"></param>
        public static void UpdateEmployee(EmployeeDM employee)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_EMPLOYEE", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@Employee_Number", employee.EmployeeNumber);
                    cmd.Parameters.AddWithValue("@Employee_Name", employee.EmployeeFirstName + " " + employee.EmployeeMiddle + " " + employee.EmployeeLastName);
                    cmd.Parameters.AddWithValue("@Employee_FirstName", employee.EmployeeFirstName);
                    cmd.Parameters.AddWithValue("@Employee_MiddleName", employee.EmployeeMiddle);
                    cmd.Parameters.AddWithValue("@Employee_LastName", employee.EmployeeLastName);
                    cmd.Parameters.AddWithValue("@Age", employee.Age);
                    cmd.Parameters.AddWithValue("@Birth_Date", employee.BirthDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Team_ID", employee.TeamID);
                    cmd.Parameters.AddWithValue("@Role_ID", employee.RoleID);
                    cmd.Parameters.AddWithValue("@Assignment_ID", employee.AssignmentID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateEmployee", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Used to delete an employee, should ONLY be used by an admin IF AND ONLY IF an employee was created BY MISTAKE
        /// Employees that are no longer working for onshore will be disabled, not deleted.
        /// Uses the DELETE_EMPLOYEE stored procedure.
        /// </summary>
        /// <param name="employee"></param>
        public static void DeleteEmployee(EmployeeDM employee)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_EMPLOYEE", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", employee.EmployeeId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("DeleteEmployee", DateTime.Now, ex.Message);
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