﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using RestServiceCore.Domain.Entity;
using RestServiceCore.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestServiceCore.EntityFrameWork.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<int>
    {
        public BaseRepository(DataContext context)
        {
        }

        public abstract void Delete(int id);

        public abstract T Get(int id);

        public abstract IEnumerable<T> GetAll();

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task<T> GetAsync(int id);

        public abstract T Insert(T entity);

        public abstract Task<T> InsertAsync(T entity);

        public abstract void SaveChanges();

        public abstract Task SaveChangesAsync();

        public abstract T Update(T entity);

        public abstract Task<T> UpdateAsync(T entity);
    }
}
