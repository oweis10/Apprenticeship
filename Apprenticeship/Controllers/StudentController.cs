using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Apprenticeship.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apprenticeship.Controllers
{
    public class StudentController : Controller
    {
        private ITaskRepository _taskRepository;

        public StudentController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult TimeLine(string studentId)
        {
            dynamic task = new ExpandoObject();
            try
            {
                task.tasks = _taskRepository.GetTasks(studentId);
                return View(task);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}