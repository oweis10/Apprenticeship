using Apprenticeship.Data;
using Apprenticeship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public class MajorAndDegreeRepository :IMajorAndDegreesRepository
    {
        private ApplicationDbContext _dataContext;

        public MajorAndDegreeRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Degree> GetDegrees()
        {
            var degrees = (from d in _dataContext.Degrees
                           select d).Where(x => x.Deleted == false).ToList();
            return degrees;
        }

        public ICollection<Major> GetMajors()
        {
            var majors = (from m in _dataContext.Majors
                           select m).Where(x => x.Deleted == false).ToList();
            return majors;
        }
    }
}
