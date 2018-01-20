using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PunishmentPointsApp.Repositories
{
    internal interface IDatabaseEnvironment
    {
        void use(DbContextOptionsBuilder optionsBuilder);
    }
}