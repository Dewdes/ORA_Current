using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORA_Logic.Models;

namespace ORA_Logic
{
    public class AssessmentLogic
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
        public static void CalculateDeveloperAssessmentScores()
        {
            return;
        }

        public static void CalculateQAAssessmentScores()
        {
            return;
        }
    }
}
