using System.ComponentModel.DataAnnotations;

namespace SchoolPortalApi.Models
{
    public class School
    {
       [Key]public int SchoolId { get; set; }
        public string? SchoolName { get;set; }

    }
}
