using Microsoft.EntityFrameworkCore;
using PunishmentPointsApp.Models;
using Microsoft.Extensions.Configuration;
using JetBrains.Annotations;

namespace PunishmentPointsApp.Repositories
{
    public class PunishmentContext : DbContext
    {
        public PunishmentContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Punishment> Punishments { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }      
    }
    
}