using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    [Table("Lookups")]
    public class Lookups
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public bool Deleted { get; set; }
    }
}
