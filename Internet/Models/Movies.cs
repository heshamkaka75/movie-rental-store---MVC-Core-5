using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Internet.Models
{
    public class Movies
    {
        [Key]
        public int movie_id { get; set; }
        public string movie_name { get; set; }
        public string Desc { get; set; }
        public int rate { get; set; }
        public string ImgUrl { get; set; }
        public Actors Actor { get; set; }


    }
}
