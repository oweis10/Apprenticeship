using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Apprenticeship.Models;
using Apprenticeship.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Apprenticeship.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _courseRepository;
        private ISkillRepository _skillRepository;

        public CourseController(ICourseRepository courseRepository, ISkillRepository skillRepository)
        {
            _courseRepository = courseRepository;
            _skillRepository = skillRepository;
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            dynamic course = new ExpandoObject();
            try
            {
                course.courses = _courseRepository.GetCourses();
                return View(course);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Authorize]
        public IActionResult CreateView(long? Id)
        {
            try
            {
                var skills = _skillRepository.GetSkills();
                List<SelectListItem> skillsList = new List<SelectListItem>();
                foreach(var skill in skills)
                {
                    skillsList.Add(new SelectListItem {
                        Text = skill.Name,
                        Value = skill.Id.ToString()
                    });
                }
                ViewBag.skills = skillsList;
                return View("CreateView");
            }
            catch
            {
                return RedirectToAction("Index", "Course");
            }
        }

        [Authorize]
        public IActionResult Create(CoursesSkills coursesSkills)
        {

            try
            {
                _courseRepository.InsertCourse(coursesSkills.Course.CourseName, coursesSkills.SkillId);
                return RedirectToAction("Index", "Course");
            }
            catch
            {
                return RedirectToAction("Index", "Course");
            }

        }

        [Authorize]
        public IActionResult EditView(long courseId, long skillId)
        {
            try
            {
                var course = _courseRepository.GetCourse(courseId, skillId);
                ICollection<Skill> courseSkills = _courseRepository.GetCourseSkills(courseId);
                ICollection<Skill> skills = _skillRepository.GetSkills();
                List<Skill> newSkills = new List<Skill>();
                List<SelectListItem> skillsList = new List<SelectListItem>();
                foreach (var cs in courseSkills)
                {
                    skillsList.Add(new SelectListItem
                    {
                        Text = cs.Name,
                        Value = cs.Id.ToString(),
                        Selected = true

                    });
                }
                
                foreach(var s in skills.ToList())
                {
                    if (courseSkills.Where(x => x.Id == s.Id).Any())
                    {
                        continue;
                    }
                    else
                        newSkills.Add(s);
                }

                foreach(var s in newSkills)
                {
                    skillsList.Add(new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString(),
                        Selected = false

                    });
                }
                
                ViewBag.skills = skillsList;
                return View(course);
            }
            catch
            {
                return RedirectToAction("Index", "Course");
            }

        }

        [Authorize]
        public IActionResult Edit(CoursesSkills courseSkill,long courseId, List<long>skillId)
        {

            try
            {
                _courseRepository.UpdateCourse(courseSkill.Course.CourseName, courseId, skillId);
                return RedirectToAction("Index", "Course");
            }
            catch
            {
                return RedirectToAction("Index", "Course");
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(long courseId)
        {
            try
            {
                _courseRepository.DeleteCourse(courseId);
                return RedirectToAction("Index", "Course");
            }
            catch
            {
                return RedirectToAction("Index", "Course");
            }

        }
    }
}