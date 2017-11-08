using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class TeamsDAL
    {
        #region Team DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();

        /// <summary>
        /// CreateTeam: Creates a new team. Duh.
        /// Uses the...wait for it....CREATE_TEAM stored procedure
        /// </summary>
        /// <param name="_team"></param>
        public static void CreateTeam(TeamsDM _team)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_TEAM", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Team_Name", _team.TeamName);
                    cmd.Parameters.AddWithValue("@Client_ID", _team.ClientId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateTeam", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// ReadTeams: Reads all created teams...
        /// Uses the READ_TEAMS stored procedure
        /// </summary>
        /// <returns></returns>
        public static List<TeamsDM> ReadTeams()
        {
            List<TeamsDM> teamList = new List<TeamsDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_TEAMS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var _team = new TeamsDM();
                                _team.TeamName = (string)reader["Team_Name"];
                                _team.TeamId = (Int64)reader["Team_ID"];
                                _team.ClientId = (Int64)reader["Client_ID"];
                                teamList.Add(_team);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (teamList);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadTeams", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// ReadTeamyId: Reads a teams information for the teamId equal to the given teamId
        /// Uses the READ_TEAM_BY_ID stored procedure
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public static TeamsDM ReadTeamById(string teamId)
        {
            TeamsDM _team = new TeamsDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_TEAM_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Team_ID", teamId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _team.TeamName = (string)reader["Team_Name"];
                                _team.TeamId = (Int64)reader["Team_ID"];
                                _team.ClientId = (Int64)reader["Client_ID"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_team);
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadTeamById", DateTime.Now, ex.Message);
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// UpdateTeam: Can update a team/
        /// Uses the UPDATE_TEAM stored procedure
        /// </summary>
        /// <param name="_team"></param>
        public static void UpdateTeam(TeamsDM _team)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_TEAM", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Team_Name", _team.TeamName);
                    cmd.Parameters.AddWithValue("@Team_ID", _team.TeamId);
                    cmd.Parameters.AddWithValue("@Client_ID", _team.ClientId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateTeam", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// DeleteTeam: Deletes a team from the database
        /// Uses the DELETE_TEAM stored procedure
        /// </summary>
        /// <param name="_team"></param>
        public static void DeleteTeam(TeamsDM _team)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_TEAM", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Team_ID", _team.TeamId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("DeleteTeam", DateTime.Now, ex.Message);
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