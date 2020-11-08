using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models.Intermediate
{
    public class IntermediateCourse
    {
        public string CourseName { get; set; }
        public List<long> SkillIds { get; set; }
    }
}
