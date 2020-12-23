using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using Apprenticeship.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Apprenticeship.Controllers
{
    public class UserController : Controller
    {
        private IStudentRepository _studentRepository;
        private ISchoolMentorRepository _schoolMentorRepository;
        private IWorkMentorRepository _workMentorRepository;
        private ICourseRepository _courseRepository;
        private IMajorAndDegreesRepository _majorAndDegreesRepository;
        private UserManager<IdentityUser> _userManager;

        public UserController(IStudentRepository studentRepository, ICourseRepository courseRepository, IMajorAndDegreesRepository majorAndDegreesRepository, UserManager<IdentityUser> userManager, ISchoolMentorRepository schoolMentorRepository, IWorkMentorRepository workMentorRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _majorAndDegreesRepository = majorAndDegreesRepository;
            _userManager = userManager;
            _schoolMentorRepository = schoolMentorRepository;
            _workMentorRepository = workMentorRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult StudentIndex()
        {
            dynamic student = new ExpandoObject();
            try
            {
                student.students = _studentRepository.GetStudents();
                return View(student);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private void StudentFillListItems()
        {
            var majors = _majorAndDegreesRepository.GetMajors();
            var degrees = _majorAndDegreesRepository.GetDegrees();

            List<SelectListItem> majorsList = new List<SelectListItem>();
            List<SelectListItem> degreesList = new List<SelectListItem>();

            foreach (var major in majors)
            {
                majorsList.Add(new SelectListItem
                {
                    Text = major.Name,
                    Value = major.Id.ToString()
                });
            }
            ViewBag.majors = majorsList;

            foreach (var degree in degrees)
            {
                degreesList.Add(new SelectListItem
                {
                    Text = degree.Name,
                    Value = degree.Id.ToString()
                });
            }
            ViewBag.degrees = degreesList;

            var courses = _courseRepository.GetCoursesList();
            List<SelectListItem> coursesList = new List<SelectListItem>();
            foreach (var course in courses)
            {
                coursesList.Add(new SelectListItem
                {
                    Text = course.CourseName,
                    Value = course.CourseId.ToString()
                });
            }
            ViewBag.courses = coursesList;
        }
        [HttpGet]
        [Authorize]
        public IActionResult CreateStudent(long? Id)
        {
            try
            {
                StudentFillListItems();
                return View("CreateStudent");
            }
            catch
            {
                return RedirectToAction("Index", "StudentIndex");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(IntermediateStudent intermediateStudent)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student
                {
                    UserName = intermediateStudent.Email,
                    Email = intermediateStudent.Email
                };

                IdentityResult result = await _userManager.CreateAsync(student, intermediateStudent.Password);
                if (result.Succeeded)
                {
                    await _studentRepository.InsertStudentAsync(intermediateStudent, student.Id);
                    SendMail(intermediateStudent.Email, $"{intermediateStudent.FirstName} {intermediateStudent.LastName}", intermediateStudent.Password);
                    //var result1 = await _userManager.AddToRoleAsync(student, Roles.Student.ToString());
                    return RedirectToAction("StudentIndex", "User");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                StudentFillListItems();
                return View();
            }
            else
            {
                StudentFillListItems();
                return View();
            }
            
        }

        [Authorize]
        public IActionResult StudentEditView(string studentId)
        {
            try
            {
                var student = _studentRepository.GetStudent(studentId);

                List<long> studentCourses = new List<long>();
                foreach(var sc in student.StudentsCourses)
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
                    CompanyName = student.CompanyName,
                    Email = student.Email
                };
                ICollection<Major> majors = _studentRepository.GetMajors();
                List<SelectListItem> majorList = new List<SelectListItem>();
                foreach (var major in majors)
                {
                    if(major.Id == intermediateStudent.MajorId)
                    {
                        majorList.Add(new SelectListItem
                        {
                            Text = major.Name,
                            Value = major.Id.ToString(),
                            Selected = true

                        });
                    }
                    else
                    {
                        majorList.Add(new SelectListItem
                        {
                            Text = major.Name,
                            Value = major.Id.ToString(),
                            Selected = false

                        });
                    }
                }
                ViewBag.majors = majorList;

                ////////////////

                ICollection<Degree> degrees = _studentRepository.GetDegrees();
                List<SelectListItem> degreeList = new List<SelectListItem>();
                foreach (var degree in degrees)
                {
                    if (degree.Id == intermediateStudent.DegreeId)
                    {
                        degreeList.Add(new SelectListItem
                        {
                            Text = degree.Name,
                            Value = degree.Id.ToString(),
                            Selected = true

                        });
                    }
                    else
                    {
                        degreeList.Add(new SelectListItem
                        {
                            Text = degree.Name,
                            Value = degree.Id.ToString(),
                            Selected = false

                        });
                    }
                }

                ViewBag.degrees = degreeList;
                /////////
                
                ICollection<CoursesSkills> courses = _courseRepository.GetCourses();
                List<SelectListItem> courseList = new List<SelectListItem>();
                foreach(var course in courses)
                {
                    if(intermediateStudent.StudentsCoursesIds.Where(x => x == course.CourseId).Any())
                    {
                        courseList.Add(new SelectListItem
                        {
                            Text = course.Course.CourseName,
                            Value = course.CourseId.ToString(),
                            Selected = true

                        });
                    }
                    else
                    {
                        courseList.Add(new SelectListItem
                        {
                            Text = course.Course.CourseName,
                            Value = course.CourseId.ToString(),
                            Selected = false

                        });
                    }
                }
                ViewBag.courses = courseList;
                return View(intermediateStudent);
            }
            catch
            {
                return RedirectToAction("StudentIndex", "User");
            }

        }

        [Authorize]
        public IActionResult EditStudent(IntermediateStudent intermediateStudent, List<long> courseIds)
        {

            try
            {
                courseIds = intermediateStudent.StudentsCoursesIds;
                var oldEmail = _studentRepository.GetStudent(intermediateStudent.Id).Email;
                _studentRepository.UpdateStudent(intermediateStudent, courseIds);
                
                if(oldEmail != intermediateStudent.Email)
                {
                    SendMail(intermediateStudent.Email, $"{intermediateStudent.FirstName} {intermediateStudent.LastName}", intermediateStudent.Password);
                }
                return RedirectToAction("StudentIndex", "User");
            }
            catch
            {
                return RedirectToAction("StudentIndex", "User");
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult DeleteStudent(string studentId)
        {
            try
            {
                _studentRepository.DeleteStudent(studentId);
                return RedirectToAction("StudentIndex", "User");
            }
            catch
            {
                return RedirectToAction("StudentIndex", "User");
            }

        }

        ////////////

        [Authorize]
        [HttpGet]
        public IActionResult SchoolMentorIndex()
        {
            dynamic schoolMentor = new ExpandoObject();
            try
            {
                schoolMentor.schoolMentors = _schoolMentorRepository.GetSchoolMentors();
                return View(schoolMentor);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateSchoolMentor()
        {
            try
            {
                return View("CreateSchoolMentor");
            }
            catch
            {
                return RedirectToAction("Index", "SchoolMentorIndex");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateSchoolMentor(IntermediateMentor intermediateSchoolMentor)
        {
            if (ModelState.IsValid)
            {
                SchoolMentor schoolMentor = new SchoolMentor
                {
                    UserName = intermediateSchoolMentor.Email,
                    Email = intermediateSchoolMentor.Email
                };

                IdentityResult result = await _userManager.CreateAsync(schoolMentor, intermediateSchoolMentor.Password);
                if (result.Succeeded)
                {
                    await _schoolMentorRepository.InsertSchoolMentorAsync(intermediateSchoolMentor, schoolMentor.Id);
                    SendMail(schoolMentor.Email, $"{schoolMentor.FirstName} {schoolMentor.LastName}", intermediateSchoolMentor.Password);
                    //var result1 = await _userManager.AddToRoleAsync(student, Roles.Student.ToString());
                    return RedirectToAction("SchoolMentorIndex", "User");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            else
            {
                return View();
            }
            
        }

        [Authorize]
        public IActionResult SchoolMentorEditView(string schoolMentorId)
        {
            try
            {

                var schoolMentor = _schoolMentorRepository.GetSchoolMentor(schoolMentorId);

                
                var intermediateSchoolMentor = new IntermediateMentor()
                {
                    Id = schoolMentor.Id,
                    FirstName = schoolMentor.FirstName,
                    SecondName = schoolMentor.SecondName,
                    LastName = schoolMentor.LastName,
                    Address = schoolMentor.Address,
                    PhoneNumber = schoolMentor.PhoneNumber,
                    CompanyName = schoolMentor.CompanyName,
                    Email = schoolMentor.Email
                };

                return View(intermediateSchoolMentor);
            }
            catch
            {
                return RedirectToAction("SchoolMentorIndex", "User");
            }

        }

        [Authorize]
        public IActionResult EditSchoolMentor(IntermediateMentor intermediateSchoolMentor)
        {

            try
            {
                var oldEmail = _schoolMentorRepository.GetSchoolMentor(intermediateSchoolMentor.Id).Email;
                _schoolMentorRepository.UpdateSchoolMentor(intermediateSchoolMentor);
                if (oldEmail != intermediateSchoolMentor.Email)
                {
                    SendMail(intermediateSchoolMentor.Email, $"{intermediateSchoolMentor.FirstName} {intermediateSchoolMentor.LastName}", intermediateSchoolMentor.Password);
                }
                return RedirectToAction("SchoolMentorIndex", "User");
            }
            catch
            {
                return RedirectToAction("SchoolMentorIndex", "User");
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult DeleteSchoolMentor(string schoolMentorId)
        {
            try
            {
                _schoolMentorRepository.DeleteSchoolMentor(schoolMentorId);
                return RedirectToAction("SchoolMentorIndex", "User");
            }
            catch
            {
                return RedirectToAction("SchoolMentorIndex", "User");
            }

        }

        ///////////
        
        
        [Authorize]
        [HttpGet]
        public IActionResult WorkMentorIndex()
        {
            dynamic workMentor = new ExpandoObject();
            try
            {
                //SendMail("oweis10@gmail.com", $"Khaled Oweis", "P@ssw0rd");
                workMentor.workMentors = _workMentorRepository.GetWorkMentors();
                return View(workMentor);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateWorkMentor()
        {
            try
            {
                return View("CreateWorkMentor");
            }
            catch
            {
                return RedirectToAction("Index", "WorkMentorIndex");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateWorkMentor(IntermediateMentor intermediateWorkMentor)
        {
            if (ModelState.IsValid)
            {
                WorkMentor workMentor = new WorkMentor
                {
                    UserName = intermediateWorkMentor.Email,
                    Email = intermediateWorkMentor.Email
                };

                IdentityResult result = await _userManager.CreateAsync(workMentor, intermediateWorkMentor.Password);
                if (result.Succeeded)
                {
                    await _workMentorRepository.InsertWorkMentorAsync(intermediateWorkMentor, workMentor.Id);
                    //var result1 = await _userManager.AddToRoleAsync(student, Roles.Student.ToString());
                    SendMail(workMentor.Email, $"{workMentor.FirstName} {workMentor.LastName}", intermediateWorkMentor.Password);
                    return RedirectToAction("WorkMentorIndex", "User");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            else
            {
                return View();
            }
            
        }

        [Authorize]
        public IActionResult WorkMentorEditView(string workMentorId)
        {
            try
            {

                var workMentor = _workMentorRepository.GetWorkMentor(workMentorId);


                var intermediateWorkMentor = new IntermediateMentor()
                {
                    Id = workMentor.Id,
                    FirstName = workMentor.FirstName,
                    SecondName = workMentor.SecondName,
                    LastName = workMentor.LastName,
                    Address = workMentor.Address,
                    PhoneNumber = workMentor.PhoneNumber,
                    CompanyName = workMentor.CompanyName,
                    Email = workMentor.Email
                };

                return View(intermediateWorkMentor);
            }
            catch
            {
                return RedirectToAction("WorkMentorIndex", "User");
            }

        }

        [Authorize]
        public IActionResult EditWorkMentor(IntermediateMentor intermediateWorkMentor)
        {

            try
            {
                var oldEmail = _workMentorRepository.GetWorkMentor(intermediateWorkMentor.Id).Email;
                _workMentorRepository.UpdateWorkMentor(intermediateWorkMentor);
                if (oldEmail != intermediateWorkMentor.Email)
                {
                    SendMail(intermediateWorkMentor.Email, $"{intermediateWorkMentor.FirstName} {intermediateWorkMentor.LastName}", intermediateWorkMentor.Password);
                }
                return RedirectToAction("WorkMentorIndex", "User");
            }
            catch
            {
                return RedirectToAction("WorkMentorIndex", "User");
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult DeleteWorkMentor(string workMentorId)
        {
            try
            {
                _workMentorRepository.DeleteWorkMentor(workMentorId);
                return RedirectToAction("WorkMentorIndex", "User");
            }
            catch
            {
                return RedirectToAction("WorkMentorIndex", "User");
            }

        }



        private void SendMail(string email, string name, string password)
        {
            using (var message = new MailMessage("htuapprenticeship@htu.edu.jo", email))
            {
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress("htuapprenticeship@htu.edu.jo");
                message.Subject = "New E-Mail from HTU";
                message.Body = $"Dear {name},<br/><br/>A new account has been created for you at HTU-Apprenticeship and you have been issued with a new temporary password.<br/>Your current login information is now:<br/><br/>username: {email}<br/>password: {password}<br/><br/>You can change your password from your settings,<br/><br/>here is the link to your portal: https://213.186.163.242:2000 <br/>Thank you.";
                message.IsBodyHtml = true;
                using (var smtpClient = new SmtpClient("smtp.office365.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("htuapprenticeship@htu.edu.jo", "Apprentice@2020");
                    smtpClient.Send(message);
                }
            }
        }
    }
}