using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity>
    {
        //GET DATA
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);

        //CREATE
        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        // Update

        void Update(TEntity entity);

        // Delete

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        // Save

        Task<bool> SaveAsync();
    }
}
