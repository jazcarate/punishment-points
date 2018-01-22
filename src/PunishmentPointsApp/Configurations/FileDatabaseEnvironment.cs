using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PunishmentPointsApp.Repositories
{
    internal class FileDatabaseEnvironment : IDatabaseEnvironment
    {
        private IConfiguration configuration;

        public FileDatabaseEnvironment(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void use(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(configuration.GetSection("Database")["ConnectionString"]);
        }
    }
}