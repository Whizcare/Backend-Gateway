using BusinessLogic;

namespace Testing
{
    [TestFixture]
    public class MapperTesting
    {
        [Test]
        public void Test1()
        {
            DataEntities.Entities.Doctor doc = new DataEntities.Entities.Doctor();
            var actual = Mapper.MapDoctor(doc);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.Doctor)));
        }
        [Test]
        public void Test2()
        {
            Models.Doctor doc = new Models.Doctor();
            var actual = Mapper.mapDoctor(doc);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(DataEntities.Entities.Doctor)));
        }
        [Test]
        public void Test3()
        {
            DataEntities.Entities.PhysicianAvailabilityStatus phyStatus = new DataEntities.Entities.PhysicianAvailabilityStatus();
            var actual = Mapper.MapPhysicianAvailabilityStatus(phyStatus);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.PhysicianAvailabilityStatus)));
        }
        [Test]
        public void Test4()
        {
            Models.PhysicianAvailabilityStatus phyStatus = new Models.PhysicianAvailabilityStatus();
            var actual = Mapper.mapPhysicianAvailabilityStatus(phyStatus);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(DataEntities.Entities.PhysicianAvailabilityStatus)));
        }
        [Test]
        public void TestDoctorList()
        {
            List<DataEntities.Entities.Doctor> doc = new List<DataEntities.Entities.Doctor>();
            var dc = Mapper.MapDoctor(doc);
            Assert.That(typeof(List<Models.Doctor>), Is.EqualTo(dc.GetType()));
        }
    }
}
