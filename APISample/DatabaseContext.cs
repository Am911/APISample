using APISample.Models;
using Microsoft.EntityFrameworkCore;

namespace APISample
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> con):base(con)
        {
                
        }
        public DbSet<TrialClass> SM_TrialClass_Mst { get; set; }
        public DbSet<UserDetails> SM_UserDetails_Mst { get; set; }
    }
}
