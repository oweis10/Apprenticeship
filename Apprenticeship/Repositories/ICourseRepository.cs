using Apprenticeship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface ICourseRepository
    {
        CoursesSkills GetCourse(long courseId, long skillId);
        ICollection<CoursesSkills> GetCourses();
        void InsertCourse(string courseName, List<long> skillIds);
        void DeleteCourse(long CourseId);
        void UpdateCourse(string courseName, long courseId, List<long> skillIds);
        ICollection<Skill> GetCourseSkills(long courseId);
        ICollection<Course> GetCoursesList();
    }
}
