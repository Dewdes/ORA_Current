using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class ResumeDAL
    {
        private static ErrorLog errorLog = new ErrorLog();
        #region CREATE METHODS

        /// <summary>
        /// Creates a blank resume on employee account creation for the employee to utilize later
        /// Uses the CREATE_RESUME stored procedure
        /// </summary>
        /// <param name="_resume"></param>
        /// <param name="empID"></param>
        public static void CreateResume(long empID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_RESUME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", empID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateResume", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Updates education fields in the Education table
        /// Uses the UPDATE_EDUCATION stored procedure
        /// </summary>
        /// <param name="_education"></param>
        public static void CreateEducation(EducationDM _education, int resumeID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_EDUCATION", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Institution_Name", _education.InsitutionName);
                    cmd.Parameters.AddWithValue("@Attended_Start_Date", _education.Attended_Start_Date);
                    cmd.Parameters.AddWithValue("@Attended_End_Date", _education.Attended_End_Date);
                    cmd.Parameters.AddWithValue("@Institution_Location", _education.InstitutionLocation ?? "Default");
                    cmd.Parameters.AddWithValue("@Education_Earned", _education.EducationEarned ?? "Default");
                    cmd.Parameters.AddWithValue("@Area_Of_Study", _education.AreaOfStudy ?? "Default");
                    cmd.Parameters.AddWithValue("@Resume_ID", resumeID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateEducation", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Updates Skill fields in the Skills table
        /// Uses the UPDATE_SKILLS stored procedure
        /// </summary>
        /// <param name="_skills"></param>
        public static void CreateSkills(SkillsDM _skills)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_SKILLS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Skills_1", _skills.Skill_1);
                    cmd.Parameters.AddWithValue("@Skill_1_Proficiency", _skills.Skill_1_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_2", _skills.Skill_2);
                    cmd.Parameters.AddWithValue("@Skill_2_Proficiency", _skills.Skill_2_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_3", _skills.Skill_3);
                    cmd.Parameters.AddWithValue("@Skill_3_Proficiency", _skills.Skill_3_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_4", _skills.Skill_4);
                    cmd.Parameters.AddWithValue("@Skill_4_Proficiency", _skills.Skill_4_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_5", _skills.Skill_5);
                    cmd.Parameters.AddWithValue("@Skill_5_Proficiency", _skills.Skill_5_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_6", _skills.Skill_6);
                    cmd.Parameters.AddWithValue("@Skill_6_Proficiency", _skills.Skill_6_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_7", _skills.Skill_7);
                    cmd.Parameters.AddWithValue("@Skill_7_Proficiency", _skills.Skill_7_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_8", _skills.Skill_8);
                    cmd.Parameters.AddWithValue("@Skill_8_Proficiency", _skills.Skill_8_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_9", _skills.Skill_9);
                    cmd.Parameters.AddWithValue("@Skill_9_Proficiency", _skills.Skill_9_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_10", _skills.Skill_10);
                    cmd.Parameters.AddWithValue("@Skill_10_Proficiency", _skills.Skill_10_Proficiency);
                    cmd.Parameters.AddWithValue("@Resume_ID", _skills.ResumeID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateSkills", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Updates the work history fields in the WorkHistory table
        /// Uses the UPDATE_WORK_HISTORY stored procedure
        /// </summary>
        /// <param name="_workHistory"></param>
        public static void CreateWorkHistory(WorkHistoryDM _workHistory, long resumeID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_WORK_HISTORY", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Organization_Name", _workHistory.OrganizationName);
                    cmd.Parameters.AddWithValue("@Work_Place_Start_Date", _workHistory.WorkPlaceStartDate);
                    cmd.Parameters.AddWithValue("@Work_Place_End_Date", _workHistory.WorkPlaceEndDate);
                    cmd.Parameters.AddWithValue("@Job_Description", _workHistory.JobDescription);
                    cmd.Parameters.AddWithValue("@Work_Place_Location", _workHistory.WorkPlaceLocation);
                    cmd.Parameters.AddWithValue("@Resume_ID", _workHistory.ResumeID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateWorkHistory", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        #endregion

        #region READ METHODS

        /// <summary>
        ///This will grab the employee resume from the resume table where the employee ID foreign key is equal to the current logged in users ID (i.e users employee ID)
        /// Uses the READ_RESUME stored procedure
        /// </summary>
        /// <param name="resumeID"></param>
        /// <param name="empID"></param>
        /// <returns></returns>
        public static ResumeDM GetResumeByID(long empID)
        {
            ResumeDM _resume = new ResumeDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("VIEW_RESUME_BY_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", empID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _resume.ResumeID = (int)reader["Resume_ID"];
                                _resume.EmployeeID = (long)reader["Employee_ID"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_resume);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("GetResumeByID", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// This gets a resume based on the employee id given
        /// Uses the READ_RESUME_ID
        /// </summary>
        /// <param name="employeeNum"></param>
        /// <returns></returns>
        public static int ReadResumeId(long employeeNum)
        {
            try
            {
                ResumeDM _resume = new ResumeDM();
                using (SqlCommand command = new SqlCommand("READ_RESUME_ID", SqlConnect.Connection))
                {
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Employee_ID", employeeNum);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _resume.ResumeID = (int)reader["Resume_ID"];
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return _resume.ResumeID;
            }
            catch (Exception ex)
            {
                errorLog.ErrorLogger("ReadResumeId", DateTime.Now, ex.Message);
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// This gets ALL the Education fields that has a unique resume key that is attached to a single employee
        /// Uses the VIEW_EDUCATION_BY_RESUME_ID stored procedure
        /// </summary>
        /// <param name="resumeID"></param>
        /// <returns></returns>
        public static List<EducationDM> GetListOfEducationsByResumeID(int resumeID)
        {
            List<EducationDM> educationList = new List<EducationDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("VIEW_EDUCATION_BY_RESUME_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", resumeID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                EducationDM _education = new EducationDM();

                                _education.ResumeID = (int)reader["Resume_ID"];
                                _education.EducationID = (int)reader["Education_ID"];
                                _education.InsitutionName = (string)reader["Institution_Name"];
                                _education.Attended_Start_Date = (DateTime)reader["Attended_Start_Date"];
                                _education.Attended_End_Date = (DateTime)reader["Attended_End_Date"];
                                _education.AreaOfStudy = (string)reader["Area_Of_Study"];
                                _education.EducationEarned = (string)reader["Education_Earned"];
                                _education.InstitutionLocation = (string)reader["Institution_Location"];

                                educationList.Add(_education);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (educationList);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("GetEducationByResumeID", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// This gets a single Education row that has a unique resume key that is attached to a single employee
        /// Uses the VIEW_EDUCATION_BY_RESUME_ID stored procedure
        /// </summary>
        /// <param name="resumeID"></param>
        /// <returns></returns>
        public static EducationDM GetEducationsByResumeID(int resumeID)
        {
            EducationDM _education = new EducationDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("VIEW_EDUCATION_BY_RESUME_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", resumeID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _education.ResumeID = (int)reader["Resume_ID"];
                                _education.EducationID = (int)reader["Education_ID"];
                                _education.InsitutionName = (string)reader["Institution_Name"];
                                _education.Attended_Start_Date = (DateTime)reader["Attended_Start_Date"];
                                _education.Attended_End_Date = (DateTime)reader["Attended_End_Date"];
                                _education.AreaOfStudy = (string)reader["Area_Of_Study"];
                                _education.EducationEarned = (string)reader["Education_Earned"];
                                _education.InstitutionLocation = (string)reader["Institution_Location"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_education);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("GetEducationByResumeID", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// This gets the WorkHistory fields that has a unique resume key that is attached to a single employee
        /// Uses the VIEW_WORK_HISTORY_BY_RESUME_ID stored procedure
        /// </summary>
        /// <param name="resumeID"></param>
        /// <returns></returns>
        public static List<WorkHistoryDM> GetListOfWorkHistoryByResumeID(int resumeID)
        {
            List<WorkHistoryDM> workHistoryList = new List<WorkHistoryDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("VIEW_WORK_HISTORY_BY_RESUME_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", resumeID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                WorkHistoryDM _workHistory = new WorkHistoryDM();
                                _workHistory.ResumeID = (int)reader["Resume_ID"];
                                _workHistory.WorkHistoryID = (int)reader["Work_History_ID"];
                                _workHistory.OrganizationName = (string)reader["Organization_Name"];
                                _workHistory.JobDescription = (string)reader["Job_Description"];
                                _workHistory.WorkPlaceStartDate = (DateTime)reader["Work_Place_Start_Date"];
                                _workHistory.WorkPlaceEndDate = (DateTime)reader["Work_Place_End_Date"];
                                _workHistory.WorkPlaceLocation = (string)reader["Work_Place_Location"];

                                workHistoryList.Add(_workHistory);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (workHistoryList);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("GetWorkHistoryByResumeID", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// This gets the Skills fields that has a unique resume key that is attached to a single employee
        /// Uses the VIEW_SKILLS_BY_RESUME_ID stored procedure
        /// </summary>
        /// <param name="resumeID"></param>
        /// <returns></returns>
        public static SkillsDM GetSkillsByResumeID(int resumeID)
        {
            SkillsDM _skills = new SkillsDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("VIEW_SKILLS_BY_RESUME_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", resumeID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _skills.ResumeID = (int)reader["Resume_ID"];
                                _skills.Skills_ID = (int)reader["Skills_ID"];
                                _skills.Skill_1 = (string)reader["Skill_1"];
                                _skills.Skill_1_Proficiency = (int)reader["Skill_1_Proficiency"];
                                _skills.Skill_2 = (string)reader["Skill_2"];
                                _skills.Skill_2_Proficiency = (int)reader["Skill_2_Proficiency"];
                                _skills.Skill_3 = (string)reader["Skill_3"];
                                _skills.Skill_3_Proficiency = (int)reader["Skill_3_Proficiency"];
                                _skills.Skill_4 = (string)reader["Skill_4"];
                                _skills.Skill_4_Proficiency = (int)reader["Skill_4_Proficiency"];
                                _skills.Skill_5 = (string)reader["Skill_5"];
                                _skills.Skill_5_Proficiency = (int)reader["Skill_5_Proficiency"];
                                _skills.Skill_6 = (string)reader["Skill_6"];
                                _skills.Skill_6_Proficiency = (int)reader["Skill_6_Proficiency"];
                                _skills.Skill_7 = (string)reader["Skill_7"];
                                _skills.Skill_7_Proficiency = (int)reader["Skill_7_Proficiency"];
                                _skills.Skill_8 = (string)reader["Skill_8"];
                                _skills.Skill_8_Proficiency = (int)reader["Skill_8_Proficiency"];
                                _skills.Skill_9 = (string)reader["Skill_9"];
                                _skills.Skill_9_Proficiency = (int)reader["Skill_9_Proficiency"];
                                _skills.Skill_10 = (string)reader["Skill_10"];
                                _skills.Skill_10_Proficiency = (int)reader["Skill_10_Proficiency"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_skills);
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("GetSkillsByResumeID", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }
        #endregion

        #region UPDATE METHODS
        /// <summary>
        /// Blank resumes are already built on account creation
        /// Uses the UPDATE_RESUME stored procedure
        /// </summary>
        /// <param name="_resume"></param>
        /// <param name="empID"></param>
        public static void UpdateResume(ResumeDM _resume, long empID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_RESUME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", _resume.ResumeID);
                    cmd.Parameters.AddWithValue("@Employee_ID", _resume.EmployeeID = empID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateResume", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Updates education fields in the Education table
        /// Uses the UPDATE_EDUCATION stored procedure
        /// </summary>
        /// <param name="_education"></param>
        public static void UpdateEducation(EducationDM _education, long resumeID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_EDUCATION", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", resumeID);

                    if (_education.InsitutionName != null)
                        cmd.Parameters.AddWithValue("@Institution_Name", _education.InsitutionName);
                    else
                        cmd.Parameters.AddWithValue("@Institution_Name", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Attended_Start_Date", _education.Attended_Start_Date);
                    cmd.Parameters.AddWithValue("@Attended_End_Date", _education.Attended_End_Date);


                    if (_education.InstitutionLocation != null)
                        cmd.Parameters.AddWithValue("@Institution_Location", _education.InstitutionLocation);
                    else
                        cmd.Parameters.AddWithValue("@Institution_Location", DBNull.Value);

                    if (_education.EducationEarned != null)
                        cmd.Parameters.AddWithValue("@Education_Earned", _education.EducationEarned);
                    else
                        cmd.Parameters.AddWithValue("@Education_Earned", DBNull.Value);

                    if (_education.AreaOfStudy != null)
                        cmd.Parameters.AddWithValue("@Area_Of_Study", _education.AreaOfStudy);
                    else
                        cmd.Parameters.AddWithValue("@Area_Of_Study", DBNull.Value);

                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateEducation", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Updates Skill fields in the Skills table
        /// Uses the UPDATE_SKILLS stored procedure
        /// </summary>
        /// <param name="_skills"></param>
        public static void UpdateSkills(SkillsDM _skills, long resumeID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_SKILLS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", resumeID);
                    if (_skills.Skill_1 != null)
                        cmd.Parameters.AddWithValue("@Skill_1", _skills.Skill_1);
                    else
                        cmd.Parameters.AddWithValue("@Skill_1", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_1_Proficiency", _skills.Skill_1_Proficiency);

                    if (_skills.Skill_2 != null)
                        cmd.Parameters.AddWithValue("@Skill_2", _skills.Skill_2);
                    else
                        cmd.Parameters.AddWithValue("@Skill_2", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_2_Proficiency", _skills.Skill_2_Proficiency);

                    if (_skills.Skill_3 != null)
                        cmd.Parameters.AddWithValue("@Skill_3", _skills.Skill_3);
                    else
                        cmd.Parameters.AddWithValue("@Skill_3", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_3_Proficiency", _skills.Skill_3_Proficiency);

                    if (_skills.Skill_4 != null)
                        cmd.Parameters.AddWithValue("@Skill_4", _skills.Skill_4);
                    else
                        cmd.Parameters.AddWithValue("@Skill_4", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_4_Proficiency", _skills.Skill_4_Proficiency);

                    if (_skills.Skill_5 != null)
                        cmd.Parameters.AddWithValue("@Skill_5", _skills.Skill_5);
                    else
                        cmd.Parameters.AddWithValue("@Skill_5", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_5_Proficiency", _skills.Skill_5_Proficiency);

                    if (_skills.Skill_6 != null)
                        cmd.Parameters.AddWithValue("@Skill_6", _skills.Skill_6);
                    else
                        cmd.Parameters.AddWithValue("@Skill_6", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_6_Proficiency", _skills.Skill_6_Proficiency);

                    if (_skills.Skill_7 != null)
                        cmd.Parameters.AddWithValue("@Skill_7", _skills.Skill_7);
                    else
                        cmd.Parameters.AddWithValue("@Skill_7", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_7_Proficiency", _skills.Skill_7_Proficiency);

                    if (_skills.Skill_8 != null)
                        cmd.Parameters.AddWithValue("@Skill_8", _skills.Skill_8);
                    else
                        cmd.Parameters.AddWithValue("@Skill_8", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_8_Proficiency", _skills.Skill_8_Proficiency);

                    if (_skills.Skill_9 != null)
                        cmd.Parameters.AddWithValue("@Skill_9", _skills.Skill_9);
                    else
                        cmd.Parameters.AddWithValue("@Skill_9", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_9_Proficiency", _skills.Skill_9_Proficiency);

                    if (_skills.Skill_10 != null)
                        cmd.Parameters.AddWithValue("@Skill_10", _skills.Skill_10);
                    else
                        cmd.Parameters.AddWithValue("@Skill_10", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Skill_10_Proficiency", _skills.Skill_10_Proficiency);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateSkills", DateTime.Now, e.Message);
                throw (e);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        /// <summary>
        /// Updates the work history fields in the WorkHistory table
        /// Uses the UPDATE_WORK_HISTORY stored procedure
        /// </summary>
        /// <param name="_workHistory"></param>
        public static void UpdateWorkHistory(WorkHistoryDM _workHistory, long resumeID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_WORK_HISTORY", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", resumeID);

                    if (_workHistory.OrganizationName != null)
                        cmd.Parameters.AddWithValue("@Organization_Name", _workHistory.OrganizationName);
                    else
                        cmd.Parameters.AddWithValue("@Organization_Name", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Work_Place_Start_Date", _workHistory.WorkPlaceStartDate);
                    cmd.Parameters.AddWithValue("@Work_Place_End_Date", _workHistory.WorkPlaceEndDate);

                    if (_workHistory.JobDescription != null)
                        cmd.Parameters.AddWithValue("@Job_Description", _workHistory.JobDescription);
                    else
                        cmd.Parameters.AddWithValue("@Job_Description", DBNull.Value);

                    if (_workHistory.WorkPlaceLocation != null)
                        cmd.Parameters.AddWithValue("@Work_Place_Location", _workHistory.WorkPlaceLocation);
                    else
                        cmd.Parameters.AddWithValue("@Work_Place_Location", DBNull.Value);

                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("UpdateWorkHistory", DateTime.Now, e.Message);
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
