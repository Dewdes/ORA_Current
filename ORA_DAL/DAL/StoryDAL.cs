using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class StoryDAL
    {
        #region Story DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();

        /// <summary>
        /// Creates stories
        /// Uses the CREATE_STORY stored procedure
        /// </summary>
        /// <param name="_story"></param>
        public static void CreateStory(StoryDM _story)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                    using (SqlCommand cmd = new SqlCommand("CREATE_STORY", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Story_Name", _story.StoryName);
                        cmd.Parameters.AddWithValue("@Story_Number", _story.StoryNumber);
                        cmd.Parameters.AddWithValue("@Story_Start_Date", _story.StartDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Story_End_Date", _story.EndDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Client_ID", _story.ClientId);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                        SqlConnect.Connection.Close();
                    }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateStory", DateTime.Now, e.Message);
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
        public static List<StoryDM> ReadStorys()
        {
            List<StoryDM> storyList = new List<StoryDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_STORYS", SqlConnect.Connection))
                    {
                    SqlConnect.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _story = new StoryDM();
                                    _story.StoryId = (Int64)reader["Story_ID"];
                                    _story.StoryName = (string)reader["Story_Name"];
                                    _story.StoryNumber = (string)reader["Story_Number"];
                                    _story.StartDate = (DateTime)reader["Story_Start_Date"];
                                    _story.EndDate = (DateTime)reader["Story_End_Date"];
                                    _story.ClientId = (Int64)reader["Client_ID"];
                                    storyList.Add(_story);
                                }
                            }
                    }
                    SqlConnect.Connection.Close();
                }
                return (storyList);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadStorys", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public static StoryDM ReadStoryById(string storyId)
        {
            StoryDM _story = new StoryDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_STORY_BY_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Story_ID", storyId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _story.StoryId = (Int64)reader["Story_ID"];
                                _story.StoryName = (string)reader["Story_Name"];
                                _story.StoryNumber = (string)reader["Story_Number"];
                                _story.StartDate = (DateTime)reader["Story_Start_Date"];
                                _story.EndDate = (DateTime)reader["Story_End_Date"];
                                _story.ClientId = (Int64)reader["Client_ID"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_story);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadStoryById", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_story"></param>
        public static void UpdateStory(StoryDM _story)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_STORY", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Story_ID", _story.StoryId);
                        cmd.Parameters.AddWithValue("@Story_Name", _story.StoryName);
                        cmd.Parameters.AddWithValue("@Story_Number", _story.StoryNumber);
                        cmd.Parameters.AddWithValue("@Story_Start_Date", _story.StartDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Story_End_Date", _story.EndDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Client_ID", _story.ClientId);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateStory", DateTime.Now, e.Message);
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
        /// <param name="_story"></param>
        public static void DeleteStory(StoryDM _story)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_STORY", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Story_ID", _story.StoryId);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("DeleteStory", DateTime.Now, ex.Message);
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