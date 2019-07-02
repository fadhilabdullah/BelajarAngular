using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BelajarAngular.Models
{
    public class CrudContext : DbContext
    {
        public DbSet<BelajarAngular.Models.Player> Players { get; set; }
    }
}