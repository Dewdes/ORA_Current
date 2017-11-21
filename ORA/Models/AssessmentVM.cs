using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ORA_Logic;

namespace ORA.Models
{
    public class AssessmentVM
    {
        public int AssessmentId { get; set; }

        [DisplayName("Problem Solving")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int TDProblemSolving { get; set; }

        [DisplayName("Quality of Work")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int TDQualityOfWork { get; set; }

        [DisplayName("Productivity")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int TDProductivity { get; set; }

        [DisplayName("Product Knowledge")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int TDProductKnowledge { get; set; }

        [DisplayName("Comments")]
        public string TDComments { get; set; }

        [DisplayName("Profesionalism Teamwork")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int CSRProfesionalismTeamwork { get; set; }

        [DisplayName("Verbal Skills")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int CSRVerbalSkills { get; set; }

        [DisplayName("Written Skills")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int CSRWrittenSkills { get; set; }

        [DisplayName("Listening Skills")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int CSRListeningSkills { get; set; }

        [DisplayName("Comments")]
        public string CSRComments { get; set; }

        [DisplayName("Attendence")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int ADAttendence { get; set; }

        [DisplayName("Ethical Behavior")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int ADEthicalBehavior { get; set; }

        [DisplayName("Meet Deadlines")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int ADMeetDeadlines { get; set; }

        [DisplayName("Organize Detailed Work")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int ADOrganizeDetailedWork { get; set; }

        [DisplayName("Comments")]
        public string ADComments { get; set; }

        [DisplayName("Resource Use")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int TMResourceUse { get; set; }

        [DisplayName("Feedback")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int TMFeedback { get; set; }

        [DisplayName("Technical Monitoring")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int TMTechnicalMonitoring { get; set; }

        [DisplayName("Asking Questions")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int TMAskingQuestions { get; set; }

        [DisplayName("Comments")]
        public string TMComments { get; set; }

        [DisplayName("Attitude Work")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int MIAttitudeWork { get; set; }

        [DisplayName("Grooming Appearance")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int MIGroomingAppearance { get; set; }

        [DisplayName("Personal Growth")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int MIPersonalGrowth { get; set; }

        [DisplayName("Potential Advanceement")]
        [Required(ErrorMessage = "Please choose a number.")]
        public int MIPotentialAdvancement { get; set; }

        [DisplayName("Comments")]
        public string MIComments { get; set; }

        public int AssessmentScore { get; set; }

        public int AssignmentID { get; set; }

        public List<AssignmentVM> Assignments { get; set; }

        [DisplayName("Assessed For")]
        [DisplayFormat(DataFormatString = "{0:MMMM-yyyy}")]
        [Required(ErrorMessage = "This is required.")]
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

        public WorkHistoryVM WorkHistory { get; set; }

        public List<WorkHistoryVM> WorkHistoryList { get; set; }

        public double Mean;

        public double StandardDeviation;

        public List<double> MeanList;

        public List<double> StandardDeviationList;
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