using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using Apprenticeship.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apprenticeship.Controllers
{
    public class SchoolMentorController : Controller
    {
        private ITaskRepository _taskRepository;
        private ISchoolMentorRepository _schoolMentorRepository;
        private IStudentRepository _studentRepository;

        public SchoolMentorController(ITaskRepository taskRepository, ISchoolMentorRepository schoolMentorRepository, IStudentRepository studentRepository)
        {
            _taskRepository = taskRepository;
            _schoolMentorRepository = schoolMentorRepository;
            _studentRepository = studentRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Tasks()
        {
            dynamic task = new ExpandoObject();
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                task.tasks = _taskRepository.GetSchoolMentorTasks(userId);
                return View(task);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Students()
        {
            dynamic student = new ExpandoObject();
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                student.students = _schoolMentorRepository.GetSchoolMentorStudents(userId);
                return View(student);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Authorize]
        public IActionResult Student(string studentId)
        {
            try
            {
                var student = _studentRepository.GetStudent(studentId);

                List<long> studentCourses = new List<long>();
                foreach (var sc in student.StudentsCourses)
                {
                    studentCourses.Add(sc.CourseId);
                }
                var intermediateStudent = new IntermediateStudent()
                {
                    Id = student.Id,
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    SecondName = student.SecondName,
                    LastName = student.LastName,
                    Address = student.Address,
                    EmergencyContactFullName = student.EmergencyContactFullName,
                    EmergencyContactPhoneNumber = student.EmergencyContactPhoneNumber,
                    PhoneNumber = student.PhoneNumber,
                    DegreeId = student.Degree.Id,
                    MajorId = student.Major.Id,
                    StudentsCoursesIds = studentCourses,
                    DegreeName = student.Degree.Name,
                    MajorName = student.Major.Name,
                    CompanyName = student.CompanyName,
                    Email = student.Email


                };
                ICollection<Skill> skills = _studentRepository.GetStudentSkills(studentId);

                List<string> studentSkills = new List<string>();
                foreach (var skill in skills)
                {
                    studentSkills.Add(skill.Name);

                }
                ViewBag.skills = studentSkills;
                return View(intermediateStudent);
            }
            catch
            {
                return RedirectToAction("Students", "WorkMentor");
            }

        }
    }
}