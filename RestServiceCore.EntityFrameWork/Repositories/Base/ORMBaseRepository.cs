﻿using Microsoft.EntityFrameworkCore;

using RestServiceCore.Domain.Entity;
using RestServiceCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceCore.EntityFrameWork.Repositories.Base
{
    public class ORMBaseRepository<T, TPrimaryKey> : BaseRepository<T>, IBaseRepository<T>, IDisposable
       where T : BaseEntity<int>
    {
        private DataContext context;
        private DbSet<T> table;
        string errorMessage = string.Empty;

        public ORMBaseRepository(DataContext context) : base(context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            var entity = table.Local.FirstOrDefault(s => s.Id == id);
            if (entity == null)
            {
                if (entity == null)
                {
                    return;
                }
            }

            table.Remove(entity);
        }

       

        public override T Get(int id)
        {
            return table.FirstOrDefault(s => s.Id == id);
        }

        public override IEnumerable<T> GetAll()
        {
            return table.AsEnumerable();
        }

        public override T Insert(T entity)
        {
            table.Add(entity);
            return entity;
        }

        public override void SaveChanges()
        {
            context.SaveChanges();
        }

        public override async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public override T Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public override async Task<T> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(s => s.Id == id);
        }

        public override async Task<T> InsertAsync(T entity)
        {
             table.Add(entity);
             return await Task.FromResult(entity);
        }

        public override async Task<T> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }

    }
}
