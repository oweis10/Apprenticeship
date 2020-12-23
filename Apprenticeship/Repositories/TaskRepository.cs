using Apprenticeship.Data;
using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private ApplicationDbContext _dataContext;

        public TaskRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Taskss GetTask(long taskId, long studentId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Taskss> GetTasks(string studentId)
        {
            if(studentId == null)
            {
                var tasks = _dataContext.Tasks.Where(x => x.Deleted == false).Include(x => x.Nos).Include(x => x.Student).Include(x => x.TaskFiles).Include(x => x.TaskFiles).Include(x => x.TasksComments).OrderBy(x=> x.CreateTime).ToList();
                return tasks;
            }
            else
            {
                var tasks = _dataContext.Tasks.Where(x => x.Deleted == false && x.StudentId == studentId).Include(x => x.Nos).Include(x => x.Student).Include(x => x.TaskFiles).Include(x => x.TaskFiles).Include(x => x.TasksComments).ToList();
                tasks = tasks.GroupBy(x => x.TaskGroup).OrderBy(x => x.First().CreateTime).Select(x => x.LastOrDefault()).ToList();
                return tasks;
            }
            
        }

        public ICollection<Taskss> GetTimelineTasks(string studentId)
        {
            if (studentId == null)
            {
                var tasks = _dataContext.Tasks.Where(x => x.Deleted == false).Include(x => x.Nos).Include(x => x.Student).Include(x => x.TaskFiles).Include(x => x.TaskFiles).Include(x => x.TasksComments).OrderBy(x => x.CreateTime).ToList();
                return tasks;
            }
            else
            {
                var tasks = _dataContext.Tasks.Where(x => x.Deleted == false && x.StudentId == studentId).Include(x => x.Nos).Include(x => x.Student).Include(x => x.TaskFiles).Include(x => x.TaskFiles).Include(x => x.TasksComments).OrderByDescending(x => x.CreateTime).ToList();
                //tasks = tasks.GroupBy(x => x.TaskGroup).OrderBy(x => x.First().CreateTime).Select(x => x.LastOrDefault()).ToList();
                return tasks;
            }

        }

        public ICollection<Taskss> GetWorkMentorTasks(string userId)
        {
            var tasks = (from t in _dataContext.Tasks
                         join p in _dataContext.Placements
                         on t.StudentId equals p.StudentId
                         where t.Deleted == false && p.Deleted == false && p.WorkMentorId == userId
                         select t).Include(x => x.Student).Distinct().ToList();
            tasks = tasks.GroupBy(x => x.TaskGroup).OrderBy(x => x.First().CreateTime).Select(x => x.LastOrDefault()).ToList();

            return tasks;
            
        }

        public ICollection<Taskss> GetSchoolMentorTasks(string userId)
        {
            var tasks = (from t in _dataContext.Tasks
                         join p in _dataContext.Placements
                         on t.StudentId equals p.StudentId
                         where t.Deleted == false && p.Deleted == false && p.SchoolMentorId == userId
                         select t).Include(x => x.Student).Distinct().ToList();
            return tasks;

        }

        public void InsertTask(IntermediateTask intermediatTask, string userId)
        {
            var student = _dataContext.Students.Where(x => x.Deleted == false).SingleOrDefault(x => x.Id == userId);

            var task = new Taskss()
            {
                Title = intermediatTask.Title,
                Description = intermediatTask.Description,
                Note = intermediatTask.Note,
                Deleted = false,
                Student = student,
                Status = ReportApprovalStatus.PendingApproval,
                NosId = intermediatTask.NosId,
                CreateTime = DateTime.Now
                
            };

            _dataContext.Tasks.Add(task);
            _dataContext.SaveChanges();
            var lastTaskGroup = _dataContext.Tasks.OrderBy(x => x.TaskGroup).Select(x => x.TaskGroup).LastOrDefault();
            task.TaskGroup = (lastTaskGroup == 0 ? 1 : lastTaskGroup + 1);
            _dataContext.SaveChanges();
            foreach(var file in intermediatTask.Files)
            {
                var taskFile = new TaskFiles()
                {
                    TaskId = task.Id,
                    File = file.File,
                    Deleted = false,
                    Task = task,
                    Name = file.Name,
                    ContentType = file.ContentType
                };
                _dataContext.TaskFiles.Add(taskFile);
                _dataContext.SaveChanges();
            }
        }

        public void UpdateTask(IntermediateTask intermediatTask)
        {
            var task = _dataContext.Tasks.Include(x => x.TaskFiles).Include(x => x.TasksComments).SingleOrDefault(x => x.Id == intermediatTask.Id && x.Deleted == false);

            var newTask = new Taskss();
            //newTask.Modified = true;
            newTask.Title = intermediatTask.Title;
            newTask.Description = intermediatTask.Description;
            newTask.Note = intermediatTask.Note;
            newTask.Status = ReportApprovalStatus.PendingApproval;
            newTask.TaskGroup = task.TaskGroup;
            newTask.CreateTime = DateTime.Now;
            newTask.NosId = task.NosId;
            newTask.StudentId = task.StudentId;
            newTask.Deleted = task.Deleted;
            _dataContext.Add(newTask);
            _dataContext.SaveChanges();
            //var taskFiles = _dataContext.TaskFiles.Where(x => x.TaskId == task.Id).ToList();
            //if(intermediatTask.Files.Any())
            //{
            //    foreach (var taskFile in taskFiles)
            //    {
            //        _dataContext.TaskFiles.Remove(taskFile);
            //        _dataContext.SaveChanges();
            //    }
            //}


            //task.Modified = true;
            //task.Title = intermediatTask.Title;
            //task.Description = intermediatTask.Description;
            //task.Note = intermediatTask.Note;
            //task.Status = ReportApprovalStatus.PendingApproval;

            if (intermediatTask.Files.Any())
            {
                foreach (var file in intermediatTask.Files)
                {
                    var taskFile = new TaskFiles()
                    {
                        TaskId = newTask.Id,
                        File = file.File,
                        Deleted = false,
                        Task = task,
                        Name = file.Name,
                        ContentType = file.ContentType
                    };
                    _dataContext.TaskFiles.Add(taskFile);
                    _dataContext.SaveChanges();
                }
            }
            else
            {
                
                foreach (var file in task.TaskFiles)
                {
                    var taskFiles = new TaskFiles()
                    {
                        TaskId = newTask.Id,
                        File = file.File,
                        Name = file.Name,
                        Url = file.Url,
                        Deleted = file.Deleted,
                        ContentType = file.ContentType
                    };

                    _dataContext.TaskFiles.Add(taskFiles);
                }

                _dataContext.SaveChanges();

                foreach (var cmnt in task.TasksComments)
                {
                    var comment = new TasksComments()
                    {
                        Comment = cmnt.Comment,
                        Date = cmnt.Date,
                        Deleted = cmnt.Deleted,
                        TaskId = newTask.Id,
                        UserId = cmnt.UserId
                    };

                    _dataContext.TasksComments.Add(comment);
                }
                _dataContext.SaveChanges();

            }

            
        }

        public Taskss ViewTask(long taskId)
        {
            var task = _dataContext.Tasks.Include(x => x.TaskFiles).Include(x => x.Nos).Include(x => x.TasksComments).ThenInclude(x => x.User).SingleOrDefault(x => x.Id == taskId && x.Deleted == false);
            return task;
        }

        public void InsertTaksComment(string comment, string userId, long taskId)
        {
            var task = _dataContext.Tasks.SingleOrDefault(x => x.Deleted == false && x.Id == taskId);
            var user = _dataContext.Users.SingleOrDefault(x => x.Deleted == false && x.Id == userId);
            var Comment = new TasksComments()
            {
                Comment = comment,
                Task = task,
                TaskId = taskId,
                User = user,
                UserId = userId,
                Deleted = false,
                Date = DateTime.Now
            };

            _dataContext.TasksComments.Add(Comment);
            _dataContext.SaveChanges();
        }

        public void DeleteTask(long taskId)
        {
            var task = _dataContext.Tasks.SingleOrDefault(x => x.Deleted == false && x.Id == taskId);
            task.Deleted = true;
            _dataContext.SaveChanges();
        }

        public async Task ApproveTask(long taskId)
        {
            var task = _dataContext.Tasks.Include(x => x.TaskFiles).Include(x => x.TasksComments).SingleOrDefault(x => x.Deleted == false && x.Id == taskId);
            
            var newTask = new Taskss();
            newTask.Title = task.Title;
            newTask.Description = task.Description;
            newTask.Note = task.Note;
            newTask.TaskGroup = task.TaskGroup;
            newTask.Status = ReportApprovalStatus.Approved;
            newTask.CreateTime = DateTime.Now;
            newTask.NosId = task.NosId;
            newTask.StudentId = task.StudentId;
            newTask.Deleted = task.Deleted;
            _dataContext.Add(newTask);
            await _dataContext.SaveChangesAsync();
            if (task.TaskFiles.Any())
            {
                foreach (var file in task.TaskFiles)
                {
                    var taskFiles = new TaskFiles()
                    {
                        TaskId = newTask.Id,
                        File = file.File,
                        Name = file.Name,
                        Url = file.Url,
                        Deleted = file.Deleted,
                        ContentType = file.ContentType
                    };

                    _dataContext.TaskFiles.Add(taskFiles);
                }

                _dataContext.SaveChanges();
            }

            if (task.TasksComments.Any())
            {
                foreach (var cmnt in task.TasksComments)
                {
                    var comment = new TasksComments()
                    {
                        Comment = cmnt.Comment,
                        Date = cmnt.Date,
                        Deleted = cmnt.Deleted,
                        TaskId = newTask.Id,
                        UserId = cmnt.UserId
                    };

                    _dataContext.TasksComments.Add(comment);
                }
                _dataContext.SaveChanges();
            }
        }

        public void RejectTask(long taskId, string note)
        {
            var task = _dataContext.Tasks.Include(x => x.TaskFiles).Include(x => x.TasksComments).SingleOrDefault(x => x.Deleted == false && x.Id == taskId);
            var newTask = new Taskss();
            newTask.Title = task.Title;
            newTask.Description = task.Description;
            newTask.Status = ReportApprovalStatus.PendingApproval;
            newTask.TaskGroup = task.TaskGroup;
            newTask.Status = ReportApprovalStatus.Rejected;
            newTask.Note = note;
            newTask.Deleted = task.Deleted;
            newTask.NosId = task.NosId;
            newTask.StudentId = task.StudentId;
            newTask.CreateTime = DateTime.Now;
            _dataContext.Add(newTask);
            _dataContext.SaveChanges();

            if(task.TaskFiles.Any())
            {
                foreach(var file in task.TaskFiles)
                {
                    var taskFiles = new TaskFiles()
                    {
                        TaskId = newTask.Id,
                        File = file.File,
                        Name = file.Name,
                        Url = file.Url,
                        Deleted = file.Deleted,
                        ContentType = file.ContentType
                    };

                    _dataContext.TaskFiles.Add(taskFiles);
                }

                _dataContext.SaveChanges();
            }

            if(task.TasksComments.Any())
            {
                foreach(var cmnt in task.TasksComments)
                {
                    var comment = new TasksComments()
                    {
                        Comment = cmnt.Comment,
                        Date = cmnt.Date,
                        Deleted = cmnt.Deleted,
                        TaskId = newTask.Id,
                        UserId = cmnt.UserId
                    };

                    _dataContext.TasksComments.Add(comment);
                }
                _dataContext.SaveChanges();
            }
            
        }

        public TaskFiles GetFile(long fileId)
        {
            return _dataContext.TaskFiles.SingleOrDefault(x => x.Id == fileId);
        }
    }
}
