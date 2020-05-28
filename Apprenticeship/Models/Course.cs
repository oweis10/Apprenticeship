using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    [Table("Courses")]
    public class Course
    {
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<CoursesSkills> CourseSkills { get; set; }
        public ICollection<StudentsCourses> StudentsCourses { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public bool Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
