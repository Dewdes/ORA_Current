using System;
using System.Data;
using System.Data.SqlClient;
using ORA_Data.Model;

namespace ORA_Data.DAL
{
    public class AccountDAL
    {
        #region CREATE METHODS
        public static void CreateAccountBio(AccountBioDM accountBio,  int empID)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("CREATE_ACCOUNT_BIO", SqlConnect.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Profile_Image", accountBio.ProfileImage);
                    command.Parameters.AddWithValue("@Account_Status", accountBio.AccountStatus);
                    command.Parameters.AddWithValue("@Banner_Background_Img", accountBio.BannerBackgroundImg);
                    command.Parameters.AddWithValue("@About_Me", accountBio.AboutMe);
                    command.Parameters.AddWithValue("@Employee_ID", empID);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
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
