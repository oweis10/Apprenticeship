using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface ISchoolMentorRepository
    {
        SchoolMentor GetSchoolMentor(string id);
        ICollection<SchoolMentor> GetSchoolMentors();
        Task InsertSchoolMentorAsync(IntermediateMentor intermediateMentor, string schoolMentorId);
        void DeleteSchoolMentor(string schoolMentorId);
        void UpdateSchoolMentor(IntermediateMentor intermediateSchoolMentor);
        ICollection<Student> GetSchoolMentorStudents(string userId);
    }
}
