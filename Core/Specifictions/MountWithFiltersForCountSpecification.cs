using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifictions
{
    public class MountWithFiltersForCountSpecification :BaseSpecification<Mountain>
    {
        public MountWithFiltersForCountSpecification(MountainsSpecParams mountainsParams)
        :base(x =>
                (string.IsNullOrEmpty(mountainsParams.Search) || x.Name.ToLower().Contains
                (mountainsParams.Search)) && 
                (!mountainsParams.VoivodeshipId.HasValue || x.VoivodeshipId == mountainsParams.VoivodeshipId) &&
                (!mountainsParams.MountainsRangeId.HasValue || x.MountainsRangeId == mountainsParams.MountainsRangeId)
            )
        {
            
        }
    }
}