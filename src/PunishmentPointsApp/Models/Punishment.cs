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
            CreatedAt = DateTime.Now;
            Id = new Random().Next();
        }
        public Punishment(TeamMember Author, TeamMember Recipient, string Reason, IncomingMessage From) : this()
        {
            this.Author = Author;
            this.Recipient = Recipient;
            this.Reason = Reason;
        }
        [Key]
        public virtual int Id { get; protected set; }
        public virtual TeamMember Author { get; set; }
        public virtual TeamMember Recipient { get; set; }
        public virtual IncomingMessage From { get; set; }
        public virtual string Reason { get; set; }
        [Column(TypeName = "date")]
        public virtual DateTime CreatedAt { get; set; }
    }
}