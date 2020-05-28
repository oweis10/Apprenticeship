using Apprenticeship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface ISkillRepository 
    {
        Skill GetSkill(long id);
        ICollection<Skill> GetSkills();
        void InsertSkill(Skill skill);
        void DeleteSkill(long skillId);
        void UpdateSkill(Skill skill);
    }
}
