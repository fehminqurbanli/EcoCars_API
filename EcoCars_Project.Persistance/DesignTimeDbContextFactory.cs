using EcoCars_Project.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EcoCarsDbContext>
    {
        public EcoCarsDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EcoCarsDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
