using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HeroesTour2;

namespace HeroesTour2.Data
{
    public class HeroesTour2Context : DbContext
    {
        public HeroesTour2Context (DbContextOptions<HeroesTour2Context> options)
            : base(options)
        {
        }

        public DbSet<HeroesTour2.Hero> Hero { get; set; }
    }
}
