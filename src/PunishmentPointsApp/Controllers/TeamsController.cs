using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PunishmentPointsApp.Models;
using PunishmentPointsApp.Repositories;
using PunishmentPointsApp.Services;

namespace PunishmentPointsApp.Controllers
{
    [Route("api/[controller]")]
    public class PunishmentController : ControllerBase
    {
		
        public PunishmentContext db { get; set; }
        public PunishmentController(PunishmentContext context)
        {
            this.db = context;
        }

        // GET: api/punishment
        [HttpGet]
        public IList<Punishment> Get()
        {
            return db.Punishments
                .Include(punishment => punishment.Author)
                .Include(punishment => punishment.Recipient)
                .ToList();
        }

        // GET api/punishment/5
        [HttpPost]
        public Reply Insert([FromBody] IncomingMessage message)
        {
            db.IncomingMessages.Add(message);
            new WebHookParser(message).Exec()
                .ForEach(punishment =>
                    db.Punishments.Add(punishment)
                );
            var count = db.SaveChanges();
            Console.WriteLine("{0} records saved to database", count);
            return new Reply("Saved!");
        }
    }
}