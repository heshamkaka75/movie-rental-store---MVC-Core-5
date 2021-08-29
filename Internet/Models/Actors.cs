using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Internet.Models
{
    public class Actors
    {
        [Key]
        public int actor_id { get; set; }
        public string actor_name { get; set; }
        public int age { get; set; }
    }
}
