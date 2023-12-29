using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMountainRepository
    {
        Task<Mountain> GetMountain(int id);

        Task<IReadOnlyList<Mountain>> GetMountains();
        Task<IReadOnlyList<Voivodeship>> GetVoivodeships();
        Task<IReadOnlyList<MountainsRange>> GetMountainsRanges();
    }
}