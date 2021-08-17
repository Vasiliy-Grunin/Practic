using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Library.DAL.Data;

namespace Library.DAL.Service.Other
{
    /// <summary>
    /// A Repository pattern mediates data
    /// from and to the Domain and Data Access Layers
    /// </summary>
    /// <typeparam name="TEntity">Entity in Db</typeparam>
    /// <typeparam name="EDto">Entity that dto</typeparam>
    internal class Connection<TEntity,EDto>
    where TEntity : class
    where EDto : class
    {
        private readonly LibraryDbContext context;
        private readonly DbSet<TEntity> dbSet;

        internal Connection(LibraryDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentException(null);

            dbSet.Add(entity);
            Save();
        }

        public void Delete(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentException(null);

            dbSet.Remove(entity);
            Save();
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<EDto> Get(string query)
        {
            if (query is null)
                throw new ArgumentException(null);


            var mapper = new Mapper(
                new MapperConfiguration(cfg => cfg.CreateMap<TEntity, EDto>()));
            return mapper
                .Map<IEnumerable<TEntity>,IEnumerable<EDto>>(dbSet
                .Where(entity => entity.ToString().Contains(query))
                .AsEnumerable());
        }

        private void Save()
        {
            context.SaveChanges();
        }
    }
}
