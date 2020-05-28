using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models.Intermediate
{
    public class IntermediateTask
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Note { get; set; }
        [Required]
        public long NosId { get; set; }
        public string NosName { get; set; }
        public string NosUrl { get; set; }
        [Required]
        public List<IFormFile> files{ get; set; }
        public List<IntermediateFile> Files { get; set; }
        public List<IntermediateComment> Comments { get; set; }
        public string Status { get; set; }
        public string StudentId { get; set; }
    }
}
