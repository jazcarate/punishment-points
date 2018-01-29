using NUnit.Framework;
using PunishmentPointsApp.Configurations;

namespace Tests
{
    public class ConnectionStringManglerTest
    {
        [Test]
        public void givenADataBaseURLItTransformsItToTheCorrectFormat()
        {
            string connectionString = DatabaseMangler.mangle("postgres://myUsername:myPassword@host:port/myDataBase");
            
            Assert.That(connectionString, Is.EqualTo("Server=host;Port=port;Database=myDataBase;User Id=myUsername;Password=myPassword;"));
        }
    }
}