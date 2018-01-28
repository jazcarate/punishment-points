using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PunishmentPointsApp.Models;

namespace PunishmentPointsApp.Services
{
    public class StatusService
    {
        private List<Punishment> punishments;

        public StatusService(List<Punishment> punishments)
        {
            this.punishments = punishments;
        }

        public List<TeamMemberStatus> Exec()
        {
            return punishments.GroupBy(punishment => punishment.Recipient).ToList().ConvertAll(
                    new Converter<IGrouping<TeamMember, Punishment>, TeamMemberStatus>(ToTeamMemberStatus)
                );
        }

        private TeamMemberStatus ToTeamMemberStatus(IGrouping<TeamMember, Punishment> input)
        {
            return new TeamMemberStatus(input.Key.Name, input.ToList());
        }
    }
}