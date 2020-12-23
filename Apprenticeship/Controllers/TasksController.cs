using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Apprenticeship.Data;
using Apprenticeship.Models.Intermediate;
using Apprenticeship.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Apprenticeship.Controllers
{
    public class TasksController : Controller
    {
        private ITaskRepository _taskRepository;
        private INosRepository _nosRepository;

        public TasksController(ITaskRepository taskRepository, INosRepository nosRepository)
        {
            _taskRepository = taskRepository;
            _nosRepository = nosRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            dynamic task = new ExpandoObject();
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                task.tasks = _taskRepository.GetTasks(id);
                return View(task);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            List<SelectListItem> nosesList = new List<SelectListItem>();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Studentnoses = _nosRepository.GetStudentNoses(userId);

            foreach(var nos in Studentnoses)
            {
                nosesList.Add(new SelectListItem {
                    Text = nos.Name,
                    Value = nos.Id.ToString(),
                    
                });
            }
            ViewBag.nosesList = nosesList;
            return View();
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetNosUrl(string NosId)
        {
            var url = _nosRepository.GetNosUrl(long.Parse(NosId));
            return Json(url);
        }

        
        [Authorize]
        [HttpPost]
        //("UploadFiles")
        public IActionResult Create(IntermediateTask intermediateTask)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    long size = intermediateTask.files.Sum(f => f.Length);

                    var intermediatFiles = new List<IntermediateFile>();
                    foreach (var formFile in intermediateTask.files)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", formFile.FileName);
                        if (formFile.Length > 0)
                        {
                            Stream st = formFile.OpenReadStream();
                            using (BinaryReader br = new BinaryReader(st))
                            {
                                var byteFile = br.ReadBytes((int)st.Length);
                                var intermediatFile = new IntermediateFile()
                                {
                                    ContentType = formFile.ContentType,
                                    File = byteFile,
                                    Name = formFile.FileName
                                };

                                intermediatFiles.Add(intermediatFile);
                            }

                        }
                    }
                    intermediateTask.Files = intermediatFiles;
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _taskRepository.InsertTask(intermediateTask, userId);

                    return RedirectToAction("Index", "Tasks");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception e)
            {
                var msg = e.Message;
                return RedirectToAction("Index", "Tasks");
            }

        }

        [Authorize]
        public IActionResult ViewTask(long taskId)
        {
            var task = _taskRepository.ViewTask(taskId);
            var intermediateTask = new IntermediateTask()
            {
                Title = task.Title,
                Description = task.Description,
                Note = task.Note,
                Status = task.Status.ToString(),
                Id = task.Id,
                StudentId = task.StudentId,
                NosUrl = task.Nos.Url
            };

            var intermediateFiles = new List<IntermediateFile>();
            foreach(var file in task.TaskFiles)
            {
                intermediateFiles.Add(new IntermediateFile {
                    Id = file.Id,
                    ContentType = file.ContentType,
                    File = file.File,
                    Name = file.Name
                });
            }
            intermediateTask.Files = intermediateFiles;

            var intermediateComments = new List<IntermediateComment>();
            foreach(var comment in task.TasksComments)
            {
                intermediateComments.Add(new IntermediateComment {
                    Comment = comment.Comment,
                    CommentId = comment.Id,
                    CommenterName = comment.User.FirstName+" "+comment.User.LastName,
                    CommenterId = comment.UserId,
                    Date = comment.Date
                });
            }
            intermediateTask.Comments = intermediateComments;

            return View(intermediateTask);

        }

        [HttpGet]
        [Authorize]
        public long Comment(string comment, long taskId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _taskRepository.InsertTaksComment(comment, userId, taskId);
            return taskId;
            
            
        }

        [Authorize]
        public IActionResult EditView(long taskId)
        {
            var task = _taskRepository.ViewTask(taskId);
            var intermediateTask = new IntermediateTask()
            {
                Title = task.Title,
                Description = task.Description,
                Note = task.Note,
                Status = task.Status.ToString(),
                Id = task.Id,
                StudentId = task.StudentId
            };

            var intermediateFiles = new List<IntermediateFile>();
            foreach (var file in task.TaskFiles)
            {
                intermediateFiles.Add(new IntermediateFile
                {
                    Id = file.Id,
                    ContentType = file.ContentType,
                    File = file.File,
                    Name = file.Name
                });
            }
            intermediateTask.Files = intermediateFiles;
            

            return View(intermediateTask);
        }

        [Authorize]
        //[HttpPost("UploadFiles")]
        public IActionResult Edit(IntermediateTask intermediateTask, List<IFormFile> files)
        {

            try
            {
                long size = files.Sum(f => f.Length);

                var intermediatFiles = new List<IntermediateFile>();
                foreach (var formFile in files)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", formFile.FileName);
                    if (formFile.Length > 0)
                    {
                        Stream st = formFile.OpenReadStream();
                        using (BinaryReader br = new BinaryReader(st))
                        {
                            var byteFile = br.ReadBytes((int)st.Length);
                            var intermediatFile = new IntermediateFile()
                            {
                                ContentType = formFile.ContentType,
                                File = byteFile,
                                Name = formFile.FileName
                            };

                            intermediatFiles.Add(intermediatFile);
                        }

                    }
                }
                intermediateTask.Files = intermediatFiles;
                //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _taskRepository.UpdateTask(intermediateTask);

                return RedirectToAction("Index", "Tasks");
            }
            catch (Exception e)
            {
                var msg = e.Message;
                return RedirectToAction("Index", "Tasks");
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult StudentTasks(string studentId)
        {
            dynamic task = new ExpandoObject();
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                task.tasks = _taskRepository.GetTasks(studentId);
                return View(task);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(long taskId)
        {
            try
            {
                _taskRepository.DeleteTask(taskId);
                return RedirectToAction("Index", "Tasks");
            }
            catch
            {
                return RedirectToAction("Index", "Tasks");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Approve(long taskId)
        {
            var previousUrl = Request.Headers["Referer"].ToString();
            await _taskRepository.ApproveTask(taskId);
            
            return Redirect(previousUrl);
        }

        [Authorize]
        [HttpGet]
        public bool Reject(long taskId, string note)
        {
            try
            {
                _taskRepository.RejectTask(taskId, note);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        [Authorize]
        public FileStreamResult GetFile(long fileId)
        {
            var file = _taskRepository.GetFile(fileId);
            Stream stream = new MemoryStream(file.File);
            return new FileStreamResult(stream, file.ContentType);
            
        }
    }
}