using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CookBookAPI.Models
{
    public class CookBookAPIContext : DbContext
    {
        public CookBookAPIContext (DbContextOptions<CookBookAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CookBookAPI.Models.Recipe> Recipes { get; set; }
    }
}
