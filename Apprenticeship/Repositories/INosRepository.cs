using Apprenticeship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface INosRepository
    {
        Nos GetNos(long nosId);
        ICollection<Nos> GetNoses();
        ICollection<Nos> GetMajorNoses(long majorId);
        ICollection<Nos> GetStudentNoses(string studentId);
        string GetNosUrl(long nosId);
    }
}
