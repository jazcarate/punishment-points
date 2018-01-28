using System;
using System.Collections.Generic;
using PunishmentPointsApp.Models;

namespace PunishmentPointsApp.Services
{
    public class TeamMemberStatus
    {
        public TeamMemberStatus(string Name, List<Punishment> Punishments)
        {
            this.Name = Name;
            this.Punishments = Punishments;
        }

        public string Name { get; set; }
        public List<Punishment> Punishments { get; set; }

        public int PunishmentCount()
        {
            return Punishments.Count;
        }
    }
}