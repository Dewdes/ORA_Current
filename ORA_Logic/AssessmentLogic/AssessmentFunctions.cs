using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ORA_Logic.Models;

namespace ORA_Logic
{
    public class AssessmentFunctions
    {
        public static AssessmentBM CalculateAssessmentScore(AssessmentBM assessment)
        {
            assessment.AssessmentScore = (
            assessment.ADAttendence + assessment.ADEthicalBehavior + assessment.ADMeetDeadlines + assessment.ADOrganizeDetailedWork +
            assessment.TDProblemSolving + assessment.TDProductivity + assessment.TDProductKnowledge + assessment.TDQualityOfWork +
            assessment.TMAskingQuestions + assessment.TMFeedback + assessment.TMResourceUse + assessment.TMTechnicalMonitoring +
            assessment.MIAttitudeWork + assessment.MIGroomingAppearance + assessment.MIPersonalGrowth + assessment.MIPotentialAdvancement +
            assessment.CSRListeningSkills + assessment.CSRProfesionalismTeamwork + assessment.CSRVerbalSkills + assessment.CSRWrittenSkills
            );
            return assessment;
        }

        public static List<double> CalculateMeanForEachAssessment(List<AssessmentBM> assessment)
        {
            List<double> assessmentAvg = new List<double>();
            foreach (var item in assessment)
            {
                item.AssessmentScore =
                (
                    (
                        item.ADAttendence + item.ADEthicalBehavior + item.ADMeetDeadlines + item.ADOrganizeDetailedWork +
                        item.TDProblemSolving + item.TDProductivity + item.TDProductKnowledge + item.TDQualityOfWork +
                        item.TMAskingQuestions + item.TMFeedback + item.TMResourceUse + item.TMTechnicalMonitoring +
                        item.MIAttitudeWork + item.MIGroomingAppearance + item.MIPersonalGrowth + item.MIPotentialAdvancement +
                        item.CSRListeningSkills + item.CSRProfesionalismTeamwork + item.CSRVerbalSkills + item.CSRWrittenSkills
                    ) / 20
                );
                assessmentAvg.Add(item.AssessmentScore);
            }
            return assessmentAvg;
        }

        //Something isnt right here, got lost in the sauce going to refactor it tomorrow
        public static void CalculateStdDevForIndividuals(List<AssessmentBM> assessmentList)
        {
            AssessmentBM assessment = new AssessmentBM();
            List<double> avgList = CalculateMeanForEachAssessment(assessmentList);
            double meanOfSum;
            List<double> standardDeviation = new List<double>();

            foreach (double num in avgList)
            {
                double sum = Math.Pow((assessment.ADAttendence - num), 2) + Math.Pow((assessment.ADEthicalBehavior - num), 2) + 
                             Math.Pow((assessment.ADMeetDeadlines - num), 2) + Math.Pow((assessment.ADOrganizeDetailedWork - num), 2) + 
                             Math.Pow((assessment.TDProblemSolving - num), 2) + Math.Pow((assessment.TDProductivity - num), 2) +
                             Math.Pow((assessment.TDProductKnowledge - num), 2) + Math.Pow((assessment.TDQualityOfWork - num), 2) + 
                             Math.Pow((assessment.TMAskingQuestions - num), 2) + Math.Pow((assessment.TMFeedback - num), 2) + 
                             Math.Pow((assessment.TMResourceUse - num), 2) + Math.Pow((assessment.TMTechnicalMonitoring - num), 2) +
                             Math.Pow((assessment.MIAttitudeWork - num), 2) + Math.Pow((assessment.MIGroomingAppearance - num), 2) + 
                             Math.Pow((assessment.MIPersonalGrowth - num), 2) + Math.Pow((assessment.MIPotentialAdvancement - num), 2) + 
                             Math.Pow((assessment.CSRListeningSkills - num), 2) + Math.Pow((assessment.CSRProfesionalismTeamwork - num), 2) +
                             Math.Pow((assessment.CSRVerbalSkills - num), 2) + Math.Pow((assessment.CSRWrittenSkills - num), 2);

                meanOfSum = sum / 20;
                standardDeviation.Add(Math.Sqrt(meanOfSum));
            }
        }

        public static double CalculateStdDeviationForAllAssessments(List<AssessmentBM> assessmentList)
        {
            AssessmentBM assessment = new AssessmentBM();
            List<double> avgList = CalculateMeanForEachAssessment(assessmentList); //List of each average score for each individual assessment
            double sum = 0; double count = avgList.Count;
            double x = 0; double meanOfSum; double standardDeviation;
            
            foreach (double avg in avgList) //Calculating the average of all the averages we got above here
            {
                sum += avg;
                count++;
            }

            double averageOfAverages = sum / count;

            foreach (double avg in avgList)
            {
                x = Math.Pow(avg - averageOfAverages, 2);
            }
            meanOfSum = x / count;
            standardDeviation = (Math.Sqrt(meanOfSum));

            return standardDeviation; 
        }

        public static void CalculateDeveloperAssessmentMean()
        {
            return;
        }

        public static void CalculateQAAssessmentMean()
        {
            return;
        }
    }
}
