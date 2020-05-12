using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models
{
    public class BabyContext:DbContext
    {
        public BabyContext(DbContextOptions<BabyContext> options)
            : base(options)
        {
        }
        public DbSet<Baby> Babies { get; set; }
    }
}
