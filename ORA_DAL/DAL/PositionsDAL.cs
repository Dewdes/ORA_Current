using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class PositionsDAL
    {
        #region POSITION DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_position"></param>
        public static void CreatePosition(PositionsDM _position)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_POSITION", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Position_Name", _position.PositionName);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreatePosition", DateTime.Now, e.Message);
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
        public static List<PositionsDM> ReadPositions()
        {
            List<PositionsDM> _positionList = new List<PositionsDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_POSITIONS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var _position = new PositionsDM();
                                _position.PositionId = (Int64)reader["Position_ID"];
                                _position.PositionName = (string)reader["Position_Name"];
                                _positionList.Add(_position);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_positionList);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("ReadPostitions", DateTime.Now, e.Message);
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
        /// <param name="positionId"></param>
        /// <returns></returns>
        public static PositionsDM ReadPositionById(string positionId)
        {
            PositionsDM _position = new PositionsDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_POSITION_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Position_ID", positionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _position.PositionId = (Int64)reader["Position_ID"];
                                _position.PositionName = (string)reader["Position_Name"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_position);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("ReadPostitionsById", DateTime.Now, e.Message);
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
        /// <param name="_position"></param>
        public static void UpdatePosition(PositionsDM _position)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_POSITION", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Position_ID", _position.PositionId);
                    cmd.Parameters.AddWithValue("@Position_Name", _position.PositionName);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdatePosition", DateTime.Now, e.Message);
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
        /// <param name="_position"></param>
        public static void DeletePosition(PositionsDM _position)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_POSITION", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Position_ID", _position.PositionId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("DeletePosition", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        #endregion
    }
}
