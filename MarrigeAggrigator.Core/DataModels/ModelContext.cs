using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrigeAggrigator.Core
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("DbConnection")
        {

        }

        public DbSet<MatrimonyProfile> Profiles { get; set; }

        public DbSet<MatrimonyWebsite> MartrimonyWebSites { get; set; }
    }
}
