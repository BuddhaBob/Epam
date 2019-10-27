using LayersDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersDAL.EF
{
    public class SiteContext : DbContext
    {
        public SiteContext() : base("Connecxion")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }


    }
}
