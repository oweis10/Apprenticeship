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
    public class SchoolMentorRepository : ISchoolMentorRepository
    {
        private ApplicationDbContext _dataContext;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public SchoolMentorRepository(ApplicationDbContext dataContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task InsertSchoolMentorAsync(IntermediateMentor intermediateMentor, string schoolMentorId)
        {
            var schoolWorkMentor = await (from sm in _dataContext.SchoolMentors
                                 where sm.Id == schoolMentorId
                                 select sm).SingleOrDefaultAsync();

            schoolWorkMentor.FirstName = intermediateMentor.FirstName;
            schoolWorkMentor.SecondName = intermediateMentor.SecondName;
            schoolWorkMentor.LastName = intermediateMentor.LastName;
            schoolWorkMentor.Address = intermediateMentor.Address;
            schoolWorkMentor.Deleted = false;
            schoolWorkMentor.CompanyName = intermediateMentor.CompanyName;
            schoolWorkMentor.PhoneNumber = intermediateMentor.PhoneNumber;
            await _dataContext.SaveChangesAsync();


            IdentityUserRole<string> schoolMentorRole = new IdentityUserRole<string>()
            {
                UserId = schoolMentorId,
                RoleId = "3"
            };

            await _dataContext.UserRoles.AddAsync(schoolMentorRole);
            await _dataContext.SaveChangesAsync();
            
        }

        public ICollection<SchoolMentor> GetSchoolMentors()
        {
            IList<SchoolMentor> schoolMentorList = new List<SchoolMentor>();
            var query = (from sm in _dataContext.SchoolMentors
                         join userRole in _dataContext.UserRoles
                         on sm.Id equals userRole.UserId
                         join role in _dataContext.Roles
                         on userRole.RoleId equals role.Id
                         where role.Name == Roles.SchoolMentor.ToString()
                         select sm)
                         .Where(x => x.Deleted == false).ToList();

            var schoolMentors = query.ToList();
            return query;
        }

        
        public SchoolMentor GetSchoolMentor(string id)
        {
            var schoolMentor = (from sm in _dataContext.SchoolMentors
                           join sRole in _dataContext.UserRoles
                           on sm.Id equals sRole.UserId
                           join role in _dataContext.Roles
                           on sRole.RoleId equals role.Id
                           where sm.Deleted == false && role.Name == Roles.SchoolMentor.ToString() && sm.Id == id.ToString()
                           select sm).SingleOrDefault();
            return schoolMentor;

        }

        public void UpdateSchoolMentor(IntermediateMentor intermediateSchoolMentor)
        {
                var schoolWorkMentor = (from sm in _dataContext.SchoolMentors
                              where sm.Id == intermediateSchoolMentor.Id
                              select sm).SingleOrDefault();

                schoolWorkMentor.FirstName = intermediateSchoolMentor.FirstName;
                schoolWorkMentor.SecondName = intermediateSchoolMentor.SecondName;
                schoolWorkMentor.LastName = intermediateSchoolMentor.LastName;
                schoolWorkMentor.Address = intermediateSchoolMentor.Address;
                schoolWorkMentor.CompanyName = intermediateSchoolMentor.CompanyName;
                schoolWorkMentor.PhoneNumber = intermediateSchoolMentor.PhoneNumber;
                schoolWorkMentor.Modified = true;

                _dataContext.SaveChanges();
            
            
        }

        public void DeleteSchoolMentor(string schoolMentorId)
        {
            var schoolMentor = (from sm in _dataContext.SchoolMentors
                          where sm.Id == schoolMentorId.ToString()
                          select sm).SingleOrDefault();

            schoolMentor.Deleted = true;
            _dataContext.SaveChanges();
        }

        public ICollection<Student> GetSchoolMentorStudents(string userId)
        {
            IList<Student> studentList = new List<Student>();
            var query = (from student in _dataContext.Students
                         join p in _dataContext.Placements
                         on student.Id equals p.StudentId
                         join userRole in _dataContext.UserRoles
                         on student.Id equals userRole.UserId
                         join role in _dataContext.Roles
                         on userRole.RoleId equals role.Id
                         where role.Name == Roles.Student.ToString()
                         && p.Deleted == false && p.SchoolMentorId == userId
                         select student)
                         .Where(x => x.Deleted == false).ToList();

            var students = query.ToList();
            return query;
        }
    }
}
