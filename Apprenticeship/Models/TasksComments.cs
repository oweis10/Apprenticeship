using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    [Table("TaskComments")]
    public class TasksComments
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public Taskss Task { get; set; }
        public long TaskId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public bool Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
