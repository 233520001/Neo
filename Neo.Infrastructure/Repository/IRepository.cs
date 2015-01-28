using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Neo.Infrastructure.Repository
{
    public interface IRepository
    {
        int Insert<TEntity>(TEntity obj);
        void InsertBatch<TEntity>(ICollection<TEntity> obj);

        void Update<TEntity>(TEntity obj);
        IRepository Set<TEntity, TSelector>(Expression<Func<TEntity, TSelector>> expr, TSelector value);
        IRepository Set<TEntity, TSelector>(Expression<Func<TEntity, TSelector>> expr, Expression<Func<TEntity, TSelector>> value);
        void Update<TEntity>();

        void Delete<TEntity>(TEntity obj);
        void Delete<TEntity>(long id);
        void Delete<TEntity>(Expression<Func<TEntity, bool>> expr);

        TEntity Get<TEntity>(long id);
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> expr);
        ICollection<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> expr);
        PageResult<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> expr, PageParameter pageParameter);
    }

    public class PageParameter
    {

    }

    public class PageResult<TEntity>
    {
        public PageParameter PageParameter { get; set; }
        public int PageCount { get; set; }
        public ICollection<TEntity> Entities { get; set; }
    }
}