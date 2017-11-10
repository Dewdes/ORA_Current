using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ORA.Models
{
    public class AssessmentVM
    {
        public int AssessmentId { get; set; }

        [DisplayName("Problem Solving")]
        public int TDProblemSolving { get; set; }

        [DisplayName("Quality of Work")]
        public int TDQualityOfWork { get; set; }

        [DisplayName("Productivity")]
        public int TDProductivity { get; set; }

        [DisplayName("Product Knowledge")]
        public int TDProductKnowledge { get; set; }

        [DisplayName("Comments")]
        public string TDComments { get; set; }

        [DisplayName("Profesionalism Teamwork")]
        public int CSRProfesionalismTeamwork { get; set; }

        [DisplayName("Verbal Skills")]
        public int CSRVerbalSkills { get; set; }

        [DisplayName("Written Skills")]
        public int CSRWrittenSkills { get; set; }

        [DisplayName("Listening Skills")]
        public int CSRListeningSkills { get; set; }

        [DisplayName("Comments")]
        public string CSRComments { get; set; }

        [DisplayName("Attendence")]
        public int ADAttendence { get; set; }

        [DisplayName("Ethical Behavior")]
        public int ADEthicalBehavior { get; set; }

        [DisplayName("Meet Deadlines")]
        public int ADMeetDeadlines { get; set; }

        [DisplayName("Organize Detailed Work")]
        public int ADOrganizeDetailedWork { get; set; }

        [DisplayName("Comments")]
        public string ADComments { get; set; }

        [DisplayName("Resource Use")]
        public int TMResourceUse { get; set; }

        [DisplayName("Feedback")]
        public int TMFeedback { get; set; }

        [DisplayName("Technical Monitoring")]
        public int TMTechnicalMonitoring { get; set; }

        [DisplayName("Asking Questions")]
        public int TMAskingQuestions { get; set; }

        [DisplayName("Comments")]
        public string TMComments { get; set; }

        [DisplayName("Attitude Work")]
        public int MIAttitudeWork { get; set; }

        [DisplayName("Grooming Appearance")]
        public int MIGroomingAppearance { get; set; }

        [DisplayName("Personal Growth")]
        public int MIPersonalGrowth { get; set; }

        [DisplayName("Potential Advanceement")]
        public int MIPotentialAdvancement { get; set; }

        [DisplayName("Comments")]
        public string MIComments { get; set; }

        public int AssignmentID { get; set; }

        public List<AssignmentVM> Assignments { get; set; }

        [DisplayName("Assessed For")]
        public DateTime DateCreatedFor { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }

        [DisplayName("Employees")]
        public long EmployeeID { get; set; }

        public EmployeeVM Employee { get; set; }

        public List<EmployeeVM> EmployeeList { get; set; }

        public List<int> Points
        {
            get
            {
                List<int> numbers = Enumerable.Range(1, 5).ToList();
                return numbers;
            }
        }

        public List<DescriptionVM> Descriptions { get; set; }

    }
    public class DescriptionVM
    {
        public DescriptionVM() { }

        public DescriptionVM(string assessName, int num, string name, string desc)
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