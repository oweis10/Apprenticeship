using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apprenticeship.Data;
using Apprenticeship.Models;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship.Repositories
{
    public class NosRepository : INosRepository
    {
        private ApplicationDbContext _dataContext;

        public NosRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Nos> GetMajorNoses(long majorId)
        {
            var noses = _dataContext.MajorsNoses.Include(x => x.Nos)
                        .Where(x => x.MajorId == majorId).Select(x => x.Nos).ToList();
            return noses;
        }

        public Nos GetNos(long nosId)
        {
            var nos = (from Nos in _dataContext.Noses
                         select Nos)
                         .Where(x => x.Deleted == false && x.Id == nosId).SingleOrDefault();
            return nos;
        }

        public ICollection<Nos> GetNoses()
        {

            var noses = (from Nos in _dataContext.Noses
                         select Nos)
                         .Where(x => x.Deleted == false).ToList();
            return noses;
        }

        public ICollection<Nos> GetStudentNoses(string studentId)
        {
            var noses = _dataContext.PlacementsNoses.Include(x => x.Nos).Where(x => x.Placement.StudentId == studentId).Select(x => x.Nos).ToList();
            return noses;
        }

        public string GetNosUrl(long nosId)
        {
            return _dataContext.Noses.Where(x => x.Id == nosId && x.Deleted == false).Select(x => x.Url).SingleOrDefault();
        }

    }
}
