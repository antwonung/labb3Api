using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace labb3Api.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity obj);
        void Update(TEntity obj);
        IQueryable<TEntity> Query {get;}
        void Save();

    }
   
}
