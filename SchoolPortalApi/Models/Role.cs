using System.ComponentModel.DataAnnotations;

namespace SchoolPortalApi.Models
{
    public class Role
    {
        [Key] public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
