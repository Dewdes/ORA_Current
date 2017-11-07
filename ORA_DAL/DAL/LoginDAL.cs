using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class LoginDAL
    {
        /// <summary>
        /// Basic methods for Logging in and Registering information.
        /// </summary>
        /// 

        #region LOGIN DAL METHODS

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
                SqlConnect.Connection.Close();
                throw (ex);
            }
        }

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
                SqlConnect.Connection.Close();
                throw (ex);
            }
        }


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
                SqlConnect.Connection.Close();
                throw (ex);
            }
        }

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
                SqlConnect.Connection.Close();
                throw (ex);
            }
        }

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
                SqlConnect.Connection.Close();
                throw (ex);
            }
        }

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
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

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
                SqlConnect.Connection.Close();
                throw (ex);
            }
        }

        #endregion
    }
}
