﻿using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class ProjectDAL
    {
        /// <summary>
        /// Basic CRUD methods for Project information. ProjectDM is the model being used here.
        /// </summary>

        #region Project DAL METHODS
        public static void CreateProject(ProjectDM _project)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                    using (SqlCommand cmd = new SqlCommand("CREATE_PROJECT", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Project_Name", _project.ProjectName);
                        cmd.Parameters.AddWithValue("@Project_Number", _project.ProjectNumber);
                        cmd.Parameters.AddWithValue("@Project_Start_Date", _project.StartDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Project_End_Date", _project.EndDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Client_ID", _project.ClientId);
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

        public static List<ProjectDM> ReadProjects()
        {
            List<ProjectDM> projectList = new List<ProjectDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_PROJECTS", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _project = new ProjectDM();
                                    _project.ProjectId = (Int64)reader["Project_ID"];
                                    _project.ProjectName = (string)reader["Project_Name"];
                                    _project.ProjectNumber = (int)reader["Project_Number"];
                                    _project.StartDate = (DateTime)reader["Project_Start_Date"];
                                    _project.EndDate = (DateTime)reader["Project_End_Date"];
                                    _project.ClientId = (Int64)reader["Client_ID"];
                                    projectList.Add(_project);
                                }
                            }
                    }
                    SqlConnect.Connection.Close();
                }
                return (projectList);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                throw ex;
            }
        }

        public static ProjectDM ReadProjectById(string projectId)
        {
            ProjectDM _project = new ProjectDM();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_PROJECT_BY_ID", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Project_ID", projectId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    _project.ProjectId = (Int64)reader["Project_ID"];
                                    _project.ProjectName = (string)reader["Project_Name"];
                                    _project.ProjectNumber = (int)reader["Project_Number"];
                                    _project.StartDate = (DateTime)reader["Project_Start_Date"];
                                    _project.EndDate = (DateTime)reader["Project_End_Date"];
                                    _project.ClientId = (Int64)reader["Client_ID"];
                                }
                            }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_project);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                throw ex;
            }
        }

        public static void UpdateProject(ProjectDM _project)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_PROJECT", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Project_ID", _project.ProjectId);
                        cmd.Parameters.AddWithValue("@Project_Name", _project.ProjectName);
                        cmd.Parameters.AddWithValue("@Project_Number", _project.ProjectNumber);
                        cmd.Parameters.AddWithValue("@Project_Start_Date", _project.StartDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Project_End_Date", _project.EndDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Client_ID", _project.ClientId);
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

        public static void DeleteProject(ProjectDM _project)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_PROJECT", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Project_ID", _project.ProjectId);
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