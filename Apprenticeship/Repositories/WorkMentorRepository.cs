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
    public class WorkMentorRepository : IWorkMentorRepository
    {
        private ApplicationDbContext _dataContext;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public WorkMentorRepository(ApplicationDbContext dataContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task InsertWorkMentorAsync(IntermediateMentor intermediateWorkMentor, string workMentorId)
        {
            var workMentor = await (from wm in _dataContext.WorkMentors
                                 where wm.Id == workMentorId
                                    select wm).SingleOrDefaultAsync();

            workMentor.FirstName = intermediateWorkMentor.FirstName;
            workMentor.SecondName = intermediateWorkMentor.SecondName;
            workMentor.LastName = intermediateWorkMentor.LastName;
            workMentor.Address = intermediateWorkMentor.Address;
            workMentor.Deleted = false;
            workMentor.CompanyName = intermediateWorkMentor.CompanyName;
            workMentor.PhoneNumber = intermediateWorkMentor.PhoneNumber;
            await _dataContext.SaveChangesAsync();


            IdentityUserRole<string> workMentorRole = new IdentityUserRole<string>()
            {
                UserId = workMentorId,
                RoleId = "4"
            };

            await _dataContext.UserRoles.AddAsync(workMentorRole);
            await _dataContext.SaveChangesAsync();
            
        }

        public ICollection<WorkMentor> GetWorkMentors()
        {
            IList<WorkMentor> workMentorList = new List<WorkMentor>();
            var query = (from wm in _dataContext.WorkMentors
                         join userRole in _dataContext.UserRoles
                         on wm.Id equals userRole.UserId
                         join role in _dataContext.Roles
                         on userRole.RoleId equals role.Id
                         where role.Name == Roles.WorkMentor.ToString()
                         select wm)
                         .Where(x => x.Deleted == false).ToList();

            var workMentors = query.ToList();
            return query;
        }

        
        public WorkMentor GetWorkMentor(string id)
        {
            var workMentor = (from wm in _dataContext.WorkMentors
                           join sRole in _dataContext.UserRoles
                           on wm.Id equals sRole.UserId
                           join role in _dataContext.Roles
                           on sRole.RoleId equals role.Id
                           where wm.Deleted == false && role.Name == Roles.WorkMentor.ToString() && wm.Id == id.ToString()
                           select wm).SingleOrDefault();
            return workMentor;

        }

        public void UpdateWorkMentor(IntermediateMentor intermediateWorkMentor)
        {
                var workMentor = (from wm in _dataContext.WorkMentors
                              where wm.Id == intermediateWorkMentor.Id
                              select wm).SingleOrDefault();

                workMentor.FirstName = intermediateWorkMentor.FirstName;
                workMentor.SecondName = intermediateWorkMentor.SecondName;
                workMentor.LastName = intermediateWorkMentor.LastName;
                workMentor.Address = intermediateWorkMentor.Address;
                workMentor.PhoneNumber = intermediateWorkMentor.PhoneNumber;
                workMentor.CompanyName = intermediateWorkMentor.CompanyName;
                workMentor.Modified = true;
                workMentor.Email = intermediateWorkMentor.Email;
                workMentor.NormalizedEmail = intermediateWorkMentor.Email.ToUpper();
                workMentor.UserName = intermediateWorkMentor.Email;
                workMentor.NormalizedUserName = intermediateWorkMentor.Email.ToUpper();

            _dataContext.SaveChanges();
            
            
        }

        public void DeleteWorkMentor(string workMentorId)
        {
            var workMentor = (from sm in _dataContext.WorkMentors
                          where sm.Id == workMentorId.ToString()
                          select sm).SingleOrDefault();

            workMentor.Deleted = true;
            _dataContext.SaveChanges();
        }


        public ICollection<Student> GetWorkMentorStudents(string userId)
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
                         && p.Deleted == false && p.WorkMentorId == userId
                         select student)
                         .Where(x => x.Deleted == false).ToList();

            var students = query.ToList();
            return query;
        }
    }
}
