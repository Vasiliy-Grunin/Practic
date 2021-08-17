﻿using Library.DAL.Entitys.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Data
{
    public class LibraryDbContext : IdentityDbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }


        public DbSet<PeopleModel> Peoples { get; set; }

        public DbSet<BookModel> Books { get; set; }

        public DbSet<GenryModel> Genries { get; set; }

        public DbSet<AuthorModel> Authors { get; set; }

        public void AddCascadingObject(object rootEntity)
        {
            ChangeTracker.TrackGraph(
                rootEntity,
                node =>
                    node.Entry.State = !node.Entry.IsKeySet ? EntityState.Added : EntityState.Unchanged
            );
        }
    }
}
