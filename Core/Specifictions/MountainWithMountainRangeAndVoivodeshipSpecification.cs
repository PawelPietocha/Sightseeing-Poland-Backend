using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifictions
{
    public class MountainWithMountainRangeAndVoivodeshipSpecification : BaseSpecification<Mountain>
    {
        public MountainWithMountainRangeAndVoivodeshipSpecification(
            MountainsSpecParams mountainsParams)
            :base(x =>
                (string.IsNullOrEmpty(mountainsParams.Search) || x.Name.ToLower().Contains
                (mountainsParams.Search)) && 
                (!mountainsParams.VoivodeshipId.HasValue || x.VoivodeshipId == mountainsParams.VoivodeshipId) &&
                (!mountainsParams.MountainsRangeId.HasValue || x.MountainsRangeId == mountainsParams.MountainsRangeId)
            )
        {
            AddInclude(x => x.Voivodeship);
            AddInclude(x => x.MountainsRange);
            AddOrderBy(x => x.Name);
            ApplyPaging(mountainsParams.PageSize * (mountainsParams.PageIndex - 1),
                mountainsParams.PageSize);

            if(!string.IsNullOrEmpty(mountainsParams.Sort)) 
            {
                switch (mountainsParams.Sort)
                {
                    case "heightAsc":
                        AddOrderBy(m => m.Height);
                        break;
                    case "heightDesc":
                        AddOrderByDescending(m => m.Height);
                        break;
                    case "voivodeshipAsc":
                        AddOrderBy(m => m.Voivodeship);
                        break;
                    case "voivodeshipDesc":
                        AddOrderByDescending(m => m.Voivodeship);
                        break;
                    case "mountainsRangeAsc": 
                        AddOrderBy(m => m.MountainsRange.Name);
                        break;
                    case "mountainsRangeDesc": 
                        AddOrderByDescending(m => m.MountainsRange.Name);
                        break;
                    default: 
                        AddOrderBy(m => m.Name);
                        break;
                };
            }
        }

        public MountainWithMountainRangeAndVoivodeshipSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Voivodeship);
            AddInclude(x => x.MountainsRange);
        }
    }
}