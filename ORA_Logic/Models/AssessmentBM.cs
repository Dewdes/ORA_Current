using System;
using System.Collections.Generic;

namespace ORA_Logic.Models
{
    public class AssessmentBM
    {
        public long AssessmentId { get; set; }

        public int TDProblemSolving { get; set; }

        public int TDQualityOfWork { get; set; }

        public int TDProductivity { get; set; }

        public int TDProductKnowledge { get; set; }

        public string TDComments { get; set; }

        public int CSRProfesionalismTeamwork { get; set; }

        public int CSRVerbalSkills { get; set; }

        public int CSRWrittenSkills { get; set; }

        public int CSRListeningSkills { get; set; }

        public string CSRComments { get; set; }

        public int ADAttendence { get; set; }

        public int ADEthicalBehavior { get; set; }

        public int ADMeetDeadlines { get; set; }

        public int ADOrganizeDetailedWork { get; set; }

        public string ADComments { get; set; }

        public int TMResourceUse { get; set; }

        public int TMFeedback { get; set; }

        public int TMTechnicalMonitoring { get; set; }

        public int TMAskingQuestions { get; set; }

        public string TMComments { get; set; }

        public int MIAttitudeWork { get; set; }

        public int MIGroomingAppearance { get; set; }

        public int MIPersonalGrowth { get; set; }

        public int MIPotentialAdvancement { get; set; }

        public string MIComments { get; set; }

        public int AssessmentScore { get; set; }

        public long EmployeeID { get; set; }

        public DateTime DateCreatedFor { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }

        public List<DescriptionBM> Descriptions { get; set; }

    }
    public class DescriptionBM
    {
        public DescriptionBM() { }

        public DescriptionBM(string assessName, int num, string name, string desc)
        {
            AssessName = assessName;
            Number = num;
            Name = name;
            Desc = desc;
        }

        public string AssessName { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}

