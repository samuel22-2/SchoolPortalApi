using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPortalApi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        [ForeignKey("SchoolId")]public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
