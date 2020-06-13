﻿using Microsoft.EntityFrameworkCore;

namespace JobApplying.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>contextOptions)
            :base(contextOptions)
        {
            
        }
        public DbSet<Applier> Appliers { set; get; }
        public DbSet<Experience> Experiences { set; get; }
        public DbSet<Position> Positions { set; get; } 
        public DbSet<PreviousWork> PreviousWorks { set; get; }
    }
}