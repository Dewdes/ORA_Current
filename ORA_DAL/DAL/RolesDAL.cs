using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class RolesDAL
    {
        /// <summary>
        /// Basic CRUD methods for Role information. RoleDM is the model being used here.
        /// </summary>

        #region ROLE DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();
        public static void CreateRole(RolesDM _role)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                    using (SqlCommand cmd = new SqlCommand("CREATE_ROLE", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Role_Name", _role.RoleName);
                        cmd.Parameters.AddWithValue("@Role_Description", _role.RoleDescription);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                    }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateRole", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        public static List<RolesDM> ReadRoles()
        {
            List<RolesDM> customerList = new List<RolesDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_ROLES", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                SqlConnect.Connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _role = new RolesDM();
                                    _role.RoleName = (string)reader["Role_Name"];
                                    _role.RoleDescription = (string)reader["Role_Description"];
                                    _role.RoleId = (Int64)reader["Role_ID"];
                                    customerList.Add(_role);
                                }
                            }
                    }
                    SqlConnect.Connection.Close();
                }
                return (customerList);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadRoles", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        public static RolesDM ReadRoleByID(long roleId)
        {
            try
            {
                RolesDM _role = new RolesDM();
                using (SqlCommand cmd = new SqlCommand("READ_ROLE_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Role_ID", roleId);
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _role.RoleId = (Int64)reader["Role_ID"];
                                _role.RoleName = (string)reader["Role_Name"];
                                _role.RoleDescription = (string)reader["Role_Description"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_role);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadRoleByID", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        public static RolesDM ReadRoleForEmployee(LoginDM _role)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_ROLE_FOR_EMPLOYEE", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Employee_ID", _role.EmployeeId);
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _role.Role.RoleId = (Int64)reader["Role_ID"];
                                _role.Role.RoleName = (string)reader["Role_Name"];
                                _role.Role.RoleDescription = (string)reader["Role_Description"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_role.Role);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadRoleForEmployee", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }


        public static void UpdateRole(RolesDM _role)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_ROLE", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Role_Name", _role.RoleName);
                        cmd.Parameters.AddWithValue("@Role_Number", _role.RoleDescription);
                        cmd.Parameters.AddWithValue("@Role_ID", _role.RoleId);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateRole", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        public static void DeleteRole(RolesDM _role)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_ROLE", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Role_ID", _role.RoleId);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("DeleteRole", DateTime.Now, ex.Message);
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