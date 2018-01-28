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
    public class StatusController : ControllerBase
    {
		
        public PunishmentContext db { get; set; }
        public StatusController(PunishmentContext context)
        {
            this.db = context;
        }

        // GET: api/status
        [HttpGet]
        public List<TeamMemberStatus> Get()
        {
            return new StatusService(db.Punishments
                .Include(punishment => punishment.Author)
                .Include(punishment => punishment.Recipient)
                .ToList()).Exec();
        }
    }
}