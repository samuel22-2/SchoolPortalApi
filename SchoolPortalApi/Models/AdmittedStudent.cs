﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPortalApi.Models
{
    public class AdmittedStudent
    {
       
       [Key] public string MatricNo { get; set; } = string.Empty;

       
        public string ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public Registration Registration { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string StateOfOrigin { get; set; }
        public string Denomination { get; set; }
        public string GuardianName { get; set; }
        public string GuardianPhoneNumber { get; set; }
        public string GuardianEmail { get; set; }
        public string GuardianAddress { get; set; }
        public double Score { get; set; }
        
        

    }
}
