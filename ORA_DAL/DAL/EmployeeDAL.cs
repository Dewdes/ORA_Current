using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ORA_Data.Model;

namespace ORA_Data.DAL
{
    public class EmployeeDAL
    {
        /// <summary>
        /// Basic CRUD methods for Employee information. EmployeeDM is the model being used here.
        /// </summary>
        /// 

        #region EMPLOYEE DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();
        //Creates the Employee in the database
        public void CreateEmployee(EmployeeDM employee)
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

        public EmployeeDM ReadEmployeeById(long employeeId)
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

        public long ReadEmployeeId(string employeeNum)
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

        public List<EmployeeDM> ReadEmployees()
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
                            #region Modal Objects
                            EmployeeDM employee = new EmployeeDM();
                            AddressDM address = new AddressDM();
                            EmployeeTimeDM EmployeeTime = new EmployeeTimeDM();
                            PositionsDM position = new PositionsDM();
                            StatusDM Status = new StatusDM();
                            #endregion

                            #region Pulling Employee Table Information

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

                            #endregion

                            //#region Pulling Address Table Information
                            //address.Address = (string)reader["Address"];
                            //address.City = (string)reader["City"];
                            //address.State = (string)reader["State"];
                            //address.Country = (string)reader["Country"];
                            //address.Zip_Code = (int)reader["Zip_Code"];
                            //address.Phone = (string)reader["Phone"];
                            //address.Email = (string)reader["Email"];
                            //#endregion

                            //#region Pulls Employee Time Table Information
                            //EmployeeTime.Other_Total = (decimal)reader["Other_Total"];
                            //EmployeeTime.Other_Available = (decimal)reader["Other_Available"];
                            //EmployeeTime.Other_Used = (decimal)reader["Other_Used"];
                            //EmployeeTime.Payed_Total = (decimal)reader["Payed_Total"];
                            //EmployeeTime.Payed_Used = (decimal)reader["Payed_Total"];
                            //#endregion

                            //#region Pulls Employee Work Status Information

                            //Status.EmployeeStatus = (string)reader["Employee_Status"];
                            //Status.HireDate = (DateTime)reader["Hire_Date"];
                            //Status.PayType = (string)reader["Pay_Type"];
                            //Status.ServiceLength = (string)reader["Service_Length"];
                            //Status.EmploymentType = (string)reader["Employment_Type"];
                            //Status.OfficeLocation = (string)reader["Office_Location"];
                            //if (reader["Termination_Date"] != DBNull.Value)
                            //    Status.TerminationDate = (DateTime)reader["Termination_Date"];
                            //#endregion

                            ////Adding the object properties to the employment object to be used together for the view modal
                            //employee.address = address; employee.EmployeeTime = EmployeeTime; employee.Status = Status;

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

        public void UpdateEmployee(EmployeeDM employee)
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

        public void DeleteEmployee(EmployeeDM employee)
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