using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsAPI.Models
{
    public class SportsDbContext : DbContext
    {
        public SportsDbContext() : base("name=SportsDbContext")
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}