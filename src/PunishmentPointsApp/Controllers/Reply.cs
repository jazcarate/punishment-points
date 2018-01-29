using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PunishmentPointsApp.Controllers
{
	 public class Reply
    {
        public Reply(string Text)
        {
            this.Text = Text;
            this.Type = "message";
        }
        public string Text { get; protected set; }
        public string Type { get; protected set; }
    }
}