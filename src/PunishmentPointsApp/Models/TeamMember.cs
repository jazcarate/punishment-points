using System;
using System.ComponentModel.DataAnnotations;

namespace PunishmentPointsApp.Models
{
	 public class TeamMember
    {
        public TeamMember()
        {
        }
        public TeamMember(string Name) : this()
        {
            this.Name = Name;
        }
        [Key]
        public virtual string Id { get; protected set; }
        public virtual string Name { get; set; }
    }
}