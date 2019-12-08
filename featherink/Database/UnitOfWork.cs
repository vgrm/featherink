using AutoMapper;
using featherink.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace featherink.Database
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly FeatherInkContext _context;
        private readonly IMapper _mapper;

        private Dictionary<string, object> _repositories;

        public UnitOfWork(FeatherInkContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var repositoryName = typeof(TEntity).Name;

            if (_repositories.ContainsKey(repositoryName))
            {
                return (IRepository<TEntity>)_repositories[repositoryName];
            }

            var repository = new Repository<TEntity>(_context, _mapper);

            _repositories.Add(repositoryName, repository);

            return repository;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
