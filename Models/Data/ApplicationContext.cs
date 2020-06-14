using Microsoft.EntityFrameworkCore;

namespace JobApplying.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>contextOptions)
            :base(contextOptions)
        {
            
        }
        public DbSet<Applier> Appliers { set; get; }
    }
}