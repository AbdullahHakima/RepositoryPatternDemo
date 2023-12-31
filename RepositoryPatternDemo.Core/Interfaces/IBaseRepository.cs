﻿using RepositoryPatternDemo.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternDemo.Core.Interfaces
{
    public interface IBaseRepository<T> where T:class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        T Find(Expression<Func<T, bool>> expression, string[] includes=null);
        IEnumerable<T> FindAll(Expression<Func<T,bool>> expression, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, string[] includes = null,
            Expression<Func<T, object>> orderBy=null, string orderByDirection = OrderBy.Ascending);

        T Add(T entity);
        
        IEnumerable<T> AddRange(IEnumerable<T> entities);


    }
}
