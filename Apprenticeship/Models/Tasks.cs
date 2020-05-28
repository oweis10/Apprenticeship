using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    [Table("Tasks")]
    public class Taskss
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public Nos Nos { get; set; }
        public long NosId { get; set; }
        public ICollection<TaskFiles> TaskFiles { get; set; }
        public ICollection<TasksComments> TasksComments { get; set; }
        public ReportApprovalStatus Status { get; set; }
        public Student Student { get; set; }
        public string StudentId { get; set; }
        public bool Deleted { get; set; }
        public long DeletedBy { get; set; }
        public bool Modified { get; set; }
        public long ModifiedBy { get; set; }
        
    }
    public enum ReportApprovalStatus
    {
        Approved = 1,
        [DisplayName("Pending Approval")]
        PendingApproval = 2,
        Rejected = 3
    }
}
