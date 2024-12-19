using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPortalApi.Models
{
    public class Admin
    {

        [Key] public int AdminId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        [ForeignKey("RoleId")]public int RoleId { get; set; }
        public Role Role { get; set; }
        public string? PasswordHash { get; set; }
       

    }
}
