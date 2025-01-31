using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolPortalApi.Models
{
    public class Examss
    {
        [Key] public int ExamId { get; set; }
        public string ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public Registration Registration { get; set; }
        public string? Subject { get; set; }
        public string? Grade { get; set; }
    }
}
