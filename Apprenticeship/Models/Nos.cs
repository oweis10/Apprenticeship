using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    [Table("Noses")]
    public class Nos
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Qualification { get; set; }
        public ICollection<MajorsNoses> MajorsNoses { get; set; }
        public ICollection<PlacementsNoses> PlacementsNoses { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public bool Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
