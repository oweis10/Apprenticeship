using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apprenticeship.Data;
using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship.Repositories
{
    public class PlacementRepository : IPlacementRepository
    {
        private ApplicationDbContext _dataContext;

        public PlacementRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void DeletePlacement(long placementId)
        {
            var placement = _dataContext.Placements.Include(x => x.PlacementsNoses).SingleOrDefault(x => x.Id == placementId);
            placement.Deleted = true;
            placement.PlacementsNoses.ToList().ForEach(z => { z.Deleted = true; });
            _dataContext.SaveChanges();
        }

        public ICollection<Nos> GetNoses()
        {
            return _dataContext.Noses.Where(x => x.Deleted == false).ToList();
        }

        public IntermediatePlacement GetPlacement(long placementId)
        {
            var noses = _dataContext.PlacementsNoses.Include(x => x.Nos)
                        .Where(x => x.Placement.Id == placementId && x.Deleted == false)
                        .Select(x => x.Nos.Id).ToList();

            var placement = _dataContext.Placements.Include(x => x.Student).Include(x => x.WorkMentor).Include(x => x.SchoolMentor).SingleOrDefault(x => x.Id == placementId);
            var intermediatePlacement = new IntermediatePlacement()
            {
                Id = placement.Id,
                CompanyName = placement.CompanyName,
                SchoolMentorId = placement.SchoolMentor.Id,
                SchoolMentorName = placement.SchoolMentor.FirstName + " " + placement.SchoolMentor.SecondName + " " + placement.SchoolMentor.LastName,
                StudentId = placement.Student.Id,
                StudentName = placement.Student.FirstName + " " + placement.Student.SecondName + " " + placement.Student.LastName,
                WorkMentorId = placement.WorkMentor.Id,
                WorkMentorName = placement.WorkMentor.FirstName + " " + placement.WorkMentor.SecondName + " " + placement.WorkMentor.LastName,
                StartDate = placement.StartDate,
                EndDate = placement.EndDate,
                Noses = noses
            };

            return intermediatePlacement;

        }

        public ICollection<Nos> GetPlacementNoses(long placementId)
        {
            return _dataContext.PlacementsNoses.Include(x => x.Nos).Where(x => x.Deleted == false && x.PlacementId == placementId).Select(x => x.Nos).ToList();
        }

        public ICollection<Placement> GetPlacements()
        {
            return _dataContext.Placements.Include(x => x.Student).Include(x => x.WorkMentor).Include(x => x.SchoolMentor).ToList();
        }

        public void InsertPlacement(IntermediatePlacement intermediatePlacement, List<long> noses)
        {
            var student = _dataContext.Students.SingleOrDefault(x => x.Id == intermediatePlacement.StudentId);
            var schoolMentor = _dataContext.SchoolMentors.SingleOrDefault(x => x.Id == intermediatePlacement.SchoolMentorId);
            var workMentor = _dataContext.WorkMentors.SingleOrDefault(x => x.Id == intermediatePlacement.WorkMentorId);
            var placement = new Placement()
            {
                CompanyName = intermediatePlacement.CompanyName,
                Deleted = false,
                StartDate = DateTime.Parse(intermediatePlacement.StartDate.ToShortDateString()),
                EndDate = DateTime.Parse(intermediatePlacement.EndDate.ToShortDateString()),
                Student = student,
                SchoolMentor = schoolMentor,
                WorkMentor = workMentor,
                PlacementsNoses = noses.Select(x => new PlacementsNoses() { NosId = x}).ToList()
            };
            _dataContext.Placements.Add(placement);
            _dataContext.SaveChanges();
            student.PortFolio = intermediatePlacement.portFolioFile.File;
            student.Name = intermediatePlacement.portFolioFile.Name;
            student.ContentType = intermediatePlacement.portFolioFile.ContentType;
            _dataContext.SaveChanges();

        }

        public void UpdatePlacement(IntermediatePlacement intermediatePlacement, List<long> noses)
        {
            var placement = _dataContext.Placements.Where(x => x.Deleted == false).SingleOrDefault(x => x.Id == intermediatePlacement.Id);

            var placementNoses = _dataContext.PlacementsNoses.Where(x => x.PlacementId == placement.Id).ToList();

            foreach (var nos in placementNoses)
            {
                _dataContext.PlacementsNoses.Remove(nos);
                _dataContext.SaveChanges();
            }


            placement.PlacementsNoses = intermediatePlacement.Noses.Select(x => new PlacementsNoses() { NosId = x }).ToList();
            placement.StartDate = intermediatePlacement.StartDate;
            placement.EndDate = intermediatePlacement.EndDate;
            placement.Modified = true;

            _dataContext.SaveChanges();

            //foreach (var nos in noses)
            //{
            //    var placementNos = new PlacementsNoses()
            //    {
            //        NosId = nos,
            //        PlacementId = placement.Id
            //    };
            //    _dataContext.PlacementsNoses.Add(placementNos);
            //    _dataContext.SaveChanges();
            //}

            //foreach (var on in oldNoses)
            //{
            //    if (noses.Contains(on.Url))
            //    {
            //        noses.Remove(on.Url);
            //    }
            //    else
            //    {
            //        var nos = _dataContext.Noses
            //            .Where(x => x.Url == on.Url)
            //        .Include(x => x.Placement)
            //        .Where(x => x.Placement.StudentId == intermediatePlacement.StudentId
            //                && x.Placement.SchoolMentorId == intermediatePlacement.SchoolMentorId
            //                && x.Placement.WorkMentorId == intermediatePlacement.WorkMentorId).SingleOrDefault();
            //        _dataContext.Noses.Remove(nos);
            //        _dataContext.SaveChanges();
            //    }
            //}


        }
    }
}
