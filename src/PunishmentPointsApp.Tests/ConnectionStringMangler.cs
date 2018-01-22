using NUnit.Framework;
using PunishmentPointsApp.Configurations;

namespace Tests
{
    public class ConnectionStringMangler
    {
        [Test]
        public void givvenADataBaseURLItTransformsItToTheCorrectFormat()
        {
            string connectionString = DatabaseMangler.mangle("postgres://myUsername:myPassword@host:port/myDataBase");
            
            Assert.That(connectionString, Is.EqualTo("Server=host;Port=port;Database=myDataBase;User Id=myUsername;Password=myPassword;"));
        }
    }
}