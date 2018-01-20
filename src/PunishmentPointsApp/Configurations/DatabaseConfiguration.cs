using System;
using Microsoft.Extensions.Configuration;

namespace PunishmentPointsApp.Repositories
{
    public static class DatabaseConfiguration
    {
        internal static IDatabaseEnvironment choose(IConfiguration Configuration)
        {
            if ("File".Equals(Configuration.GetSection("Database")["Type"]))
                return new FileDatabaseEnvironment(Configuration);
            return new PostgressDatabaseEnvironment(Configuration);
        }
    }
}