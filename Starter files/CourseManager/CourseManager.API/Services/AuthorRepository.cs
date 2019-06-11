using CourseManager.API.DbContexts;
using CourseManager.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.API.Services
{
    public class AuthorRepository : IDisposable
    {
        private CourseContext _context;

        public AuthorRepository(CourseContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors() 
        { 
            return _context.Authors.ToList();
        }

        public IEnumerable<Author> GetAuthors(int pageNumber = 1, int pageSize = 5)
        {
            return _context.Authors.Skip((pageNumber-1) * pageSize).Take(pageSize).ToList();
        }

        public Author GetAuthor(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentException(nameof(authorId));
            }

            return _context.Authors.FirstOrDefault(a => a.Id == authorId);
        }

        public void AddAuthor(Author author)
        {
            try
            {            
                if (author.CountryId == null)
                {
                    author.CountryId = "BE";
                }

                _context.Authors.Add(author);
            }
            catch (Exception)
            {
                // potentially handle exception, log
                throw;
            }
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
