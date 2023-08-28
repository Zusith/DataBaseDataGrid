using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBaseCheck.Models
{
    //Класс для создания контекста подключения к таблице бд Clients
    class ClientContext : DbContext
    {
        public ClientContext(string dbNameOrConnection)
        : base(dbNameOrConnection)
        { }

        public ClientContext()
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
