using Microsoft.EntityFrameworkCore;
using PunishmentPointsApp.Models;
using Microsoft.Extensions.Configuration;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Design;

namespace PunishmentPointsApp.Repositories
{
    public class PunishmentContextFactory : IDesignTimeDbContextFactory<PunishmentContext>
    {
        public PunishmentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PunishmentContext>();
            optionsBuilder.UseSqlite("Data Source=db\\punishing.db");

            return new PunishmentContext(optionsBuilder.Options);
        }
    }
    
}