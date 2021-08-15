using Library.DAL.Entitys.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {

            string listFullName = @"Пирожкова Тамара Елизаровна
Воробьева Майя Давидовна
Яблонцев Никон Евграфович
Лебедева Дина Серафимовна
Жданова Рада Николаевна
Трошкина Бронислава Тимофеевна
Квартовский Аристарх Архипович
Якушин Никифор Ефремович
Гребнев Емельян Пахомович
Кувардин Поликарп Самсонович
Ельцов Моисей Викентиевич
Кочкорбаева Жанна Леонидовна
Корниенко Лев Матвеевич
Черепанова Оксана Николаевна
Новикова Роза Марковна
Ключникова Тамара Германовна
Онегина Зоя Семеновна
Юхтриц Аскольд Валерьянович
Кетов Аким Матвеевич
Сутулина Лада Андрияновна
Оленева Стела Леонидовна
Саракаев Валентин Ипатович
Гребенникова Клара Алексеевна
Яценко Евграф Олегович
Лассмана Лариса Афанасиевна";

            string birhtday = @"04.02.2009
17.01.2008
12.12.2003
14.03.2008
30.10.2013
24.09.2008
03.12.2010
13.08.2018
15.05.2008
22.01.2020
28.12.2018
30.11.2009
11.12.2013
22.09.2008
17.11.2006
08.06.2012
20.04.2010
16.02.2017
12.03.2009
08.03.2004
07.12.2007
25.08.2010
24.06.2021
05.04.2010
16.12.2019";

            string titleBook = @"Baker Of The River
Criminal Of Rainbows
Turtles Of Wood
Giants Of Darkness
Snakes And Slaves
Descendants And Hunters
Confinement Without Courage
Moon Of The Stars
Vanish In My School
Symbols Of The Town
Clone Of The Fallen
Defender With Spaceships
Spies Of The Void
Emperors Of The Sun
Creatures And Traitors
Volunteers And Officers
Corruption Of The Void
Ascension Of Death
Bored By The Machines
Inspired By Robotic Control";

            string fullNameAuthor = @"Lewie Emery
Kirandeep Nixon
Loren Bate
Inez Leech
Nathaniel Salazar
Millicent Walker
Zeeshan Dodd
Mathilda Esquivel
Uwais Carter
Keeley Rawlings
Garrett Flowers
Johnny Hardy
Pollyanna Schroeder
Jasmine Alvarez
Yuvraj Costa
Aanya Hurst
Robin Peralta
Tanisha Wardle
Subhaan Stott
Braxton Thomas";



            builder.Entity<GenryModel>()
                .HasMany(tab => tab.Books);
            builder.Entity<PeopleModel>()
                .HasMany(tab  => tab.Books);
            builder.Entity<BookModel>()
                .HasMany(tab => tab.Master);
            builder.Entity<AuthorModel>()
                .HasMany(tab => tab.Books);

            var listFIO = listFullName.Split("\r\n");
            var listBirhtday = birhtday.Split("\r\n");
            var nameBook = titleBook.Split("\r\n");
            var authors = fullNameAuthor.Split("\r\n");
            var random = new Random();

            var listPerson = new List<PeopleModel>();
            var listBooks = new List<BookModel>();
            var listAuthors = new List<AuthorModel>();
            var listGenry = new List<GenryModel>()
            {
                new GenryModel() { Id = 1, Name = "horror" },
                new GenryModel() { Id = 2, Name = "drama" },
                new GenryModel() { Id = 3, Name = "sci-fi" }

            };

            for (int i = 0; i < listFIO.Length; i++)
            {
                var fio = listFIO[i].Split(" ");
                listPerson.Add(new PeopleModel()
                {
                    Id = i + 1,
                    LastName = fio[0],
                    Name = fio[1],
                    MidleName = fio[2],
                    Birthday = DateTime.Parse(listBirhtday[i]),
                    Books = new List<BookModel>() //{ listBooks[i] }
                });
            }
            for (int i = 0; i < authors.Length; i++)
            {
                var genryRandom = random.NextDouble();
                List<GenryModel> genryList = genryRandom < 0.3
                                    ? new List<GenryModel>() { listGenry[0] }
                                    : genryRandom < 0.69
                                    ? new List<GenryModel>() { listGenry[1] }
                                    : new List<GenryModel>() { listGenry[2] };
                var newBook = new BookModel()
                {
                    Id = i + 1,
                    Genre = genryList,
                    Title = nameBook[i],
                    Master = new List<PeopleModel>() { listPerson[i] }
                };
                if(i < listPerson.Count)
                    listPerson[i].Books.Add(newBook);
                listBooks.Add(newBook);
                listAuthors.Add(new AuthorModel()
                {
                    Id = i + 1,
                    Name = authors[i].Split(" ")[0],
                    LastName = authors[i].Split(" ")[1],
                    MidleName = "",
                    Books = new List<BookModel>()
                    {
                        listBooks[i]
                    }
                });
            }

            //builder.Entity<GenryModel>().HasData(listGenry);
            //builder.Entity<PeopleModel>().HasData(listPerson);
            //builder.Entity<BookModel>().HasData(listBooks);
            //builder.Entity<AuthorModel>().HasData(listAuthors);

            base.OnModelCreating(builder);
        }
    }
}
