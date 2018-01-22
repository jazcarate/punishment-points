using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PunishmentPointsApp.Configurations;

namespace PunishmentPointsApp.Repositories
{
    internal class PostgressDatabaseEnvironment : IDatabaseEnvironment
    {
        private IConfiguration configuration;

        public PostgressDatabaseEnvironment(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void use(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DatabaseMangler.mangle(configuration["DATABASE_URL"]));
        }
    }
}