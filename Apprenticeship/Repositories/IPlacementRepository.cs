using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface IPlacementRepository
    {
        IntermediatePlacement GetPlacement(long placementId);
        ICollection<Placement> GetPlacements();
        void InsertPlacement(IntermediatePlacement intermediatePlacement, List<long> noses);
        void DeletePlacement(long placementId);
        void UpdatePlacement(IntermediatePlacement intermediatePlacement, List<long> noses);
        ICollection<Nos> GetNoses();
        ICollection<Nos> GetPlacementNoses(long placementId);
    }
}
