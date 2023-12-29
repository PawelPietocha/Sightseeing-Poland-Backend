using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MountainRepository : IMountainRepository
    {
        private readonly SightseeingContext _context;
        public MountainRepository(SightseeingContext context)
        {
            _context = context;
        }

        public async Task<Mountain> GetMountain(int id)
        {
            return await _context.Mountains
                .Include(m => m.Voivodeship)
                .Include(m => m.MountainsRange)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IReadOnlyList<Mountain>> GetMountains()
        {
            return await _context.Mountains
                .Include(m => m.Voivodeship)
                .Include(m => m.MountainsRange)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<MountainsRange>> GetMountainsRanges()
        {
            return await _context.MountainsRanges.ToListAsync();
        }

        public async Task<IReadOnlyList<Voivodeship>> GetVoivodeships()
        {
            return await _context.Voivodeships.ToListAsync();
        }
    }
}