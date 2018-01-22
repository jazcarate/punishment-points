using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PunishmentPointsApp.Models
{
	 public class Punishment
    {
        public Punishment()
        {
            Recipients = new List<TeamMember>();
            CreatedAt = DateTime.Now;
            Id = new Random().Next();
        }
        [Key]
        public virtual int Id { get; protected set; }
        public virtual TeamMember Author { get; set; }
        public virtual IList<TeamMember> Recipients { get; set; }
        public virtual string Reason { get; set; }
        [Column(TypeName = "date")]
        public virtual DateTime CreatedAt { get; set; }
    }
}