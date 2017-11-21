using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class AssessmentDAL
    {
        #region Assessment DAL Methods
        private static ErrorLog errorLog = new ErrorLog();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_assessment"></param>
        public static void CreateAssessment(AssessmentDM _assessment)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_ASSESSMENT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TD_Problem_Solving", _assessment.TDProblemSolving);
                    cmd.Parameters.AddWithValue("@TD_Quality_of_Work", _assessment.TDQualityOfWork);
                    cmd.Parameters.AddWithValue("@TD_Productivity", _assessment.TDProductivity);
                    cmd.Parameters.AddWithValue("@TD_Product_Knowledge", _assessment.TDProductKnowledge);
                    if (_assessment.TDComments != null)
                        cmd.Parameters.AddWithValue("@TD_Comments", _assessment.TDComments);
                    else
                        cmd.Parameters.AddWithValue("@TD_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CSR_Professionalism_Teamwork", _assessment.CSRProfesionalismTeamwork);
                    cmd.Parameters.AddWithValue("@CSR_Verbal_Skills", _assessment.CSRVerbalSkills);
                    cmd.Parameters.AddWithValue("@CSR_Written_Skills", _assessment.CSRWrittenSkills);
                    cmd.Parameters.AddWithValue("@CSR_Listening_Skills", _assessment.CSRListeningSkills);
                    if (_assessment.CSRComments != null)
                        cmd.Parameters.AddWithValue("@CSR_Comments", _assessment.CSRComments);
                    else
                        cmd.Parameters.AddWithValue("@CSR_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@AD_Attendence", _assessment.ADAttendence);
                    cmd.Parameters.AddWithValue("@AD_Ethical_Behavior", _assessment.ADEthicalBehavior);
                    cmd.Parameters.AddWithValue("@AD_Meet_Deadlines", _assessment.ADMeetDeadlines);
                    cmd.Parameters.AddWithValue("@AD_Organize_Detailed_Work", _assessment.ADOrganizeDetailedWork);
                    if (_assessment.ADComments != null)
                        cmd.Parameters.AddWithValue("@AD_Comments", _assessment.ADComments);
                    else
                        cmd.Parameters.AddWithValue("@AD_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TM_Resource_Use", _assessment.TMResourceUse);
                    cmd.Parameters.AddWithValue("@TM_Feedback", _assessment.TMFeedback);
                    cmd.Parameters.AddWithValue("@TM_TechnicalMonitoring", _assessment.TMTechnicalMonitoring);
                    cmd.Parameters.AddWithValue("@TM_Asking_Questions", _assessment.TMAskingQuestions);
                    if (_assessment.TMComments != null)
                        cmd.Parameters.AddWithValue("@TM_Comments", _assessment.TMComments);
                    else
                        cmd.Parameters.AddWithValue("@TM_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@MI_Attitude_Work", _assessment.MIAttitudeWork);
                    cmd.Parameters.AddWithValue("@MI_Grooming_Appearance", _assessment.MIGroomingAppearance);
                    cmd.Parameters.AddWithValue("@MI_Personal_Growth", _assessment.MIPersonalGrowth);
                    cmd.Parameters.AddWithValue("@MI_Potential_Advancement", _assessment.MIPotentialAdvancement);
                    if (_assessment.MIComments != null)
                        cmd.Parameters.AddWithValue("@MI_Comments", _assessment.MIComments);
                    else
                        cmd.Parameters.AddWithValue("@MI_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Employee_ID", _assessment.EmployeeID);
                    cmd.Parameters.AddWithValue("@Created", _assessment.Created.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Created_By", _assessment.CreatedBy);
                    cmd.Parameters.AddWithValue("@Modified", _assessment.Modified.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Modified_By", _assessment.ModifiedBy);
                    cmd.Parameters.AddWithValue("@DateCreatedFor", _assessment.DateCreatedFor.ToShortDateString());
                    cmd.Parameters.AddWithValue("@AssessmentScore", _assessment.AssessmentScore);

                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                errorLog.ErrorLogger("CreateAssessment", DateTime.Now, e.Message);
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
        public static List<AssessmentDM> ReadAssessments()
        {
            List<AssessmentDM> assessmentList = new List<AssessmentDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_ASSESSMENTS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var _assessment = new AssessmentDM();
                                _assessment.AssessmentId = (Int64)reader["Assessment_ID"];
                                _assessment.TDProblemSolving = (int)reader["TD_Problem_Solving"];
                                _assessment.TDQualityOfWork = (int)reader["TD_Quality_Of_Work"];
                                _assessment.TDProductivity = (int)reader["TD_Productivity"];
                                _assessment.TDProductKnowledge = (int)reader["TD_Product_Knowledge"];
                                if (reader["TD_Comments"] != DBNull.Value)
                                    _assessment.TDComments = (string)reader["TD_Comments"];
                                else
                                    _assessment.TDComments = "";
                                _assessment.CSRProfesionalismTeamwork = (int)reader["CSR_Professionalism_Teamwork"];
                                _assessment.CSRVerbalSkills = (int)reader["CSR_Verbal_Skills"];
                                _assessment.CSRWrittenSkills = (int)reader["CSR_Written_Skills"];
                                _assessment.CSRListeningSkills = (int)reader["CSR_Listening_Skills"];
                                if (reader["CSR_Comments"] != DBNull.Value)
                                    _assessment.CSRComments = (string)reader["CSR_Comments"];
                                else
                                    _assessment.CSRComments = "";
                                _assessment.ADAttendence = (int)reader["AD_Attendence"];
                                _assessment.ADEthicalBehavior = (int)reader["AD_Ethical_Behavior"];
                                _assessment.ADMeetDeadlines = (int)reader["AD_Meet_Deadlines"];
                                _assessment.ADOrganizeDetailedWork = (int)reader["AD_Organize_Detailed_Work"];
                                if (reader["AD_Comments"] != DBNull.Value)
                                    _assessment.ADComments = (string)reader["AD_Comments"];
                                else
                                    _assessment.ADComments = "";
                                _assessment.TMResourceUse = (int)reader["TM_Resource_Use"];
                                _assessment.TMFeedback = (int)reader["TM_Feedback"];
                                _assessment.TMTechnicalMonitoring = (int)reader["TM_Technical_Monitoring"];
                                _assessment.TMAskingQuestions = (int)reader["TM_Asking_Questions"];
                                if (reader["TM_Comments"] != DBNull.Value)
                                    _assessment.TMComments = (string)reader["TM_Comments"];
                                else
                                    _assessment.TMComments = "";
                                _assessment.MIAttitudeWork = (int)reader["MI_Attitude_Work"];
                                _assessment.MIGroomingAppearance = (int)reader["MI_Grooming_Appearance"];
                                _assessment.MIPersonalGrowth = (int)reader["MI_Personal_Growth"];
                                _assessment.MIPotentialAdvancement = (int)reader["MI_Potential_Advancement"];
                                if (reader["MI_Comments"] != DBNull.Value)
                                    _assessment.MIComments = (string)reader["MI_Comments"];
                                else
                                    _assessment.MIComments = "";

                                _assessment.EmployeeID = (Int64)reader["Employee_ID"];
                                _assessment.Created = (DateTime)reader["Created"];
                                _assessment.CreatedBy = (string)reader["Created_By"];
                                _assessment.Modified = (DateTime)reader["Modified"];
                                _assessment.ModifiedBy = (string)reader["Modified_By"];
                                _assessment.DateCreatedFor = (DateTime)reader["DateCreatedFor"];

                                _assessment.EmployeeID = (Int64)reader["Employee_ID"];
                                _assessment.Created = (DateTime)reader["Created"];
                                _assessment.CreatedBy = (string)reader["Created_By"];
                                _assessment.Modified = (DateTime)reader["Modified"];
                                _assessment.ModifiedBy = (string)reader["Modified_By"];
                                _assessment.AssessmentScore = (int)reader["AssessmentScore"];

                                assessmentList.Add(_assessment);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (assessmentList);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("ReadAssessments", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns></returns>
        public static AssessmentDM ReadAssessmentByID(int assessmentId)
        {
            try
            {
                AssessmentDM _assessment = new AssessmentDM();
                using (SqlCommand cmd = new SqlCommand("READ_ASSESSMENT_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Assessment_ID", assessmentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _assessment.AssessmentId = (Int64)reader["Assessment_ID"];
                                _assessment.TDProblemSolving = (int)reader["TD_Problem_Solving"];
                                _assessment.TDQualityOfWork = (int)reader["TD_Quality_Of_Work"];
                                _assessment.TDProductivity = (int)reader["TD_Productivity"];
                                _assessment.TDProductKnowledge = (int)reader["TD_Product_Knowledge"];
                                if (reader["TD_Comments"] != DBNull.Value)
                                    _assessment.TDComments = (string)reader["TD_Comments"];
                                else
                                    _assessment.TDComments = "";
                                _assessment.CSRProfesionalismTeamwork = (int)reader["CSR_Professionalism_Teamwork"];
                                _assessment.CSRVerbalSkills = (int)reader["CSR_Verbal_Skills"];
                                _assessment.CSRWrittenSkills = (int)reader["CSR_Written_Skills"];
                                _assessment.CSRListeningSkills = (int)reader["CSR_Listening_Skills"];
                                if (reader["CSR_Comments"] != DBNull.Value)
                                    _assessment.CSRComments = (string)reader["CSR_Comments"];
                                else
                                    _assessment.CSRComments = "";
                                _assessment.ADAttendence = (int)reader["AD_Attendence"];
                                _assessment.ADEthicalBehavior = (int)reader["AD_Ethical_Behavior"];
                                _assessment.ADMeetDeadlines = (int)reader["AD_Meet_Deadlines"];
                                _assessment.ADOrganizeDetailedWork = (int)reader["AD_Organize_Detailed_Work"];
                                if (reader["AD_Comments"] != DBNull.Value)
                                    _assessment.ADComments = (string)reader["AD_Comments"];
                                else
                                    _assessment.ADComments = "";
                                _assessment.TMResourceUse = (int)reader["TM_Resource_Use"];
                                _assessment.TMFeedback = (int)reader["TM_Feedback"];
                                _assessment.TMTechnicalMonitoring = (int)reader["TM_Technical_Monitoring"];
                                _assessment.TMAskingQuestions = (int)reader["TM_Asking_Questions"];
                                if (reader["TM_Comments"] != DBNull.Value)
                                    _assessment.TMComments = (string)reader["TM_Comments"];
                                else
                                    _assessment.TMComments = "";
                                _assessment.MIAttitudeWork = (int)reader["MI_Attitude_Work"];
                                _assessment.MIGroomingAppearance = (int)reader["MI_Grooming_Appearance"];
                                _assessment.MIPersonalGrowth = (int)reader["MI_Personal_Growth"];
                                _assessment.MIPotentialAdvancement = (int)reader["MI_Potential_Advancement"];
                                if (reader["MI_Comments"] != DBNull.Value)
                                    _assessment.MIComments = (string)reader["MI_Comments"];
                                else
                                    _assessment.MIComments = "";
                                _assessment.EmployeeID = (Int64)reader["Employee_ID"];
                                _assessment.Created = (DateTime)reader["Created"];
                                _assessment.CreatedBy = (string)reader["Created_By"];
                                _assessment.Modified = (DateTime)reader["Modified"];
                                _assessment.ModifiedBy = (string)reader["Modified_By"];
                                _assessment.DateCreatedFor = (DateTime)reader["DateCreatedFor"];
                                _assessment.AssessmentScore = (int)reader["AssessmentScore"];

                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_assessment);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("ReadAssessmentByID", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static List<AssessmentDM> ReadMyAssessmentsByID(long employeeId)
        {
            try
            {
                AssessmentDM _assessment = new AssessmentDM();
                List<AssessmentDM> assessmentList = new List<AssessmentDM>();
                using (SqlCommand cmd = new SqlCommand("READ_MY_ASSESSMENTS_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Employee_ID", employeeId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _assessment.AssessmentId = (Int64)reader["Assessment_ID"];
                                _assessment.TDProblemSolving = (int)reader["TD_Problem_Solving"];
                                _assessment.TDQualityOfWork = (int)reader["TD_Quality_Of_Work"];
                                _assessment.TDProductivity = (int)reader["TD_Productivity"];
                                _assessment.TDProductKnowledge = (int)reader["TD_Product_Knowledge"];
                                if (reader["TD_Comments"] != DBNull.Value)
                                    _assessment.TDComments = (string)reader["TD_Comments"];
                                else
                                    _assessment.TDComments = "";
                                _assessment.CSRProfesionalismTeamwork = (int)reader["CSR_Professionalism_Teamwork"];
                                _assessment.CSRVerbalSkills = (int)reader["CSR_Verbal_Skills"];
                                _assessment.CSRWrittenSkills = (int)reader["CSR_Written_Skills"];
                                _assessment.CSRListeningSkills = (int)reader["CSR_Listening_Skills"];
                                if (reader["CSR_Comments"] != DBNull.Value)
                                    _assessment.CSRComments = (string)reader["CSR_Comments"];
                                else
                                    _assessment.CSRComments = "";
                                _assessment.ADAttendence = (int)reader["AD_Attendence"];
                                _assessment.ADEthicalBehavior = (int)reader["AD_Ethical_Behavior"];
                                _assessment.ADMeetDeadlines = (int)reader["AD_Meet_Deadlines"];
                                _assessment.ADOrganizeDetailedWork = (int)reader["AD_Organize_Detailed_Work"];
                                if (reader["AD_Comments"] != DBNull.Value)
                                    _assessment.ADComments = (string)reader["AD_Comments"];
                                else
                                    _assessment.ADComments = "";
                                _assessment.TMResourceUse = (int)reader["TM_Resource_Use"];
                                _assessment.TMFeedback = (int)reader["TM_Feedback"];
                                _assessment.TMTechnicalMonitoring = (int)reader["TM_Technical_Monitoring"];
                                _assessment.TMAskingQuestions = (int)reader["TM_Asking_Questions"];
                                if (reader["TM_Comments"] != DBNull.Value)
                                    _assessment.TMComments = (string)reader["TM_Comments"];
                                else
                                    _assessment.TMComments = "";
                                _assessment.MIAttitudeWork = (int)reader["MI_Attitude_Work"];
                                _assessment.MIGroomingAppearance = (int)reader["MI_Grooming_Appearance"];
                                _assessment.MIPersonalGrowth = (int)reader["MI_Personal_Growth"];
                                _assessment.MIPotentialAdvancement = (int)reader["MI_Potential_Advancement"];
                                if (reader["MI_Comments"] != DBNull.Value)
                                    _assessment.MIComments = (string)reader["MI_Comments"];
                                else
                                    _assessment.MIComments = "";
                                _assessment.EmployeeID = (Int64)reader["Employee_ID"];
                                _assessment.Created = (DateTime)reader["Created"];
                                _assessment.CreatedBy = (string)reader["Created_By"];
                                _assessment.Modified = (DateTime)reader["Modified"];
                                _assessment.ModifiedBy = (string)reader["Modified_By"];
                                _assessment.DateCreatedFor = (DateTime)reader["DateCreatedFor"];
                                _assessment.AssessmentScore = (int)reader["AssessmentScore"];

                                assessmentList.Add(_assessment);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (assessmentList);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("ReadMyAssessmentByID", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<DescriptionDM> ReadAssessDescriptions()
        {
            List<DescriptionDM> descriptions = new List<DescriptionDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_ASSESSMENT_DESCRIPTIONS", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                DescriptionDM info = new DescriptionDM()
                                {
                                    AssessName = (string)reader["AssessmentName"],
                                    Number = (int)reader["Number"],
                                    Name = (string)reader["Name"],
                                    Desc = (string)reader["Description"],
                                };
                                descriptions.Add(info);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (descriptions);
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("ReadAssessDescriptions", DateTime.Now, e.Message);
                throw (e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_assessment"></param>
        public static void UpdateAssessment(AssessmentDM _assessment)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_ASSESSMENT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Assessment_ID", _assessment.AssessmentId);
                    cmd.Parameters.AddWithValue("@TD_Problem_Solving", _assessment.TDProblemSolving);
                    cmd.Parameters.AddWithValue("@TD_Quality_of_Work", _assessment.TDQualityOfWork);
                    cmd.Parameters.AddWithValue("@TD_Productivity", _assessment.TDProductivity);
                    cmd.Parameters.AddWithValue("@TD_Product_Knowledge", _assessment.TDProductKnowledge);
                    if (_assessment.TDComments != null)
                        cmd.Parameters.AddWithValue("@TD_Comments", _assessment.TDComments);
                    else
                        cmd.Parameters.AddWithValue("@TD_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CSR_Professionalism_Teamwork", _assessment.CSRProfesionalismTeamwork);
                    cmd.Parameters.AddWithValue("@CSR_Verbal_Skills", _assessment.CSRVerbalSkills);
                    cmd.Parameters.AddWithValue("@CSR_Written_Skills", _assessment.CSRWrittenSkills);
                    cmd.Parameters.AddWithValue("@CSR_Listening_Skills", _assessment.CSRListeningSkills);
                    if (_assessment.CSRComments != null)
                        cmd.Parameters.AddWithValue("@CSR_Comments", _assessment.CSRComments);
                    else
                        cmd.Parameters.AddWithValue("@CSR_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@AD_Attendence", _assessment.ADAttendence);
                    cmd.Parameters.AddWithValue("@AD_Ethical_Behavior", _assessment.ADEthicalBehavior);
                    cmd.Parameters.AddWithValue("@AD_Meet_Deadlines", _assessment.ADMeetDeadlines);
                    cmd.Parameters.AddWithValue("@AD_Organize_Detailed_Work", _assessment.ADOrganizeDetailedWork);
                    if (_assessment.ADComments != null)
                        cmd.Parameters.AddWithValue("@AD_Comments", _assessment.ADComments);
                    else
                        cmd.Parameters.AddWithValue("@AD_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TM_Resource_Use", _assessment.TMResourceUse);
                    cmd.Parameters.AddWithValue("@TM_Feedback", _assessment.TMFeedback);
                    cmd.Parameters.AddWithValue("@TM_TechnicalMonitoring", _assessment.TMTechnicalMonitoring);
                    cmd.Parameters.AddWithValue("@TM_Asking_Questions", _assessment.TMAskingQuestions);
                    if (_assessment.TMComments != null)
                        cmd.Parameters.AddWithValue("@TM_Comments", _assessment.TMComments);
                    else
                        cmd.Parameters.AddWithValue("@TM_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@MI_Attitude_Work", _assessment.MIAttitudeWork);
                    cmd.Parameters.AddWithValue("@MI_Grooming_Appearance", _assessment.MIGroomingAppearance);
                    cmd.Parameters.AddWithValue("@MI_Personal_Growth", _assessment.MIPersonalGrowth);
                    cmd.Parameters.AddWithValue("@MI_Potential_Advancement", _assessment.MIPotentialAdvancement);
                    if (_assessment.MIComments != null)
                        cmd.Parameters.AddWithValue("@MI_Comments", _assessment.MIComments);
                    else
                        cmd.Parameters.AddWithValue("@MI_Comments", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Employee_ID", _assessment.EmployeeID);
                    cmd.Parameters.AddWithValue("@Modified", _assessment.Modified.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Modified_By", _assessment.ModifiedBy);
                    cmd.Parameters.AddWithValue("@DateCreatedFor", _assessment.DateCreatedFor);
                    cmd.Parameters.AddWithValue("@AssessmentScore", _assessment.AssessmentScore);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("UpdateAssessment", DateTime.Now, e.Message);
                throw (e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_assessment"></param>
        public static void DeleteAssessment(AssessmentDM _assessment)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_ASSESSMENT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Assessment_ID", _assessment.AssessmentId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("DeleteAssessment", DateTime.Now, e.Message);
                throw (e);
            }
        }

        #endregion
    }
}
