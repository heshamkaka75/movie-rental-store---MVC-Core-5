using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet.Repo
{
    public interface IMoviesRepo<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        List<TEntity> Search(string term);

    }
}
