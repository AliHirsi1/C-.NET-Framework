using Microsoft.AspNet.Identity.EntityFramework;
using Safe.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safe.Data
{
    class SafeExploreDBContext : IdentityDbContext<User>
    {
        public SafeExploreDBContext()
        
            : base("SAFE")
        {

            
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Cadence> Cadence { get; set; }
        public DbSet<Capacity> Capacity { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Team_and_Trains> Teams_and_Trains { get; set; }
    }
}
