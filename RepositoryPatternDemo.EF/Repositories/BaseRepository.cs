using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Core.Consts;
using RepositoryPatternDemo.Core.Interfaces;
using System.Linq.Expressions;

namespace RepositoryPatternDemo.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }


        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

        public T Find(Expression<Func<T, bool>> expression, string[] includes=null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach(var include in includes)
                    query= query.Include(include);

            return query.SingleOrDefault(expression);
        }

        public IEnumerable<T> FindAll(Expression<Func<T,bool>> expression, string[] includes = null)
        {
            IQueryable<T> query= _context.Set<T>();
            if(includes != null)
                foreach(var include in includes)
                    query= query.Include(include);

            return query.Where(expression).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, string[] includes = null,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
           IQueryable<T> query=_context.Set<T>().Where(expression);

            if(includes!=null)
                foreach(var include in includes)
                    query= query.Include(include);
            if (orderBy != null)
                if (orderByDirection == OrderBy.Ascending)
                { 
                    query = query.OrderBy(orderBy); 
                }
                else
                    query=query.OrderByDescending(orderBy);
            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            
            return _context.Set<T>().Find(id);
        }
    }
}
