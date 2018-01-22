using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PunishmentPointsApp.Models;
using PunishmentPointsApp.Repositories;

namespace PunishmentPointsApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
		
        public PunishmentContext db { get; set; }
        public ValuesController(PunishmentContext context)
        {
            this.db = context;
        }

        // GET: api/values
        [HttpGet]
        public IList<Punishment> Get()
        {
            return db.Punishments.ToList();
        }

        // GET api/values/5
        [HttpPost]
        public Punishment Insert([FromBody] Punishment punishment)
        {
            db.Punishments.Add(punishment);
            var count = db.SaveChanges();
            Console.WriteLine("{0} records saved to database", count);
            return punishment;
        }
    }
}