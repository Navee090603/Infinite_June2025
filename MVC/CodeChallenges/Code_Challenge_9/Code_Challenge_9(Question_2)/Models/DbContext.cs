using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Code_Challenge_9_Question_2_.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("name=connectstr") { }
        public DbSet<Movie> Movies { get; set; }
    }
}