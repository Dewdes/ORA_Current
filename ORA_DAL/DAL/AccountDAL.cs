using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class AccountDAL
    {
        private static ErrorLog errorLog = new ErrorLog();
        /// <summary>
        /// Records
        /// </summary>
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

        /// <summary>
        /// Bio CRUD
        /// </summary>

        public static void CreateBio(AccountBioDM bio, long id )
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_BIO", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProfileImg", bio.ProfileImage);
                    cmd.Parameters.AddWithValue("@Status", bio.AccountStatus);
                    cmd.Parameters.AddWithValue("@BannerBackgroundImg", bio.BannerBackgroundImg);
                    cmd.Parameters.AddWithValue("@AboutMe", bio.AboutMe);
                    cmd.Parameters.AddWithValue("@Employee_ID", id);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateBio", DateTime.Now, e.Message);
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
        /// <returns></returns>
        public static List<AccountBioDM> ReadBios()
        {
            List<AccountBioDM> bioList = new List<AccountBioDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_BIOS", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var bio = new AccountBioDM();
                                bio.AccountBioID = (Int64)reader["EmployeeBio_ID"];
                                bio.ProfileImage = (string)reader["ProfileImg"];
                                bio.AccountStatus = (string)reader["Status"];
                                bio.BannerBackgroundImg = (string)reader["BannerBackgroundImg"];
                                bio.AboutMe = (string)reader["AboutMe"];
                                bio.EmployeeID = (Int64)reader["Employee_ID"];
                                bioList.Add(bio);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (bioList);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("ReadBios", DateTime.Now, e.Message);
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
        public static AccountBioDM ReadBioById(string id)
        {
            AccountBioDM bio = new AccountBioDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_BIO_BY_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                bio.AccountBioID = (Int64)reader["EmployeeBio_ID"];

                                if (reader["ProfileImg"] != DBNull.Value)
                                    bio.ProfileImage = (string)reader["ProfileImg"];
                                else
                                    bio.ProfileImage = "";

                                if (reader["Status"] != DBNull.Value)
                                    bio.AccountStatus = (string)reader["Status"];
                                else
                                    bio.AccountStatus = "";

                                if (reader["BannerBackgroundImg"] != DBNull.Value)
                                    bio.BannerBackgroundImg = (string)reader["BannerBackgroundImg"];
                                else
                                    bio.BannerBackgroundImg = "";

                                if (reader["AboutMe"] != DBNull.Value)
                                    bio.AboutMe = (string)reader["AboutMe"];
                                else
                                    bio.AboutMe = "";
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (bio);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("ReadBioByID", DateTime.Now, e.Message);
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
        public static void UpdateBio(AccountBioDM bio)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_BIO", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProfileImg", bio.ProfileImage);
                    cmd.Parameters.AddWithValue("@Status", bio.AccountStatus);
                    cmd.Parameters.AddWithValue("@BannerBackgroundImg", bio.BannerBackgroundImg);
                    cmd.Parameters.AddWithValue("@AboutMe", bio.AboutMe);
                    cmd.Parameters.AddWithValue("@Employee_ID", bio.EmployeeID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateBio", DateTime.Now, e.Message);
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
        public static void DeleteBio(AccountBioDM bio)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_BIO", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", bio.EmployeeID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("DeleteBio", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }
    

    public static void UpdateAboutMe(long emp_ID, string aboutMe)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_ABOUTME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", emp_ID);
                    cmd.Parameters.AddWithValue("@AboutMe", aboutMe);
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

        public static void UpdateStatus(long emp_ID, string status)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_STATUS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", emp_ID);
                    cmd.Parameters.AddWithValue("@Status", status);
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

        public static void UpdateProfileImg(long emp_ID, string image)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_PROFILE_IMAGE", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", emp_ID);
                    cmd.Parameters.AddWithValue("@ProfileImg", image);
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

        public static void UpdateBackground(long emp_ID, string image)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_BACKGROUND_IMAGE", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", emp_ID);
                    cmd.Parameters.AddWithValue("@BannerBackgroundImg", image);
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
    }
}
