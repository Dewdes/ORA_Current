﻿using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class SprintDAL
    {
        /// <summary>
        /// Basic CRUD methods for Sprint information. SprintDM is the model being used here.
        /// </summary>

        #region Sprint DAL METHODS
        public static void CreateSprint(SprintDM _sprint)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_SPRINT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Sprint_Number", _sprint.SprintNumber);
                    cmd.Parameters.AddWithValue("@Sprint_Name", _sprint.SprintName);
                    cmd.Parameters.AddWithValue("@Client_ID", _sprint.ClientId);
                    cmd.Parameters.AddWithValue("@Start_Date", _sprint.EndDate);
                    cmd.Parameters.AddWithValue("@End_Date", _sprint.StartDate);
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

        public static List<SprintDM> ReadSprints()
        {
            List<SprintDM> sprintList = new List<SprintDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_SPRINTS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var _sprint = new SprintDM();
                                _sprint.SprintId = (Int64)reader["Sprint_ID"];
                                _sprint.SprintName = (string)reader["Sprint_Name"];
                                _sprint.SprintNumber = (int)reader["Sprint_Number"];
                                _sprint.StartDate = (DateTime)reader["Start_Date"];
                                _sprint.EndDate = (DateTime)reader["End_Date"];
                                _sprint.ClientId = (Int64)reader["Client_ID"];
                                _sprint.SprintId = (Int64)reader["Sprint_ID"];
                                sprintList.Add(_sprint);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (sprintList);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                throw ex;
            }
        }

        public static SprintDM ReadSprintById(string sprintId)
        {
            SprintDM _sprint = new SprintDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_SPRINT_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Sprint_ID", sprintId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _sprint.SprintId = (Int64)reader["Sprint_ID"];
                                _sprint.SprintName = (string)reader["Sprint_Name"];
                                _sprint.SprintNumber = (int)reader["Sprint_Number"];
                                _sprint.StartDate = (DateTime)reader["Start_Date"];
                                _sprint.EndDate = (DateTime)reader["End_Date"];
                                _sprint.ClientId = (Int64)reader["Client_ID"];
                                _sprint.SprintId = (Int64)reader["Sprint_ID"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_sprint);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                throw ex;
            }
        }

        public static void UpdateSprint(SprintDM _sprint)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_SPRINT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Sprint_Name", _sprint.SprintName);
                    cmd.Parameters.AddWithValue("@Sprint_Number", _sprint.SprintNumber);
                    cmd.Parameters.AddWithValue("@Start_Date", _sprint.StartDate);
                    cmd.Parameters.AddWithValue("@End_Date", _sprint.EndDate);
                    cmd.Parameters.AddWithValue("@Client_ID", _sprint.ClientId);
                    cmd.Parameters.AddWithValue("@Sprint_ID", _sprint.SprintId);
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

        public static void DeleteSprint(SprintDM _sprint)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_SPRINT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Sprint_ID", _sprint.SprintId);
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
        #endregion
    }
}