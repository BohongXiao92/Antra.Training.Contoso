using Antra.Training.Contoso.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Antra.Training.Contoso.Data
{

    public interface IRepository<T> where T : class
    {

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T GetById(int id);

        T Get(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        IQueryable<T> GetQueryable();

        void SaveChanges();

        IEnumerable<T> AllInclude(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate,params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetPagedList(out int totalCount, int? page = null, int? pageSize = null, Expression<Func<T, bool>> filter = null, string[] includePaths = null, params SortExpression<T>[] sortExpressions);

        IEnumerable<U> GetBy<U>(Expression<Func<T, U>> columns, Expression<Func<T, bool>> where);

    }

}
