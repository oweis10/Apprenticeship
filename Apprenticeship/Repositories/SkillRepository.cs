using Apprenticeship.Data;
using Apprenticeship.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        
        private ApplicationDbContext _dataContext;

        public SkillRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Skill> GetSkills()
        {
            IList<Skill> skillList = new List<Skill>();
            var query = (from Skill in _dataContext.Skills
                         select Skill)
                         .Where(x => x.Deleted == false);

            var skills = query.ToList();
            foreach (var skill in skills)
            {
                skillList.Add(new Skill()
                {
                    Id = skill.Id,
                    Name = skill.Name
                });
            }
            return skillList;
        }

        public Skill GetSkill(long Id)
        {
            var query = (from Skill in _dataContext.Skills
                         select Skill)
                         .Where(x => x.Deleted == false && x.Id == Id).FirstOrDefault();

           
            
            return query;
        }

        public void InsertSkill(Skill skill)
        {
            var skillData = new Skill()
            {
                Name = skill.Name,
                Deleted = false
            };
            _dataContext.Skills.Add(skillData);
            _dataContext.SaveChanges();
        }
        public void DeleteSkill(long skillId)
        {
            Skill skill = _dataContext.Skills.Where(e => e.Id == skillId).SingleOrDefault();
            skill.Deleted = true;
            //skill.DeletedBy = GetCurrentUserId().ToString();
            _dataContext.SaveChanges();
        }

        public void UpdateSkill(Skill skill)
        {
            Skill skillData = _dataContext.Skills.Where(e => e.Id == skill.Id).SingleOrDefault();
            skillData.Name = skill.Name;
            skillData.Modified = true;
            _dataContext.SaveChanges();
        }

    }
}
