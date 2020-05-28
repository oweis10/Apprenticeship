﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    public class Student : User
    {       
        public Major Major { get; set; }
        public Degree Degree { get; set; }
        public ICollection<StudentsCourses> StudentsCourses { get; set; }
        public ICollection<Placement> Placements { get; set; }
        public string EmergencyContactFullName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
    }
}
