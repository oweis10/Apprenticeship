using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface ITaskRepository
    {
        Taskss GetTask(long taskId, long studentId);
        ICollection<Taskss> GetTasks(string studentId);
        void InsertTask(IntermediateTask intermediatTask, string userId);
        void DeleteTask(long taskId);
        Task ApproveTask(long taskId);
        void RejectTask(long taskId, string note);
        void UpdateTask(IntermediateTask intermediatTask);
        Taskss ViewTask(long taskId);
        void InsertTaksComment(string comment, string userId, long taskId);
        ICollection<Taskss> GetWorkMentorTasks(string userId);
        ICollection<Taskss> GetSchoolMentorTasks(string userId);
        TaskFiles GetFile(long fileId);
    }
}
