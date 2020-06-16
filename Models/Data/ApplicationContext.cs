using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobApplying.Models
{
    public class ApplicationContext:IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>contextOptions)
            :base(contextOptions)
        {
            
        }
        public DbSet<Applier> Appliers { set; get; }
    }
}