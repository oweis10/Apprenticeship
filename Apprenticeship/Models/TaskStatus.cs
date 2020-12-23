using System;
using System.Collections.Generic;
using System.Linq;

namespace Apprenticeship.Models
{
    public class TaskStatus
    {
        
        public ReportApprovalStatus Status { get; set; }
        public Taskss Task { get; set; }
        public long TaskId { get; set; }
    }
}
