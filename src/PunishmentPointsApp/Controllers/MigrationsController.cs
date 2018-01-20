using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PunishmentPointsApp.Models;
using PunishmentPointsApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace PunishmentPointsApp.Controllers
{
    [Route("api/[controller]")]
    public class MigrationsController : ControllerBase
    {
		
        public PunishmentContext db { get; set; }
        public MigrationsController(PunishmentContext context)
        {
            this.db = context;
        }

        // GET: api/migrations
        [HttpPost]
        public void Migrate()
        {
            db.Database.Migrate();
        }
    }
}