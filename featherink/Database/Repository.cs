using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using featherink.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace featherink.Database
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;

        public Repository(FeatherInkContext context, IMapper mapper)
        {
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            IEnumerable<string> includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null) query = query.Where(filter);

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query,
                    (current, includeProperty) => current.Include(includeProperty));
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(string id, IEnumerable<string> includeProperties = null)
        {
            if (int.TryParse(id, out var result) && result >= 0)
            {
                return await GetById(result);
            }

            return null;
        }

        public async Task<TEntity> GetById(int id, IEnumerable<string> includeProperties = null)
        {
            if (id < 0)
            {
                return null;
            }

            // ReSharper disable once InvertIf
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    _dbSet.Include(includeProperty);
                }
            }

            return await _dbSet.FindAsync(id);
        }

        public async System.Threading.Tasks.Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<TEntity> UpdateById(int id, TEntity entity)
        {
            if (id < 0)
            {
                return null;
            }

            var entry = await _dbSet.FindAsync(id);

            if (entry == null)
            {
                return null;
            }

            _mapper.Map(entity, entry);
            entry.Id = id;

            return entry;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<TEntity> Delete(int id)
        {
            if (id < 0)
            {
                return null;
            }

            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            _dbSet.Remove(entity);

            return entity;
        }
    }
}
