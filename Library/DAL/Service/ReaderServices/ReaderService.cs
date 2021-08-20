using AutoMapper;
using Library.DAL.Data;
using Library.DAL.Entitys.Dto;
using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Service.ReaderServices
{
    public class ReaderService : GynericRepository<PeopleModel,PersonDto>, IReaderService
    {
        public ReaderService(LibraryDbContext context, IMapper mapper)
            : base(context, mapper)
        { 
        }

        public IEnumerable<ReaderDto> GetLibraryCard()
        {
            return mapper.Map<IEnumerable<PeopleModel>, IEnumerable<ReaderDto>>(context.Set<PeopleModel>()
                .Include(entity => entity.Books)
                .AsEnumerable());
        }

        public bool UpdateBook(PersonDto entity, Entitys.Dto.BookDto book)
        {
            try
            {
                GetEntity(entity).Books.Add(mapper.Map<Entitys.Dto.BookDto, BookModel>(book));
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public override bool Remove(PersonDto entity)
        {
            if (GetEntity(entity).Books.Any())
                return false;

            return base.Remove(entity);
        }

        public bool RemoveBook(PersonDto entity, Entitys.Dto.Default.BookDto book)
        {
            try
            {
                context.Set<PeopleModel>()
               .Include(entity => entity.Books)
               .AsEnumerable()
               .Where(people =>
               entity.Birthday == people.Birthday
               && people.LastName == entity.LastName
               && people.MidleName == entity.MidleName
               && people.Name == entity.Name).Select(per => per.Books.Remove(new BookModel() { Title = book.Title }));

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public override bool Remove(int id)
        {
            if (GetEntity(id).Books.Any())
                return false;

            return base.Remove(id);
        }

        public override bool RemoveRange(IEnumerable<PersonDto> entitys)
        {
            if (GetEntities(entitys)
                .Select(entity => entity.Books.Any())
                .Any())
                return false;

            return base.RemoveRange(entitys);
        }

        private PeopleModel GetEntity(PersonDto person)
        {
            return context.Set<PeopleModel>()
                .Include(entity => entity.Books)
                .AsEnumerable()
                .Where(entity =>
                entity.Birthday == person.Birthday
                && entity.LastName == person.LastName
                && entity.MidleName == person.MidleName
                && entity.Name == person.Name).FirstOrDefault();
        }
    }
}
