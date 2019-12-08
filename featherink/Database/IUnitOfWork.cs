using featherink.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace featherink.Database
{
    public interface IUnitOfWork
    {
        Task Save();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
    }
}
