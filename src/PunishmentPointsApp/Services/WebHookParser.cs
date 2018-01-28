using Microsoft.EntityFrameworkCore;
using PunishmentPointsApp.Models;
using Microsoft.Extensions.Configuration;
using JetBrains.Annotations;
using System.Collections.Generic;
using System;

namespace PunishmentPointsApp.Services
{
    public class WebHookParser
    {
        private readonly IncomingMessage message;

        public WebHookParser(IncomingMessage message)
        {
            this.message = message;
        }

        public List<Punishment> Exec(){
            return message.Entities.ConvertAll(
                new Converter<Entity, Punishment>(ToPunishment)
            );
        }

        public Punishment ToPunishment (Entity e){
            return new Punishment(message.From, e.Mentioned, message.Text, message);
        }
    }
    
}