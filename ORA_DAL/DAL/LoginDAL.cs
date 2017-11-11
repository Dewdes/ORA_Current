using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class LoginDAL
    {
        #region LOGIN DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool Login(LoginDM login)
        {
            try
            {
                bool loggedIN = false;
                using (SqlCommand command = new SqlCommand("READ_LOGIN_BY_EMAIL", SqlConnect.Connection))
                {
                    command.Parameters.AddWithValue("Email",login.Email);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if ((string)reader["Email"] == login.Email)
                                {
                                    if ((string)reader["Password"] == ORA_Data.Hash.GetHash(login.Password + (string)reader["Salt"]))
                                    {
                                        loggedIN = true;
                                    }
                                }
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return loggedIN;
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("Login", DateTime.Now, ex.Message);
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="EmpID"></param>
        public static void Register(LoginDM login, long EmpID)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("CREATE_LOGIN", SqlConnect.Connection))
                {
                    command.Parameters.AddWithValue("@Employee_ID", EmpID);
                    command.Parameters.AddWithValue("@Email",login.Email);
                    command.Parameters.AddWithValue("@Password",login.Password);
                    command.Parameters.AddWithValue("@Salt",login.Salt);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("Register", DateTime.Now, ex.Message);
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<LoginDM> ViewLogins()
        {
            try
            {
                List<LoginDM> logins = new List<LoginDM>();
                using (SqlCommand command = new SqlCommand("READ_LOGINS", SqlConnect.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                LoginDM login = new LoginDM { Email = (string)reader["Email"] };
                                logins.Add(login);
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return logins;
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ViewLogins", DateTime.Now, ex.Message);
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static LoginDM ReadLoginById(string loginId)
        {
            try
            {
                LoginDM login = new LoginDM();
                using (SqlCommand command = new SqlCommand("READ_LOGIN_BY_ID", SqlConnect.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Employee_ID", loginId);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                login.Email = (string)reader["Email"];
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return login;
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadLoginById", DateTime.Now, ex.Message);
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static long ReadLoginByEmail(string email)
        {
            try
            {
                LoginDM login = new LoginDM();
                using (SqlCommand command = new SqlCommand("READ_LOGIN_BY_EMAIL", SqlConnect.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                login.EmployeeId = (long)reader["Employee_ID"];
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return login.EmployeeId;
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadLoginByEmail", DateTime.Now, ex.Message);
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        public static void UpdateLogin(LoginDM login)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_LOGIN", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Login_ID", login.LoginId);
                    cmd.Parameters.AddWithValue("@Email", login.Email);
                    cmd.Parameters.AddWithValue("@Password", login.Password);
                    cmd.Parameters.AddWithValue("@Salt", login.Salt);
                    cmd.Parameters.AddWithValue("@Employee_ID", login.EmployeeId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateLogin", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        public static void DeleteLogin(LoginDM login)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_LOGIN", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", login.Email);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                        SqlConnect.Connection.Close();
                    }
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("DeleteLogin", DateTime.Now, ex.Message);
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        #endregion
    }
}
