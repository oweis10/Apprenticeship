using Apprenticeship.Data;
using Apprenticeship.Models;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private ApplicationDbContext _dataContext;

        public CourseRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<Course> GetCoursesList()
        {
            IList<Course> CourseList = new List<Course>();
            var courses = (from Courses in _dataContext.Courses
                         select Courses)
                         .Where(x => x.Deleted == false).Distinct().ToList();

            return courses;
        }
        public ICollection<CoursesSkills> GetCourses()
        {
            IList<CoursesSkills> CourseList = new List<CoursesSkills>();
            var query = (from CoursesSkills in _dataContext.CoursesSkills
                         select CoursesSkills)
                         .Where(x => x.Deleted == false).Include(x => x.Course)
                         .Include(x => x.Skill);
            

            var courses = query.ToList().DistinctBy(x => x.CourseId);
            foreach (var course in courses)
            {
                CourseList.Add(new CoursesSkills()
                {
                    
                    CourseId = course.CourseId, 
                    Course = course.Course,
                    Skill = course.Skill,
                    SkillId = course.SkillId
                });
            }
            return CourseList;
        }

        public CoursesSkills GetCourse(long courseId, long skillId)
        {
            var query = (from c in _dataContext.CoursesSkills
                         select c)
                         .Where(x => x.Deleted == false && x.CourseId == courseId && x.SkillId == skillId).Include(x => x.Course).Include(x => x.Skill).FirstOrDefault();



            return query;
        }

        public void InsertCourse(string courseName, long skillId)
        {
            Course course = new Course()
            {
                CourseName = courseName,
                Deleted = false
            };
            _dataContext.Courses.Add(course);
            _dataContext.SaveChanges();

            var skill = (from s in _dataContext.Skills
                        where s.Id == skillId && s.Deleted == false
                        select s).SingleOrDefault();
            CoursesSkills coursesSkill = new CoursesSkills()
            {
                CourseId = course.CourseId,
                SkillId = skill.Id,
                Deleted = false
            };
            _dataContext.CoursesSkills.Add(coursesSkill);
            _dataContext.SaveChanges();
        }
        public void DeleteCourse(long courseId)
        {
            List<CoursesSkills> Courses = _dataContext.CoursesSkills.Where(e => e.CourseId == courseId).ToList();

            foreach (var cs in Courses)
            {
                cs.Deleted = true;
                _dataContext.SaveChanges();
            }
            //Course.DeletedBy = GetCurrentUserId().ToString();
            
        }

        public ICollection<Skill> GetCourseSkills(long courseId)
        {
            IList<Skill> skillList = new List<Skill>();
            var skills = (from cs in _dataContext.CoursesSkills
                          where cs.CourseId == courseId && cs.Deleted == false
                          select cs).Include(x => x.Skill).Select(x => x.Skill).ToList().Distinct();

            foreach (var skill in skills)
            {
                skillList.Add(new Skill()
                {
                    Id = skill.Id,
                    Name = skill.Name
                });
            }

            return skillList;
        }

        public void UpdateCourse(string courseName, long courseId, List<long> skillIds)
        {
            var oldSkills = (from cs in _dataContext.CoursesSkills
                            select cs)
                            .Include(x => x.Skill)
                            .Where(x => x.Deleted == false && x.CourseId == courseId)
                            .Select(x => x.SkillId).ToList();

            foreach(var os in oldSkills)
            {
                if(skillIds.Contains(os))
                {
                    skillIds.Remove(os);
                }
                else
                {
                    var courseSkill = _dataContext.CoursesSkills.Where(e => e.CourseId == courseId && e.SkillId == os).SingleOrDefault();
                    _dataContext.CoursesSkills.Remove(courseSkill);
                    _dataContext.SaveChanges();
                }
            }

            foreach(var skillId in skillIds)
            {
                var course = (from c in _dataContext.Courses
                              where c.CourseId == courseId
                              select c).SingleOrDefault();
                course.CourseName = courseName;
                course.Modified = true;
                _dataContext.SaveChanges();
                CoursesSkills courseSkill = new CoursesSkills()
                {
                    CourseId = courseId,
                    SkillId = skillId,
                    Modified = true
                };

                _dataContext.CoursesSkills.Add(courseSkill);
                _dataContext.SaveChanges();
            }
        }
    }
}
