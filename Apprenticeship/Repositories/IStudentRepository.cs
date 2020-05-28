using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface IStudentRepository
    {
        Student GetStudent(string id);
        ICollection<Student> GetStudents();
        Task InsertStudentAsync(IntermediateStudent intermediateStudent, string studentId);
        ICollection<Major> GetMajors();
        ICollection<Degree> GetDegrees();
        void DeleteStudent(string studentId);
        void UpdateStudent(IntermediateStudent intermediateStudent, List<long> courseIds);
        ICollection<Skill> GetStudentSkills(string studentId);
    }
}
