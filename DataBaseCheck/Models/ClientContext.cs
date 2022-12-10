using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBaseCheck.Models
{
    
    class ClientContext : DbContext
    {
        public ClientContext(string dbNameOrConnection)
        : base(dbNameOrConnection)
        { }

        public DbSet<Client> Clients { get; set; }
    }
}
