using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PunishmentPointsApp.Models
{
	 public class IncomingMessage
    {
        public IncomingMessage()
        {
            this.Entities = new List<Entity>();
        }
        [Key]
        public virtual string Id { get; set; }
        public virtual string Type { get; set; }
        public virtual string ServiceUrl { get; set; }
        public virtual string ChannelId { get; set; }
        public virtual TeamMember From { get; set; }
        public virtual string Text { get; set; }
        public virtual List<Entity> Entities { get; set; }
        [Column(TypeName = "date")]
        public virtual DateTime LocalTimestamp { get; set; }
    }
}