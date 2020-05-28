﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    [Table("Majors")]
    public class Major
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<MajorsNoses> MajorsNoses { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public bool Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}