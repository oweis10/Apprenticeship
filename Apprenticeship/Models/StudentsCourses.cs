using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    [Table("StudentsCourses")]
    public class StudentsCourses
    {
        public Course Course { get; set; }
        public long CourseId { get; set; }
        public Student Student { get; set; }
        public string StudentId { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public bool Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
