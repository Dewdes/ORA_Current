﻿using ORA.Models;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ORA_DAL.DAL
{
    class AssessmentDAL
    {
        #region Assessment DAL Methods
        public void CreateAssessment(AssessmentDM _assessment)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_ASSESSMENT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TD_Problem_Solving", _assessment.TDProblemSolving);
                        cmd.Parameters.AddWithValue("@TD_Quality_of_Work", _assessment.TDQualityOfWork);
                        cmd.Parameters.AddWithValue("@TD_Productivity", _assessment.TDProductivity);
                        cmd.Parameters.AddWithValue("@TD_Product_Knowledge", _assessment.TDProductKnowledge);
                        cmd.Parameters.AddWithValue("@TD_Comments", _assessment.TDComments);
                        cmd.Parameters.AddWithValue("@CSR_Proffesionalism_Teamwork", _assessment.CSRProffesionalismTeamwork);
                        cmd.Parameters.AddWithValue("@CSR_Verbal_Skills", _assessment.CSRVerbalSkills);
                        cmd.Parameters.AddWithValue("@CSR_Written_Skills", _assessment.CSRWrittenSkills);
                        cmd.Parameters.AddWithValue("@CSR_Listening_Skills", _assessment.CSRListeningSkills);
                        cmd.Parameters.AddWithValue("@CSR_Comments", _assessment.CSRComments);
                        cmd.Parameters.AddWithValue("@AD_Attendence", _assessment.ADAttendence);
                        cmd.Parameters.AddWithValue("@AD_Ethical_Behavior", _assessment.ADEthicalBehavior);
                        cmd.Parameters.AddWithValue("@AD_Meet_Deadlines", _assessment.ADMeetDeadlines);
                        cmd.Parameters.AddWithValue("@AD_Organize_Detailed_Work", _assessment.ADOrganizeDetailedWork);
                        cmd.Parameters.AddWithValue("@AD_Comments", _assessment.ADComments);
                        cmd.Parameters.AddWithValue("@TM_Resource_Use", _assessment.TMResourceUse);
                        cmd.Parameters.AddWithValue("@TM_Feedback", _assessment.TMFeedback);
                        cmd.Parameters.AddWithValue("@TM_Technical_Monitoring", _assessment.TMTechnicalMonitoring);
                        cmd.Parameters.AddWithValue("@TM_Asking_Questions", _assessment.TMAskingQuestions);
                        cmd.Parameters.AddWithValue("@TM_Comments", _assessment.TMComments);
                        cmd.Parameters.AddWithValue("@MI_Attitude_Work", _assessment.MIAttitudeWork);
                        cmd.Parameters.AddWithValue("@MI_Grooming_Appearance", _assessment.MIGroomingAppearance);
                        cmd.Parameters.AddWithValue("@MI_Personal_Growth", _assessment.MIPersonalGrowth);
                        cmd.Parameters.AddWithValue("@MI_Potential_Advancement", _assessment.MIPotentialAdvancement);
                        cmd.Parameters.AddWithValue("@MI_Comments", _assessment.MIComments);
                        cmd.Parameters.AddWithValue("@Created", _assessment.Created);
                        cmd.Parameters.AddWithValue("@Created_By", _assessment.CreatedBy);
                        cmd.Parameters.AddWithValue("@Modified", _assessment.Modified);
                        cmd.Parameters.AddWithValue("@Modified_By", _assessment.ModifiedBy);

                        Connection.Open();
                        cmd.ExecuteNonQuery();
                        Connection.Close();
                        Connection.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public List<AssessmentDM> ReadAddress()
        {
            List<AssessmentDM> assessmentList = new List<AssessmentDM>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    Connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_ASSESSMENT", Connection))
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _assessment = new AssessmentDM();
                                    _assessment.TDProblemSolving = (int)reader["TD_Problem_Solving"];
                                    _assessment.TDQualityOfWork = (int)reader["TD_Quality_Of_Work"];
                                    _assessment.TDProductivity = (int)reader["TD_Productivity"];
                                    _assessment.TDProductKnowledge = (int)reader["TD_Product_Knowledge"];
                                    _assessment.TDComments = (string)reader["TD_Comments"];
                                    _assessment.CSRProffesionalismTeamwork = (int)reader["CSR_Proffesionalism_Teamwork"];
                                    _assessment.CSRVerbalSkills = (int)reader["CSR_Verbal_Skills"];
                                    _assessment.CSRWrittenSkills = (int)reader["CSR_Written_Skills"];
                                    _assessment.CSRListeningSkills = (int)reader["CSR_Listening_Skills"];
                                    _assessment.CSRComments = (string)reader["CSR_Comments"];
                                    _assessment.ADAttendence = (int)reader["AD_Attendence"];
                                    _assessment.ADEthicalBehavior = (int)reader["AD_Ethical_Behavior"];
                                    _assessment.ADMeetDeadlines = (int)reader["AD_Meet_Deadlines"];
                                    _assessment.ADOrganizeDetailedWork = (int)reader["AD_Organize_Detailed_Work"];
                                    _assessment.ADComments = (string)reader["AD_Comments"];
                                    _assessment.TMResourceUse = (int)reader["TM_ResourceUse"];
                                    _assessment.TMFeedback = (int)reader["TM_Feedback"];
                                    _assessment.TMTechnicalMonitoring = (int)reader["TM_Technical_Monitoring"];
                                    _assessment.TMAskingQuestions = (int)reader["TM_Asking_Questions"];
                                    _assessment.TMComments = (string)reader["TM_Comments"];
                                    _assessment.MIAttitudeWork = (int)reader["MI_Attitude_Work"];
                                    _assessment.MIGroomingAppearance = (int)reader["MI_Grooming_Appearance"];
                                    _assessment.MIPersonalGrowth = (int)reader["MI_Personal_Growth"];
                                    _assessment.MIPotentialAdvancement = (int)reader["MI_Potential_Advancement"];
                                    _assessment.MIComments = (string)reader["MI_Comments"];
                                    _assessment.Created = (DateTime)reader["Created"];
                                    _assessment.CreatedBy = (string)reader["Created_By"];
                                    _assessment.Modified = (DateTime)reader["Modified"];
                                    _assessment.ModifiedBy = (string)reader["Modified_By"];

                                    assessmentList.Add(_assessment);
                                }
                            }
                        }
                    }
                }
                return (assessmentList);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void UpdateAssessment(AssessmentDM _assessment)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_ASSESSMENT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Assessment_ID", _assessment.AssessmentId);
                        cmd.Parameters.AddWithValue("@TD_Problem_Solving", _assessment.TDProblemSolving);
                        cmd.Parameters.AddWithValue("@TD_Quality_of_Work", _assessment.TDQualityOfWork);
                        cmd.Parameters.AddWithValue("@TD_Productivity", _assessment.TDProductivity);
                        cmd.Parameters.AddWithValue("@TD_Product_Knowledge", _assessment.TDProductKnowledge);
                        cmd.Parameters.AddWithValue("@TD_Comments", _assessment.TDComments);
                        cmd.Parameters.AddWithValue("@CSR_Proffesionalism_Teamwork", _assessment.CSRProffesionalismTeamwork);
                        cmd.Parameters.AddWithValue("@CSR_Verbal_Skills", _assessment.CSRVerbalSkills);
                        cmd.Parameters.AddWithValue("@CSR_Written_Skills", _assessment.CSRWrittenSkills);
                        cmd.Parameters.AddWithValue("@CSR_Listening_Skills", _assessment.CSRListeningSkills);
                        cmd.Parameters.AddWithValue("@CSR_Comments", _assessment.CSRComments);
                        cmd.Parameters.AddWithValue("@AD_Attendence", _assessment.ADAttendence);
                        cmd.Parameters.AddWithValue("@AD_Ethical_Behavior", _assessment.ADEthicalBehavior);
                        cmd.Parameters.AddWithValue("@AD_Meet_Deadlines", _assessment.ADMeetDeadlines);
                        cmd.Parameters.AddWithValue("@AD_Organize_Detailed_Work", _assessment.ADOrganizeDetailedWork);
                        cmd.Parameters.AddWithValue("@AD_Comments", _assessment.ADComments);
                        cmd.Parameters.AddWithValue("@TM_Resource_Use", _assessment.TMResourceUse);
                        cmd.Parameters.AddWithValue("@TM_Feedback", _assessment.TMFeedback);
                        cmd.Parameters.AddWithValue("@TM_Technical_Monitoring", _assessment.TMTechnicalMonitoring);
                        cmd.Parameters.AddWithValue("@TM_Asking_Questions", _assessment.TMAskingQuestions);
                        cmd.Parameters.AddWithValue("@TM_Comments", _assessment.TMComments);
                        cmd.Parameters.AddWithValue("@MI_Attitude_Work", _assessment.MIAttitudeWork);
                        cmd.Parameters.AddWithValue("@MI_Grooming_Appearance", _assessment.MIGroomingAppearance);
                        cmd.Parameters.AddWithValue("@MI_Personal_Growth", _assessment.MIPersonalGrowth);
                        cmd.Parameters.AddWithValue("@MI_Potential_Advancement", _assessment.MIPotentialAdvancement);
                        cmd.Parameters.AddWithValue("@MI_Comments", _assessment.MIComments);
                        cmd.Parameters.AddWithValue("@Created", _assessment.Created);
                        cmd.Parameters.AddWithValue("@Created_By", _assessment.CreatedBy);
                        cmd.Parameters.AddWithValue("@Modified", _assessment.Modified);
                        cmd.Parameters.AddWithValue("@Modified_By", _assessment.ModifiedBy);
                        Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public void DeleteAssessment(AssessmentDM _assessment)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_ASSESSMENT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Assessment_ID", _assessment.AssessmentId);
                        Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        #endregion
    }
}