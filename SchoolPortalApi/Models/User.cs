using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPortalApi.Models
{
    public class User
    { 
        [Key]public int Id { get; set; }
        public string MatricNo { get; set; }
        [ForeignKey("MatricNo")]
        public AdmittedStudent AdmittedStudent {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }


        

         
    }
}
