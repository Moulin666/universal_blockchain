using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using universal_blockchain.Models;

namespace universal_blockchain.Context
{
    public class mysqlContext : DbContext
    {
        public mysqlContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server = whisperq.ru; userid = blockchain_univ; pwd = cedVJs7cDvBMny+gCxVtivfd; port = 3306; database = blockchain_univ; sslmode = none;");
        }

        public DbSet<Block> Block { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}
