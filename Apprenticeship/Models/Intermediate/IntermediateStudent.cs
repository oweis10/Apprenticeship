using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models.Intermediate
{
    public class IntermediateStudent : IdentityUser
    {
        [Required]
        [DisplayName("Student Id")]
        public long StudentId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Second Name")]
        public string SecondName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [DisplayName("Major")]
        public long MajorId { get; set; }
        [Required]
        [DisplayName("Degree")]
        public long DegreeId { get; set; }
        [DisplayName("Major Name")]
        public string MajorName { get; set; }
        [DisplayName("Degree Name")]
        public string DegreeName { get; set; }
        [Required]
        [DisplayName("Courses")]
        public List<long> StudentsCoursesIds { get; set; }
        [DisplayName("Emergency Contact Name")]
        public string EmergencyContactFullName { get; set; }
        [DisplayName("Emergency Contact Phone")]
        public string EmergencyContactPhoneNumber { get; set; }
    }
}
