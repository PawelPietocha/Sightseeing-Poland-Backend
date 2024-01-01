using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifictions
{
    public class MountainWithMountainRangeAndVoivodeshipSpecification : BaseSpecification<Mountain>
    {
        public MountainWithMountainRangeAndVoivodeshipSpecification()
        {
            AddInclude(x => x.Voivodeship);
            AddInclude(x => x.MountainsRange);
        }

        public MountainWithMountainRangeAndVoivodeshipSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Voivodeship);
            AddInclude(x => x.MountainsRange);
        }
    }
}