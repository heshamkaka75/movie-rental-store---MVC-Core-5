using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Internet.Models
{
    public class MoviesViewModel
    {

        
        public int movie_id { get; set; }
        public string movie_name { get; set; }
        public string Desc { get; set; }
        public int rate { get; set; }
        public string ImgUrl { get; set; }
        public int actor_id { get; set; }
        public List<Actors> Actor { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
