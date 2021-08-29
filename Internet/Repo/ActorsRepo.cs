using Internet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet.Repo
{
    public class ActorsRepo : IMoviesRepo<Actors>
    {

        MoviesDbContext db;
        public ActorsRepo(MoviesDbContext _mDB)
        {
            
            db = _mDB;
        }
        public void Add(Actors entity)
        {
            db.Actors.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var actor = Find(id);
            db.Actors.Remove(actor);
            db.SaveChanges();
        }

        public Actors Find(int id)
        {
            var actor = db.Actors.Where(a => a.actor_id == id).FirstOrDefault();
            return actor;
        }

        public IList<Actors> List()
        {
            return db.Actors.ToList();
        }

        public List<Actors> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(Actors entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
