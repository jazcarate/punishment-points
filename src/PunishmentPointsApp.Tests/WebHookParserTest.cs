using System.Collections.Generic;
using NUnit.Framework;
using PunishmentPointsApp.Configurations;
using PunishmentPointsApp.Models;
using PunishmentPointsApp.Services;

namespace Tests
{
    public class WebHookParserTest
    {
        [Test]
        public void givenAnEmptyIncomingMessageItCreatesNoPunishments()
        {
            IncomingMessage message = new IncomingMessage();
            List<Punishment> punishments = new WebHookParser(message).Exec();
            
            Assert.That(punishments, Is.Empty);
        }

        [Test]
        public void givenAnIncomingMessageWithAMentionItCreatesASinglePunishments()
        {
            IncomingMessage message = new IncomingMessage();
            TeamMember mentioned = new TeamMember("Foo");
            TeamMember author = new TeamMember("Bar");

            message.From = author;
            message.Entities.Add(new Entity("mention", mentioned, "<at>Foo</at>"));
            List<Punishment> punishments = new WebHookParser(message).Exec();
            
            Assert.That(punishments.Count, Is.EqualTo(1));
            Assert.That(punishments[0].Recipient, Is.EqualTo(mentioned));
            Assert.That(punishments[0].Author, Is.EqualTo(author));
        }

        [Test]
        public void itIgnoresNonMentionEntities()
        {
            IncomingMessage message = new IncomingMessage();
            message.Entities.Add(new Entity("biz", null, null));
            List<Punishment> punishments = new WebHookParser(message).Exec();
            
            Assert.That(punishments, Is.Empty);
        }

        [Test]
        public void givenAnIncomingMessageWithMultipleMentionsItCreatesAMultiplePunishmentsThatSteamFromTheSameMessage()
        {
            IncomingMessage message = new IncomingMessage();
            TeamMember mentioned1 = new TeamMember("Foo1");
            TeamMember mentioned2 = new TeamMember("Foo2");
            TeamMember author = new TeamMember("Bar");

            message.From = author;
            message.Entities.Add(new Entity("mention", mentioned1, "<at>Foo</at>"));
            message.Entities.Add(new Entity("mention", mentioned2, "<at>Foo</at>"));
            List<Punishment> punishments = new WebHookParser(message).Exec();
            
            Assert.That(punishments.Count, Is.EqualTo(2));
            Assert.That(punishments[0].Recipient, Is.EqualTo(mentioned1));
            Assert.That(punishments[0].Author, Is.EqualTo(author));
            
            Assert.That(punishments[1].Recipient, Is.EqualTo(mentioned2));
            Assert.That(punishments[1].Author, Is.EqualTo(author));
            
            Assert.That(punishments[0].From, Is.EqualTo(punishments[1].From));
        }
    }
}