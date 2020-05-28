using Apprenticeship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface IMajorAndDegreesRepository
    {
        ICollection<Degree> GetDegrees();
        ICollection<Major> GetMajors();
    }
}
