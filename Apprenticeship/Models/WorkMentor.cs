using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    public class WorkMentor : User
    {
        public ICollection<Placement> Placements { get; set; }
    }
}
