using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models.Intermediate
{
    public class IntermediateFile
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public Byte[] File { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public IFormFile Files { get; set; }
    }
}
