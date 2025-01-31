namespace SchoolPortalApi.Models
{
    public class ModelDto
    {
        public string? FirstName { get; set; }
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
        public string? SecondarySchool { get; set; }
        public string? SchoolAddress { get; set; }
        public int JambScore { get; set; }
        public string? CourseOfStudy { get; set; }
        public List<ExamDTO> ExamList { get; set; }
    }

    public class ExamDTO
    {
        //public int Id { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
    }

    public class DepartmentDto
    {
        public string? DepartmentName { get; set; }
        public int SchoolId { get; set; }
    }

    public class SchoolDto
    {
        public string? SchoolName { get; set; }
    }
    public class AdminDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
     
    }
    public class RoleDto
    {
        public string? RoleName { get; set; }
    }

    
}
