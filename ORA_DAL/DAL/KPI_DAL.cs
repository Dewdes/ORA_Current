using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class KPI_DAL
    {
        #region KPI DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_kpi"></param>
        public static void CreateKPI(KPIDM _kpi)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_KPI", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Create_Date", _kpi.CreateDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Points", _kpi.Points);
                    cmd.Parameters.AddWithValue("@TC_Created", _kpi.TCCreated);
                    cmd.Parameters.AddWithValue("@TC_Executed", _kpi.TCExecuted);
                    cmd.Parameters.AddWithValue("@TC_Failed", _kpi.TCFailed);
                    cmd.Parameters.AddWithValue("@TC_Passed", _kpi.TCPassed);
                    cmd.Parameters.AddWithValue("@TC_Blocked", _kpi.TCBlocked);
                    cmd.Parameters.AddWithValue("@Defects_Found", _kpi.DefectsFound);
                    cmd.Parameters.AddWithValue("@Defects_Fixed", _kpi.DefectsFixed);
                    cmd.Parameters.AddWithValue("@Defects_Accepted", _kpi.DefectsAccepted);
                    cmd.Parameters.AddWithValue("@Defects_Rejected", _kpi.DefectsRejected);
                    cmd.Parameters.AddWithValue("@Defects_Deferred", _kpi.DefectsDeferred);
                    cmd.Parameters.AddWithValue("@Critical_Defects", _kpi.CriticalDefects);
                    cmd.Parameters.AddWithValue("@Test_Hrs_Planned", _kpi.TestHrsPlanned);
                    cmd.Parameters.AddWithValue("@Test_Hrs_Actual", _kpi.TestHrsActual);
                    cmd.Parameters.AddWithValue("@Bugs_Found_Production", _kpi.BugsFoundProduction);
                    cmd.Parameters.AddWithValue("@Total_Hrs_Fixing_Bugs", _kpi.TotalHrsFixingBugs);
                    cmd.Parameters.AddWithValue("@Velocity", _kpi.Velocity);
                    cmd.Parameters.AddWithValue("@Collaboration", _kpi.Collaboration);
                    cmd.Parameters.AddWithValue("@Start_Date", _kpi.Start_Date);
                    cmd.Parameters.AddWithValue("@End_Date", _kpi.End_Date);
                    cmd.Parameters.AddWithValue("@Assignment_ID", _kpi.AssignmentId);
                    cmd.Parameters.AddWithValue("@Project_ID", _kpi.ProjectId);
                    cmd.Parameters.AddWithValue("@Sprint_ID", _kpi.SprintId);
                    cmd.Parameters.AddWithValue("@Story_ID", _kpi.StoryId);
                    cmd.Parameters.AddWithValue("@Employee_ID", _kpi.EmployeeId);
                    cmd.Parameters.AddWithValue("@Modified", _kpi.Modified);
                    cmd.Parameters.AddWithValue("@Modified_By", _kpi.ModifiedBy);
                    cmd.Parameters.AddWithValue("@Created_By", _kpi.CreatedBy);
                    cmd.Parameters.AddWithValue("@RTC_Passed", _kpi.RTCPassed);
                    cmd.Parameters.AddWithValue("@RTC_Failed", _kpi.RTCFailed);
                    cmd.Parameters.AddWithValue("@RTC_Created", _kpi.RTCCreated);
                    cmd.Parameters.AddWithValue("@RTC_Updated", _kpi.RTCUpdated);
                    cmd.Parameters.AddWithValue("@SprintTC_Passed", _kpi.SprintTC_Passed);
                    cmd.Parameters.AddWithValue("@SprintTC_Failed", _kpi.SprintTC_Failed);
                    cmd.Parameters.AddWithValue("@SprintTC_Created", _kpi.SprintTC_Created);
                    cmd.Parameters.AddWithValue("@Defects_FoundInTesting", _kpi.Defects_FoundInTesting);
                    cmd.Parameters.AddWithValue("@Defects_FoundInProd", _kpi.Defects_FoundInProd);
                    cmd.Parameters.AddWithValue("@Defects_RetestedFailed", _kpi.Defects_RetestedFailed);
                    cmd.Parameters.AddWithValue("@Defects_Closed", _kpi.DefectsClosed);
                    if (_kpi.TasksCompleted != null)
                    {
                        cmd.Parameters.AddWithValue("@Tasks_Completed", _kpi.TasksCompleted);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Tasks_Completed", DBNull.Value);
                    }

                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateKPI", DateTime.Now, e.Message);
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
        public static List<KPIDM> ReadKPIs()
        {
            List<KPIDM> _kpiList = new List<KPIDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_KPIS", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var _kpi = new KPIDM();
                                _kpi.KPIID = (Int64)reader["KPI_ID"];
                                _kpi.CreateDate = (DateTime)reader["Create_Date"];
                                _kpi.Points = (int)reader["Points"];
                                _kpi.TCCreated = (int)reader["TC_Created"];
                                _kpi.TCExecuted = (int)reader["TC_Executed"];
                                _kpi.TCFailed = (int)reader["TC_Failed"];
                                _kpi.TCPassed = (int)reader["TC_Passed"];
                                _kpi.TCBlocked = (int)reader["TC_Blocked"];
                                _kpi.DefectsFound = (int)reader["Defects_Found"];
                                _kpi.DefectsFixed = (int)reader["Defects_Fixed"];
                                _kpi.DefectsAccepted = (int)reader["Defects_Accepted"];
                                _kpi.DefectsRejected = (int)reader["Defects_Rejected"];
                                _kpi.DefectsDeferred = (int)reader["Defects_Deferred"];
                                _kpi.CriticalDefects = (int)reader["Critical_Defects"];
                                _kpi.TestHrsPlanned = (decimal)reader["Test_Hrs_Planned"];
                                _kpi.TestHrsActual = (decimal)reader["Test_Hrs_Actual"];
                                _kpi.BugsFoundProduction = (int)reader["Bugs_Found_Production"];
                                _kpi.TotalHrsFixingBugs = (decimal)reader["Total_Hrs_Fixing_Bugs"];
                                _kpi.Velocity = (Int64)reader["Velocity"];
                                _kpi.Collaboration = (Int64)reader["Collaboration"];
                                _kpi.Start_Date = (DateTime)reader["Start_Date"];
                                _kpi.End_Date = (DateTime)reader["End_Date"];
                                _kpi.AssignmentId = (Int64)reader["Assignment_ID"];
                                _kpi.ProjectId = (Int64)reader["Project_ID"];
                                _kpi.SprintId = (Int64)reader["Sprint_ID"];
                                _kpi.StoryId = (Int64)reader["Story_ID"];
                                _kpi.EmployeeId = (Int64)reader["Employee_ID"];
                                _kpi.CreatedBy = (string)reader["Created_By"];
                                _kpi.Modified = (DateTime)reader["Modified"];
                                _kpi.ModifiedBy = (string)reader["Modified_By"];
                                if (reader["RTC_Passed"] != DBNull.Value)
                                    _kpi.RTCPassed = (int)reader["RTC_Passed"];
                                else
                                    _kpi.RTCPassed = 0;
                                if (reader["RTC_Failed"] != DBNull.Value)
                                    _kpi.RTCFailed = (int)reader["RTC_Failed"];
                                else
                                    _kpi.RTCFailed = 0;
                                if (reader["RTC_Created"] != DBNull.Value)
                                    _kpi.RTCCreated = (int)reader["RTC_Created"];
                                else
                                    _kpi.RTCCreated = 0;
                                if (reader["RTC_Updated"] != DBNull.Value)
                                    _kpi.RTCUpdated = (int)reader["RTC_Updated"];
                                else
                                    _kpi.RTCUpdated = 0;
                                if (reader["SprintTC_Passed"] != DBNull.Value)
                                    _kpi.SprintTC_Passed = (int)reader["SprintTC_Passed"];
                                else
                                    _kpi.SprintTC_Passed = 0;
                                if (reader["SprintTC_Failed"] != DBNull.Value)
                                    _kpi.SprintTC_Failed = (int)reader["SprintTC_Failed"];
                                else
                                    _kpi.SprintTC_Failed = 0;
                                if (reader["SprintTC_Created"] != DBNull.Value)
                                    _kpi.SprintTC_Created = (int)reader["SprintTC_Created"];
                                else
                                    _kpi.SprintTC_Created = 0;
                                if (reader["Defects_FoundInTesting"] != DBNull.Value)
                                    _kpi.Defects_FoundInTesting = (int)reader["Defects_FoundInTesting"];
                                else
                                    _kpi.Defects_FoundInTesting = 0;
                                if (reader["Defects_FoundInProd"] != DBNull.Value)
                                    _kpi.Defects_FoundInProd = (int)reader["Defects_FoundInProd"];
                                else
                                    _kpi.Defects_FoundInProd = 0;
                                if (reader["Defects_RetestedFailed"] != DBNull.Value)
                                    _kpi.Defects_RetestedFailed = (int)reader["Defects_RetestedFailed"];
                                else
                                    _kpi.Defects_RetestedFailed = 0;
                                if (reader["Defects_Closed"] != DBNull.Value)
                                    _kpi.DefectsClosed = (int)reader["Defects_Closed"];
                                else
                                    _kpi.DefectsClosed = 0;
                                if (reader["Tasks_Completed"] != DBNull.Value)
                                    _kpi.TasksCompleted = (string)reader["Tasks_Completed"];
                                else
                                    _kpi.TasksCompleted = "";

                                _kpiList.Add(_kpi);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_kpiList);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("ReadKPIs", DateTime.Now, e.Message);
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
        /// <param name="kpiId"></param>
        /// <returns></returns>
        public static KPIDM ReadKPIById(long kpiId)
        {
            KPIDM _kpi = new KPIDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_KPI_BY_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KPI_ID", kpiId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _kpi.KPIID = (Int64)reader["KPI_ID"];
                                _kpi.CreateDate = (DateTime)reader["Create_Date"];
                                _kpi.Points = (int)reader["Points"];
                                _kpi.TCCreated = (int)reader["TC_Created"];
                                _kpi.TCExecuted = (int)reader["TC_Executed"];
                                _kpi.TCFailed = (int)reader["TC_Failed"];
                                _kpi.TCPassed = (int)reader["TC_Passed"];
                                _kpi.TCBlocked = (int)reader["TC_Blocked"];
                                _kpi.DefectsFound = (int)reader["Defects_Found"];
                                _kpi.DefectsFixed = (int)reader["Defects_Fixed"];
                                _kpi.DefectsAccepted = (int)reader["Defects_Accepted"];
                                _kpi.DefectsRejected = (int)reader["Defects_Rejected"];
                                _kpi.DefectsDeferred = (int)reader["Defects_Deferred"];
                                _kpi.CriticalDefects = (int)reader["Critical_Defects"];
                                _kpi.TestHrsPlanned = (decimal)reader["Test_Hrs_Planned"];
                                _kpi.TestHrsActual = (decimal)reader["Test_Hrs_Actual"];
                                _kpi.BugsFoundProduction = (int)reader["Bugs_Found_Production"];
                                _kpi.TotalHrsFixingBugs = (decimal)reader["Total_Hrs_Fixing_Bugs"];
                                _kpi.Velocity = (Int64)reader["Velocity"];
                                _kpi.Collaboration = (Int64)reader["Collaboration"];
                                _kpi.Start_Date = (DateTime)reader["Start_Date"];
                                _kpi.End_Date = (DateTime)reader["End_Date"];
                                _kpi.AssignmentId = (Int64)reader["Assignment_ID"];
                                _kpi.ProjectId = (Int64)reader["Project_ID"];
                                _kpi.SprintId = (Int64)reader["Sprint_ID"];
                                _kpi.StoryId = (Int64)reader["Story_ID"];
                                _kpi.EmployeeId = (Int64)reader["Employee_ID"];
                                _kpi.CreatedBy = (string)reader["Created_By"];
                                _kpi.Modified = (DateTime)reader["Modified"];
                                _kpi.ModifiedBy = (string)reader["Modified_By"];
                                if (reader["RTC_Passed"] != DBNull.Value)
                                    _kpi.RTCPassed = (int)reader["RTC_Passed"];
                                else
                                    _kpi.RTCPassed = 0;
                                if (reader["RTC_Failed"] != DBNull.Value)
                                    _kpi.RTCFailed = (int)reader["RTC_Failed"];
                                else
                                    _kpi.RTCFailed = 0;
                                if (reader["RTC_Created"] != DBNull.Value)
                                    _kpi.RTCCreated = (int)reader["RTC_Created"];
                                else
                                    _kpi.RTCCreated = 0;
                                if (reader["RTC_Updated"] != DBNull.Value)
                                    _kpi.RTCUpdated = (int)reader["RTC_Updated"];
                                else
                                    _kpi.RTCUpdated = 0;
                                if (reader["SprintTC_Passed"] != DBNull.Value)
                                    _kpi.SprintTC_Passed = (int)reader["SprintTC_Passed"];
                                else
                                    _kpi.SprintTC_Passed = 0;
                                if (reader["SprintTC_Failed"] != DBNull.Value)
                                    _kpi.SprintTC_Failed = (int)reader["SprintTC_Failed"];
                                else
                                    _kpi.SprintTC_Failed = 0;
                                if (reader["SprintTC_Created"] != DBNull.Value)
                                    _kpi.SprintTC_Created = (int)reader["SprintTC_Created"];
                                else
                                    _kpi.SprintTC_Created = 0;
                                if (reader["Defects_FoundInTesting"] != DBNull.Value)
                                    _kpi.Defects_FoundInTesting = (int)reader["Defects_FoundInTesting"];
                                else
                                    _kpi.Defects_FoundInTesting = 0;
                                if (reader["Defects_FoundInProd"] != DBNull.Value)
                                    _kpi.Defects_FoundInProd = (int)reader["Defects_FoundInProd"];
                                else
                                    _kpi.Defects_FoundInProd = 0;
                                if (reader["Defects_RetestedFailed"] != DBNull.Value)
                                    _kpi.Defects_RetestedFailed = (int)reader["Defects_RetestedFailed"];
                                else
                                    _kpi.Defects_RetestedFailed = 0;
                                if (reader["Defects_Closed"] != DBNull.Value)
                                    _kpi.DefectsClosed = (int)reader["Defects_Closed"];
                                else
                                    _kpi.DefectsClosed = 0;
                                if (reader["Tasks_Completed"] != DBNull.Value)
                                    _kpi.TasksCompleted = (string)reader["Tasks_Completed"];
                                else
                                    _kpi.TasksCompleted = "";

                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_kpi);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("ReadKPIbyID", DateTime.Now, e.Message);
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
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<KPIDM> ReadMyKPIsById(int id)
        {
            KPIDM _kpi = new KPIDM();
            List<KPIDM> kpiList = new List<KPIDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_MY_KPIS_BY_ID", SqlConnect.Connection))
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
                                _kpi.KPIID = (Int64)reader["KPI_ID"];
                                _kpi.CreateDate = (DateTime)reader["Create_Date"];
                                _kpi.Points = (int)reader["Points"];
                                _kpi.TCCreated = (int)reader["TC_Created"];
                                _kpi.TCExecuted = (int)reader["TC_Executed"];
                                _kpi.TCFailed = (int)reader["TC_Failed"];
                                _kpi.TCPassed = (int)reader["TC_Passed"];
                                _kpi.TCBlocked = (int)reader["TC_Blocked"];
                                _kpi.DefectsFound = (int)reader["Defects_Found"];
                                _kpi.DefectsFixed = (int)reader["Defects_Fixed"];
                                _kpi.DefectsAccepted = (int)reader["Defects_Accepted"];
                                _kpi.DefectsRejected = (int)reader["Defects_Rejected"];
                                _kpi.DefectsDeferred = (int)reader["Defects_Deferred"];
                                _kpi.CriticalDefects = (int)reader["Critical_Defects"];
                                _kpi.TestHrsPlanned = (decimal)reader["Test_Hrs_Planned"];
                                _kpi.TestHrsActual = (decimal)reader["Test_Hrs_Actual"];
                                _kpi.BugsFoundProduction = (int)reader["Bugs_Found_Production"];
                                _kpi.TotalHrsFixingBugs = (decimal)reader["Total_Hrs_Fixing_Bugs"];
                                _kpi.Velocity = (Int64)reader["Velocity"];
                                _kpi.Collaboration = (Int64)reader["Collaboration"];
                                _kpi.Start_Date = (DateTime)reader["Start_Date"];
                                _kpi.End_Date = (DateTime)reader["End_Date"];
                                _kpi.AssignmentId = (Int64)reader["Assignment_ID"];
                                _kpi.ProjectId = (Int64)reader["Project_ID"];
                                _kpi.SprintId = (Int64)reader["Sprint_ID"];
                                _kpi.StoryId = (Int64)reader["Story_ID"];
                                _kpi.EmployeeId = (Int64)reader["Employee_ID"];
                                _kpi.CreatedBy = (string)reader["Created_By"];
                                _kpi.Modified = (DateTime)reader["Modified"];
                                _kpi.ModifiedBy = (string)reader["Modified_By"];
                                if (reader["RTC_Passed"] != DBNull.Value)
                                    _kpi.RTCPassed = (int)reader["RTC_Passed"];
                                else
                                    _kpi.RTCPassed = 0;
                                if (reader["RTC_Failed"] != DBNull.Value)
                                    _kpi.RTCFailed = (int)reader["RTC_Failed"];
                                else
                                    _kpi.RTCFailed = 0;
                                if (reader["RTC_Created"] != DBNull.Value)
                                    _kpi.RTCCreated = (int)reader["RTC_Created"];
                                else
                                    _kpi.RTCCreated = 0;
                                if (reader["RTC_Updated"] != DBNull.Value)
                                    _kpi.RTCUpdated = (int)reader["RTC_Updated"];
                                else
                                    _kpi.RTCUpdated = 0;
                                if (reader["SprintTC_Passed"] != DBNull.Value)
                                    _kpi.SprintTC_Passed = (int)reader["SprintTC_Passed"];
                                else
                                    _kpi.SprintTC_Passed = 0;
                                if (reader["SprintTC_Failed"] != DBNull.Value)
                                    _kpi.SprintTC_Failed = (int)reader["SprintTC_Failed"];
                                else
                                    _kpi.SprintTC_Failed = 0;
                                if (reader["SprintTC_Created"] != DBNull.Value)
                                    _kpi.SprintTC_Created = (int)reader["SprintTC_Created"];
                                else
                                    _kpi.SprintTC_Created = 0;
                                if (reader["Defects_FoundInTesting"] != DBNull.Value)
                                    _kpi.Defects_FoundInTesting = (int)reader["Defects_FoundInTesting"];
                                else
                                    _kpi.Defects_FoundInTesting = 0;
                                if (reader["Defects_FoundInProd"] != DBNull.Value)
                                    _kpi.Defects_FoundInProd = (int)reader["Defects_FoundInProd"];
                                else
                                    _kpi.Defects_FoundInProd = 0;
                                if (reader["Defects_RetestedFailed"] != DBNull.Value)
                                    _kpi.Defects_RetestedFailed = (int)reader["Defects_RetestedFailed"];
                                else
                                    _kpi.Defects_RetestedFailed = 0;
                                if (reader["Defects_Closed"] != DBNull.Value)
                                    _kpi.DefectsClosed = (int)reader["Defects_Closed"];
                                else
                                    _kpi.DefectsClosed = 0;
                                if (reader["Tasks_Completed"] != DBNull.Value)
                                    _kpi.TasksCompleted = (string)reader["Tasks_Completed"];
                                else
                                    _kpi.TasksCompleted = "";


                                kpiList.Add(_kpi);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (kpiList);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("ReadMyKPIsByID", DateTime.Now, e.Message);
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
        /// <param name="_kpi"></param>
        public static void UpdateKPI(KPIDM _kpi)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_KPI", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KPI_ID", _kpi.KPIID);
                    cmd.Parameters.AddWithValue("@Create_Date", _kpi.CreateDate);
                    cmd.Parameters.AddWithValue("@Points", _kpi.Points);
                    cmd.Parameters.AddWithValue("@TC_Created", _kpi.TCCreated);
                    cmd.Parameters.AddWithValue("@TC_Executed", _kpi.TCExecuted);
                    cmd.Parameters.AddWithValue("@TC_Failed", _kpi.TCFailed);
                    cmd.Parameters.AddWithValue("@TC_Passed", _kpi.TCPassed);
                    cmd.Parameters.AddWithValue("@TC_Blocked", _kpi.TCBlocked);
                    cmd.Parameters.AddWithValue("@Defects_Found", _kpi.DefectsFound);
                    cmd.Parameters.AddWithValue("@Defects_Fixed", _kpi.DefectsFixed);
                    cmd.Parameters.AddWithValue("@Defects_Accepted", _kpi.DefectsAccepted);
                    cmd.Parameters.AddWithValue("@Defects_Rejected", _kpi.DefectsRejected);
                    cmd.Parameters.AddWithValue("@Defects_Deferred", _kpi.DefectsDeferred);
                    cmd.Parameters.AddWithValue("@Critical_Defects", _kpi.CriticalDefects);
                    cmd.Parameters.AddWithValue("@Test_Hrs_Planned", _kpi.TestHrsPlanned);
                    cmd.Parameters.AddWithValue("@Test_Hrs_Actual", _kpi.TestHrsActual);
                    cmd.Parameters.AddWithValue("@Bugs_Found_Production", _kpi.BugsFoundProduction);
                    cmd.Parameters.AddWithValue("@Total_Hrs_Fixing_Bugs", _kpi.TotalHrsFixingBugs);
                    cmd.Parameters.AddWithValue("@Velocity", _kpi.Velocity);
                    cmd.Parameters.AddWithValue("@Collaboration", _kpi.Collaboration);
                    cmd.Parameters.AddWithValue("@Start_Date", _kpi.Start_Date);
                    cmd.Parameters.AddWithValue("@End_Date", _kpi.End_Date);
                    cmd.Parameters.AddWithValue("@Assignment_ID", _kpi.AssignmentId);
                    cmd.Parameters.AddWithValue("@Project_ID", _kpi.ProjectId);
                    cmd.Parameters.AddWithValue("@Story_ID", _kpi.StoryId);
                    cmd.Parameters.AddWithValue("@Sprint_ID", _kpi.SprintId);
                    cmd.Parameters.AddWithValue("@Employee_ID", _kpi.EmployeeId);
                    cmd.Parameters.AddWithValue("@Modified", _kpi.Modified);
                    cmd.Parameters.AddWithValue("@Modified_By", _kpi.ModifiedBy);
                    cmd.Parameters.AddWithValue("@RTC_Passed", _kpi.RTCPassed);
                    cmd.Parameters.AddWithValue("@RTC_Failed", _kpi.RTCFailed);
                    cmd.Parameters.AddWithValue("@RTC_Created", _kpi.RTCCreated);
                    cmd.Parameters.AddWithValue("@RTC_Updated", _kpi.RTCUpdated);
                    cmd.Parameters.AddWithValue("@SprintTC_Passed", _kpi.SprintTC_Passed);
                    cmd.Parameters.AddWithValue("@SprintTC_Failed", _kpi.SprintTC_Failed);
                    cmd.Parameters.AddWithValue("@SprintTC_Created", _kpi.SprintTC_Created);
                    cmd.Parameters.AddWithValue("@Defects_FoundInTesting", _kpi.Defects_FoundInTesting);
                    cmd.Parameters.AddWithValue("@Defects_FoundInProd", _kpi.Defects_FoundInProd);
                    cmd.Parameters.AddWithValue("@Defects_RetestedFailed", _kpi.Defects_RetestedFailed);
                    cmd.Parameters.AddWithValue("@Defects_Closed", _kpi.DefectsClosed);
                    if (_kpi.TasksCompleted != null)
                    {
                        cmd.Parameters.AddWithValue("@Tasks_Completed", _kpi.TasksCompleted);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Tasks_Completed", DBNull.Value);
                    }
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateKPI", DateTime.Now, e.Message);
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
        /// <param name="_kpi"></param>
        public static void DeleteKPI(KPIDM _kpi)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_KPI", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KPI_ID", _kpi.KPIID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("DeleteKPI", DateTime.Now, e.Message);
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
