using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface IWorkMentorRepository
    {
        WorkMentor GetWorkMentor(string id);
        ICollection<WorkMentor> GetWorkMentors();
        Task InsertWorkMentorAsync(IntermediateMentor intermediateWorkMentor, string workMentorId);
        void DeleteWorkMentor(string workMentorId);
        void UpdateWorkMentor(IntermediateMentor intermediateWorkMentor);
        ICollection<Student> GetWorkMentorStudents(string userId);
    }
}
