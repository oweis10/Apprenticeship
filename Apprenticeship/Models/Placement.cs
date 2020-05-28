using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    [Table("Placements")]
    public class Placement
    {
        public long Id { get; set; }
        public Student Student { get; set; }
        public string StudentId { get; set; }
        public WorkMentor WorkMentor { get; set; }
        public string WorkMentorId { get; set; }
        public SchoolMentor SchoolMentor { get; set; }
        public string SchoolMentorId { get; set; }
        public string CompanyName { get; set; }
        [DisplayName("Nos")]
        public ICollection<PlacementsNoses> PlacementsNoses { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public bool Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
