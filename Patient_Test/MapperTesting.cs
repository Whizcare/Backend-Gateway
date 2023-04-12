using EF = DataEntities.Entities;
using Models;
using Patient_Logic;
namespace Test
{
    [TestFixture]
    public class MapperTesting
    {
        [Test]
        public void TestPatient()
        {
            Models.Patient pat = new Models.Patient();
            var ps=Mapper.Map(pat);
            Assert.That(typeof(EF.Patient),Is.EqualTo(ps.GetType()));

        }
        [Test]
        public void TestPatient1()
        {
            EF.Patient pat = new EF.Patient();
            var ps=Mapper.Map(pat);
            Assert.That(typeof(Models.Patient),Is.EqualTo(ps.GetType()));
        }

        [Test]
        public void TestPatientList()
        {
            List<EF.Patient> allle = new List<EF.Patient>();
            var ale = Mapper.Map(allle);
            Assert.That(typeof(List<Models.Patient>), Is.EqualTo(ale.GetType()));
        }
        [Test]
        public void TestHealthHistory()
        {
            Models.HealthHistory pat = new Models.HealthHistory();
            var ps=Mapper.Map(pat);
            Assert.That(typeof(EF.HealthHistory),Is.EqualTo(ps.GetType()));
        }
        [Test]
        public void TestHealthHistory2()
        {
            EF.HealthHistory pat = new EF.HealthHistory();
            var ps=Mapper.Map(pat);
            Assert.That(typeof(Models.HealthHistory),Is.EqualTo(ps.GetType()));
        }
        [Test]
        public void TestHHList()
        {
            List<EF.HealthHistory> allle = new List<EF.HealthHistory>();
            var ht = Mapper.Map(allle);
            Assert.That(typeof(List<Models.HealthHistory>), Is.EqualTo(ht.GetType()));
        }
        [Test]
        public void PrescriptionTest()
        {
            Models.Prescriptions prescr= new Models.Prescriptions();
            var ps=Mapper.Map(prescr);
            Assert.That(typeof(EF.Prescription),Is.EqualTo(ps.GetType()));  
        }
        [Test]
        public void TestPrescription()
        {
            EF.Prescription prescription = new EF.Prescription();
            var ps=Mapper.Map(prescription);
            Assert.That(typeof(Models.Prescriptions),Is.EqualTo(ps.GetType()));
        }
        [Test]
        public void TestPrescriptionList()
        {
            List<EF.Prescription> prelist = new List<EF.Prescription>();
            var pre = Mapper.Map(prelist);
            Assert.That(typeof(List<Models.Prescriptions>), Is.EqualTo(pre.GetType()));
        }

    }
}