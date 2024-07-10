using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifictions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SightseeingContext _context;
        public GenericRepository(SightseeingContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec) 
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public async Task<T> AddAsync(T objectToAdd)
        {
            var entity = await Task<T>.Run(() =>
            {
                var addedEntity =_context.Set<T>().Add(objectToAdd);
                _context.SaveChangesAsync();
                return addedEntity;
            }
             );
             return objectToAdd;

        }

        public async Task<T> UpdateAsync(T objectToUpdate)
        { 
            
              var entity = await Task<T>.Run(() =>
            {
                var updatedEntity =_context.Set<T>().Update(objectToUpdate);
                _context.SaveChangesAsync();
                return updatedEntity;
            }
             );
             return objectToUpdate;

        }

        public async Task<T> DeleteAsync(T objectToDelete)
        { 
              var entity = await Task<T>.Run(() =>
            {
                var deletedEntity =_context.Set<T>().Remove(objectToDelete);
                _context.SaveChangesAsync();
                return deletedEntity;
            }
             );
             return objectToDelete;

        }
    }
}