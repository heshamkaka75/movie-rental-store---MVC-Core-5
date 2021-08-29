using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internet.Models;
using Microsoft.EntityFrameworkCore;

namespace Internet.Repo
{
    public class MoviesReop : IMoviesRepo<Movies>
    {
        private readonly MoviesDbContext db;
        
        public MoviesReop(MoviesDbContext db)
        {
            this.db = db;
        }
        public void Add(Movies entity)
        {
            db.Movies.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();

        }

        public Movies Find(int id)
        {
            var movie = db.Movies.Include(a => a.Actor).Where(m => m.movie_id == id).FirstOrDefault();
            return movie;
        }

        public IList<Movies> List()
        {
            
            return db.Movies.Include(a => a.Actor).ToList();
        }

        public List<Movies> Search(string term)
        {
            var result = db.Movies.Where(a => a.movie_name.Contains(term) || a.Desc.Contains(term));
            return result.ToList();
        }

        
        public void Update(Movies entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
