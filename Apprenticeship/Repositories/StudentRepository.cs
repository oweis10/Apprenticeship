using Apprenticeship.Data;
using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationDbContext _dataContext;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public StudentRepository(ApplicationDbContext dataContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task InsertStudentAsync(IntermediateStudent intermediateStudent, string studentId)
        {
            var degree = await (from d in _dataContext.Degrees
                          select d).Where(x => x.Deleted == false && x.Id == intermediateStudent.DegreeId).SingleOrDefaultAsync();

            var major = await (from m in _dataContext.Majors
                          select m).Where(x => x.Deleted == false && x.Id == intermediateStudent.MajorId).SingleOrDefaultAsync();

            var student = await (from s in _dataContext.Students
                           where s.Id == studentId
                           select s).SingleOrDefaultAsync();

            student.StudentId = intermediateStudent.StudentId;
            student.FirstName = intermediateStudent.FirstName;
            student.SecondName = intermediateStudent.SecondName;
            student.LastName = intermediateStudent.LastName;
            student.Address = intermediateStudent.Address;
            student.Deleted = false;
            student.EmergencyContactFullName = intermediateStudent.EmergencyContactFullName;
            student.EmergencyContactPhoneNumber = intermediateStudent.EmergencyContactPhoneNumber;
            student.PhoneNumber = intermediateStudent.PhoneNumber;
            student.Degree = degree;
            student.Major = major;
            await _dataContext.SaveChangesAsync();


            IdentityUserRole<string> studentRole = new IdentityUserRole<string>()
            {
                UserId = studentId,
                RoleId = "2"
            };

            await _dataContext.UserRoles.AddAsync(studentRole);
            await _dataContext.SaveChangesAsync();

            foreach (var courseId in intermediateStudent.StudentsCoursesIds)
            {
                StudentsCourses studentCourse = new StudentsCourses()
                {
                    StudentId = student.Id,
                    CourseId = courseId,
                    Deleted = false
                };
                await _dataContext.StudentsCourses.AddAsync(studentCourse);
                await _dataContext.SaveChangesAsync();
            }
        }

        public ICollection<Student> GetStudents()
        {
            IList<Student> studentList = new List<Student>();
            var query = (from student in _dataContext.Students
                         join userRole in _dataContext.UserRoles
                         on student.Id equals userRole.UserId
                         join role in _dataContext.Roles
                         on userRole.RoleId equals role.Id
                         where role.Name == Roles.Student.ToString()
                         select student)
                         .Where(x => x.Deleted == false).ToList();

            var students = query.ToList();
            return query;
        }


        public ICollection<Major> GetMajors()
        {
            IList<Major> majorList = new List<Major>();
            var query = (from major in _dataContext.Majors
                         select major)
                         .Where(x => x.Deleted == false);

            var majors = query.ToList();
            foreach (var major in majors)
            {
                majorList.Add(new Major()
                {
                    Id = major.Id,
                    Name = major.Name
                });
            }
            return majorList;
        }

        public ICollection<Degree> GetDegrees()
        {
            IList<Degree> degreeList = new List<Degree>();
            var query = (from degree in _dataContext.Degrees
                         select degree)
                         .Where(x => x.Deleted == false);

            var degrees = query.ToList();
            foreach (var degree in degrees)
            {
                degreeList.Add(new Degree()
                {
                    Id = degree.Id,
                    Name = degree.Name
                });
            }
            return degreeList;
        }

        public Student GetStudent(string id)
        {
            var student = (from s in _dataContext.Students
                           join sRole in _dataContext.UserRoles
                           on s.Id equals sRole.UserId
                           join role in _dataContext.Roles
                           on sRole.RoleId equals role.Id
                           where s.Deleted == false && role.Name == Roles.Student.ToString() && s.Id == id.ToString()
                           select s).Include(x => x.Degree).Include(x => x.Major)
                           .Include(x => x.StudentsCourses).SingleOrDefault();
            return student;

        }

        public void UpdateStudent(IntermediateStudent intermediateStudent, List<long> courseIds)
        {
            var oldCourses = (from sc in _dataContext.StudentsCourses
                             select sc)
                            .Where(x => x.Deleted == false && x.StudentId == intermediateStudent.Id)
                            .Select(x => x.CourseId).ToList();

            foreach (var oc in oldCourses)
            {
                if (courseIds.Contains(oc))
                {
                    courseIds.Remove(oc);
                }
                else
                {
                    var studentCourse = _dataContext.StudentsCourses.Where(e => e.StudentId == intermediateStudent.Id && e.CourseId == oc).SingleOrDefault();
                    _dataContext.StudentsCourses.Remove(studentCourse);
                    _dataContext.SaveChanges();
                }


            }

            var student = (from s in _dataContext.Students
                           where s.Id == intermediateStudent.Id
                           select s).Include(x => x.Major).Include(x => x.Degree).SingleOrDefault();

            student.FirstName = intermediateStudent.FirstName;
            student.SecondName = intermediateStudent.SecondName;
            student.LastName = intermediateStudent.LastName;
            student.Address = intermediateStudent.Address;
            student.EmergencyContactFullName = intermediateStudent.EmergencyContactFullName;
            student.EmergencyContactPhoneNumber = intermediateStudent.EmergencyContactPhoneNumber;
            student.PhoneNumber = intermediateStudent.PhoneNumber;
            student.Degree.Id = intermediateStudent.DegreeId;
            student.Major.Id = intermediateStudent.MajorId;
            student.Modified = true;
            student.CompanyName = intermediateStudent.CompanyName;
            student.Email = intermediateStudent.Email;
            student.NormalizedEmail = intermediateStudent.Email.ToUpper();
            student.UserName = intermediateStudent.Email;
            student.NormalizedUserName = intermediateStudent.Email.ToUpper();

            _dataContext.SaveChanges();

            foreach (var courseId in courseIds)
            {
                

                StudentsCourses studentCourse = new StudentsCourses()
                {
                    CourseId = courseId,
                    StudentId = intermediateStudent.Id
                };

                _dataContext.StudentsCourses.Add(studentCourse);
                _dataContext.SaveChanges();
            }
        }

        public void DeleteStudent(string studentId)
        {
            var student = (from s in _dataContext.Students
                          where s.Id == studentId.ToString()
                          select s).SingleOrDefault();

            student.Deleted = true;
            _dataContext.SaveChanges();
        }

        public ICollection<Skill> GetStudentSkills(string studentId)
        {
            var studentSkills = (from sc in _dataContext.StudentsCourses
                                 join cs in _dataContext.CoursesSkills
                                 on sc.CourseId equals cs.CourseId
                                 join s in _dataContext.Skills
                                 on cs.SkillId equals s.Id
                                 where sc.Deleted == false && cs.Deleted == false 
                                 && sc.Deleted == false && s.Deleted == false && sc.StudentId == studentId
                                 select s).Distinct().ToList();
            return studentSkills;
        }

        public Student GetStudentPortfolio(string studentId)
        {
            return _dataContext.Students.SingleOrDefault(x => x.Id == studentId);
        }
    }
}
