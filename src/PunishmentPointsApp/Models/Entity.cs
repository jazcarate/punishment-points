using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PunishmentPointsApp.Models
{
	 public class Entity
    {
        public Entity()
        {
            Id = new Random().Next();
        }
        public Entity(string Type, TeamMember Mentioned, string Text) : this()
        {
            this.Text = Text;
            this.Type = Type;
            this.Mentioned = Mentioned;
        }
        [Key]
        public virtual int Id { get; set; }
        public virtual TeamMember Mentioned { get; set; }
        public virtual string Text { get; set; }
        public virtual string Type { get; set; }
    }
}