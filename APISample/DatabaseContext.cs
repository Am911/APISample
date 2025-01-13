using APISample.Models;
using APISample.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APISample
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> con):base(con)
        {
                
        }
        public DbSet<TrialClass> SM_TrialClass_Mst { get; set; }
        public DbSet<UserDetails> SM_UserDetails_Mst { get; set; }
        public DbSet<HostDetails> SM_HostDetails_Mst { get; set; }
        public DbSet<VehicleType> SM_VehicleType_Mst { get; set; }

    }

}
