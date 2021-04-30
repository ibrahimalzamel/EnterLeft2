using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    
    public class EnterLeftDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=sql11.freemysqlhosting.net;
                                      Port=3306;
                                      Database=sql11400705;
                                      Uid=sql11400705;
                                      Pwd=zVsKNdY7tb;");
        } 
    
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
  