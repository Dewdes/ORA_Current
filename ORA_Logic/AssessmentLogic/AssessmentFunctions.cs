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
        public static AssessmentBM CalculateTotalAssessmentScore(AssessmentBM assessment)
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

        /// <summary>
        /// This calculates the mean for each individual assessment and puts those scores in a list
        /// </summary>
        /// <param name="assessment"></param>
        /// <returns></returns>
        public static List<double> CalculateMeanForAllAssessments(List<AssessmentBM> assessment)
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

        /// <summary>
        /// This method calculates means for a given individual assessment
        /// </summary>
        /// <param name="assessment"></param>
        /// <returns></returns>
        public static double CalculateMeanForIndividualAssessment(AssessmentBM assessment)
        {
            assessment.AssessmentScore =
           (
               (
                   assessment.ADAttendence + assessment.ADEthicalBehavior + assessment.ADMeetDeadlines + assessment.ADOrganizeDetailedWork +
                   assessment.TDProblemSolving + assessment.TDProductivity + assessment.TDProductKnowledge + assessment.TDQualityOfWork +
                   assessment.TMAskingQuestions + assessment.TMFeedback + assessment.TMResourceUse + assessment.TMTechnicalMonitoring +
                   assessment.MIAttitudeWork + assessment.MIGroomingAppearance + assessment.MIPersonalGrowth + assessment.MIPotentialAdvancement +
                   assessment.CSRListeningSkills + assessment.CSRProfesionalismTeamwork + assessment.CSRVerbalSkills + assessment.CSRWrittenSkills
               ) / 20
           );
            double assessmentAverage = Convert.ToDouble(assessment.AssessmentScore);
            return assessmentAverage;
        }

        //Something isnt right here, got lost in the sauce going to refactor it tomorrow
        public static void CalculateStdDevForIndividuals(List<AssessmentBM> assessmentList)
        {
            AssessmentBM assessment = new AssessmentBM();
            List<double> avgList = CalculateMeanForAllAssessments(assessmentList);
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

        /// <summary>
        /// I am calculating the standard deviation of all of the individual assessment averages
        /// Not to be confused with getting the standard deviation for a individual
        /// </summary>
        /// <param name="assessmentList"></param>
        /// <returns></returns>
        public static double CalculateStdDeviationForAllAssessments(List<AssessmentBM> assessmentList)
        {
            AssessmentBM assessment = new AssessmentBM();
            List<double> avgList = CalculateMeanForAllAssessments(assessmentList); //List of each average score for each individual assessment
            double sum = 0; double count = avgList.Count;
            double x = 0; double meanOfSum; double standardDeviation;

            foreach (double avg in avgList) //Calculating the average of all the averages we got above here
            {
                sum += avg;
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

        /// <summary>
        /// Used to gather AssessmentMeans for all developers at selected Location
        /// </summary>
        public static void CalculateDeveloperAssessmentMean()
        {
            return;
        }

        /// <summary>
        /// used to gather Assessment means for all QA members at selected location
        /// </summary>
        public static void CalculateQAAssessmentMean()
        {
            return;
        }

        public static void CalculateMedianAggregateForAllAssessments(List<AssessmentBM> assessmentList)
        {

            //var sorted = from n in assessmentList
            //             orderby n ascending
            //             select n;
            //decimal middle = (sorted.Count() + 1) / 2;

            //if (assessmentList == null || assessmentList.Count == 0)
            //    throw new System.Exception("Median of empty array not defined.");

            //make sure the list is sorted, but use a new array
            //List<AssessmentBM> sortedPNumbers = new List<AssessmentBM>();
            //sortedPNumbers = assessmentList;

            //get the median
            //int size = sortedPNumbers.Count;
            //int mid = size / 2;
            //double median = (size % 2 != 0) ? (double)sortedPNumbers[mid] : ((double)sortedPNumbers[mid] + (double)sortedPNumbers[mid - 1]) / 2;
            //return median;

            //if (sorted.Count() % 2 != 0)
            //{
            //    double median = Convert.ToDouble(sorted.ElementAt((int)middle - 1));
            //    return median;
            //}
            //else
            //{
            //    return assessmentList.Average(new List<int>() { sorted.ElementAt((AssessmentBM)middle - 1), sorted.ElementAt((AssessmentBM)middle) });
            //}

            //return 0;
        }
    }
}
