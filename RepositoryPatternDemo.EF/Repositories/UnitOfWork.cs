using RepositoryPatternDemo.Core.Interfaces;
using RepositoryPatternDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternDemo.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Movie> Movies { get; private set; }
        public IBaseRepository<Genre> Genres { get; private set; }
         public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Movies =new BaseRepository<Movie>(_context);
            Genres = new BaseRepository<Genre>(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
