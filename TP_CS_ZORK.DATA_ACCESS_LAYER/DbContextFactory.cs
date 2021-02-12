using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER
{
    class DbContextFactory : IDesignTimeDbContextFactory<ZorkDbContext>
    {
        public ZorkDbContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<ZorkDbContext>();
            dbContextBuilder.UseSqlServer("Server=localhost;Database=ZorkDb;Trusted_Connection=True;", opt => opt.MigrationsAssembly("EntityFrameworkDbFirst"));

            return new (dbContextBuilder.Options);
        }
    }
}
