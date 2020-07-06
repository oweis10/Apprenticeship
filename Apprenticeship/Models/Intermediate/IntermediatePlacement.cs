using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models.Intermediate
{
    public class IntermediatePlacement : IValidatableObject
    {
        public long? Id { get; set; }
        [Required]
        [DisplayName("Student")]
        public string StudentId { get; set; }
        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        [Required]
        [DisplayName("Work Mentor")]
        public string WorkMentorId { get; set; }
        [DisplayName("Work Mentor Name")]
        public string WorkMentorName { get; set; }
        [Required]
        [DisplayName("School Mentor")]
        public string SchoolMentorId { get; set; }
        [DisplayName("School Mentor Name")]
        public string SchoolMentorName { get; set; }
        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        public List<long> Noses { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [DisplayName("Student's Portfolio")]
        public List<IFormFile> portfolio { get; set; }
        public IntermediateFile portFolioFile { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Noses.Count != 5)
            {
                yield return new ValidationResult("You must choose 5 Noses!", new List<string>() { "Noses"});
            }
        }
    }
}
