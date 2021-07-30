using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.Interface;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Library.Data;

namespace Library.LogicDb
{
    internal class Connection<T>
    where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public Connection(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity is null)
                throw new ArgumentException(null);

            dbSet.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            if (entity is null)
                throw new ArgumentException(null);

            dbSet.Remove(entity);
            Save();
        }

        public IEnumerable<T> Get()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<T> Get(string query)
        {
            if (query is null)
                throw new ArgumentException(null);

            return dbSet
                .Where(entity => entity.ToString().Contains(query))
                .AsEnumerable();
        }

        private void Save()
        {
            context.SaveChanges();
        }
    }
}
