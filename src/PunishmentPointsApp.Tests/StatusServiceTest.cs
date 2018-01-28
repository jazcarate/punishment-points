using System.Collections.Generic;
using NUnit.Framework;
using PunishmentPointsApp.Configurations;
using PunishmentPointsApp.Models;
using PunishmentPointsApp.Services;

namespace Tests
{
    public class StatusServiceTest
    {
        [Test]
        public void itReturnsAnEmptyStateIfThereAreNoPunishments()
        {
            List<Punishment> punishments = new List<Punishment>();
            List<TeamMemberStatus> status = new StatusService(punishments).Exec();
            
            Assert.That(status, Is.Empty);
        }

        [Test]
        public void whenThersOnlyOnePunishmentitReturnsASingleMemberWithThisPunishment()
        {
            List<Punishment> punishments = new List<Punishment>();
            TeamMember recipient = new TeamMember("Pepe");
            TeamMember author = new TeamMember("Jose");
            punishments.Add(new Punishment(author, recipient, "por gil", null));
            
            List<TeamMemberStatus> status = new StatusService(punishments).Exec();
            
            Assert.That(status.Count, Is.EqualTo(1));
            Assert.That(status[0].Name, Is.EqualTo("Pepe"));
            Assert.That(status[0].PunishmentCount, Is.EqualTo(1));
            Assert.That(status[0].Punishments[0].Reason, Is.EqualTo("por gil"));
            Assert.That(status[0].Punishments[0].Author.Name, Is.EqualTo("Jose"));
        }

                [Test]
        public void whenThersMultiplePunishmentsForASinglePersonitReturnsASingleMemberWithAllOfHisPunishment()
        {
            List<Punishment> punishments = new List<Punishment>();
            TeamMember recipient = new TeamMember("Pepe");
            TeamMember author = new TeamMember("Jose");
            punishments.Add(new Punishment(author, recipient, "por gil", null));
            punishments.Add(new Punishment(author, recipient, "por gato", null));
            punishments.Add(new Punishment(author, recipient, "por nabo", null));

            List<TeamMemberStatus> status = new StatusService(punishments).Exec();
            
            Assert.That(status.Count, Is.EqualTo(1));
            Assert.That(status[0].Name, Is.EqualTo("Pepe"));
            Assert.That(status[0].PunishmentCount, Is.EqualTo(3));
            Assert.That(status[0].Punishments[0].Reason, Is.EqualTo("por gil"));
            Assert.That(status[0].Punishments[1].Reason, Is.EqualTo("por gato"));
            Assert.That(status[0].Punishments[2].Reason, Is.EqualTo("por nabo"));
        }
    }
}