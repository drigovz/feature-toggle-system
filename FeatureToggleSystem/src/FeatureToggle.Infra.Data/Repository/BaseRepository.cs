﻿using FeatureToggle.Domain.Entities;
using FeatureToggle.Domain.Interfaces.Repository;
using FeatureToggle.Infra.Data.Context;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace FeatureToggle.Infra.Data.Repository
{
    public class BaseRepository<E, T> : IBaseRepository<E, int> where E : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        protected internal async Task Commit() =>
            await _context.SaveChangesAsync();

        public async Task<IEnumerable<E>> GetAsync() =>
            await _context.Set<E>().ToListAsync();

        public async Task<E?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Set<E>().SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (entity != null)
                    return entity;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<E?> AddAsync(E entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;

                _context.Set<E>().Add(entity);
            }
            catch (Exception ex)
            {
                entity.Valid = false;
                entity.ValidationResult.Errors.Add(new ValidationFailure(ex.Source, ex.Message));
                return null;
            }
             
            await Commit();
            return entity;
        }

        public async Task<E?> UpdateAsync(E entity)
        {
            try
            {
                var result = await GetByIdAsync(entity.Id);
                if (result == null)
                    return null;

                entity.UpdatedAt = DateTime.UtcNow;
                entity.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(entity);
            }
            catch
            {
                return null;
            }

            await Commit();
            return entity;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                if (result == null)
                    return false;

                _context.Set<E>().Remove(result);
            }
            catch
            {
                return false;
            }

            await Commit();
            return true;
        }
    }
}
