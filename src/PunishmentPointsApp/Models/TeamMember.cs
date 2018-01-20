using System.ComponentModel.DataAnnotations;

namespace PunishmentPointsApp.Models
{
	 public class TeamMember
    {
        [Key]
        public virtual string Id { get; protected set; }
        public virtual string Name { get; set; }
    }
}