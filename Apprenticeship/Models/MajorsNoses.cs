using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    [Table("MajorsNoses")]
    public class MajorsNoses
    {
        public long Id { get; set; }
        public Major Major { get; set; }
        public long MajorId { get; set; }
        public Nos Nos { get; set; }
        public long NosId { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public bool Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
