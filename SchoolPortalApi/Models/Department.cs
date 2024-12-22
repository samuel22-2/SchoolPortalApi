using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPortalApi.Models
{
    public class Department
    {
        [Key]public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public School School { get; set; }
    }
}
