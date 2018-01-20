using NUnit.Framework;
using PunishmentPointsApp.Controllers;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ValuesController controler = new ValuesController();
            Assert.That(controler.Get(), Is.Not.Empty);
        }
    }
}