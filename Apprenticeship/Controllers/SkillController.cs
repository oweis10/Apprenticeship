using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Apprenticeship.Data;
using Apprenticeship.Models;
using Apprenticeship.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship.Controllers
{
    public class SkillController : Controller
    {
        private ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            dynamic skill = new ExpandoObject();
            try
            {
                skill.skills = _skillRepository.GetSkills();
                return View(skill);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(long Id)
        {
            try
            {
                _skillRepository.DeleteSkill(Id);
                return RedirectToAction("Index", "Skill");
            }
            catch
            {
                return RedirectToAction("Index", "Skill");
            }
            
        }

        [Authorize]
        public IActionResult CreateView(long ?Id)
        {
            
            return View();
        }

        [Authorize]
        public IActionResult Create(Skill skill)
        {

            try
            {
                _skillRepository.InsertSkill(skill);
                return RedirectToAction("Index", "Skill");
            }
            catch
            {
                return RedirectToAction("Index", "Skill");
            }
            
        }

        [Authorize]
        public IActionResult EditView(long Id)
        {
            try
            {
                var skill = _skillRepository.GetSkill(Id);
                return View(skill);
            }
            catch
            {
                return RedirectToAction("Index", "Skill");
            }

        }

        [Authorize]
        public IActionResult Edit(Skill skill)
        {

            try
            {
                _skillRepository.UpdateSkill(skill);
                return RedirectToAction("Index", "Skill");
            }
            catch 
            {
                return RedirectToAction("Index", "Skill");
            }
            
        }
    }
}