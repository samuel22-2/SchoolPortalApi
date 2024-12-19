using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPortalApi.Models
{
    public class Registration
    {
        public static readonly GenerateID idGenerator = new GenerateID();

        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Disable automatic identity generation

        [Key] public string ApplicantId { get; set; } 
        public string? FirstName  { get; set; }
        public string? MiddleName { get; set; }    
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime DOB { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Nationality { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? Denomination { get; set; }
        public string? GuardianName { get; set; }
        public string? GuardianPhoneNumber { get; set; }
        public string? GuardianEmail { get; set; }
        public string? GuardianAddress { get; set; }
        public int JambScore { get; set; }
        public decimal TotalScore { get; set; } 
        public string? CourseOfStudy { get; set; }
        public string? PasswordHash { get; set; }
        public int TotalApplicants { get; set; }

        public Registration()
        {
            ApplicantId = idGenerator.GenerateApplicantID();
        }
    }

    public class Exam
    {
        public int ExamId { get; set; }
        [ForeignKey("ApplicantId")] public string? ApplicantId { get; set; }
        public Registration Registration { get; set; }
        public string? Subject { get; set; }
        public string? Grade { get; set; }
    }

}
 