using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    public class TaskFiles
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public Taskss Task { get; set; }
        [MaxLength]
        public Byte [] File { get; set; }
        public long TaskId { get; set; }
        public bool Deleted { get; set; }
        public long DeletedBy { get; set; }
        public bool Modified { get; set; }
        public long ModifiedBy { get; set; }
    }
}
