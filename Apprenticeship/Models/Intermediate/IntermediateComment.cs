using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models.Intermediate
{
    public class IntermediateComment
    {
        public string Comment { get; set; }
        public long CommentId { get; set; }
        public string CommenterId { get; set; }
        public string CommenterName { get; set; }
        public DateTime Date { get; set; }
    }
}
