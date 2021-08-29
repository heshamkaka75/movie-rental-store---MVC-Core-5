using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internet.Models;

namespace Internet.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options):base(options)
        {

        }

        public DbSet<Actors> Actors  { get; set; }
        public DbSet<Movies> Movies { get; set; }
        
        

    }
}
