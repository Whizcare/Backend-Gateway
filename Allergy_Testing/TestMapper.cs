using BusinessLogic;
using Models;
using EF = DataEntities.Entities;

namespace Testing
{
    [TestFixture]
    public class TestMapper
    {
        [Test]
        public void TestMap()
        {
            Models.Allergy all = new Models.Allergy();
            var al=Mapper.AllergyMapper(all);

            Assert.That(typeof(EF.Allergy), Is.EqualTo(al.GetType()));
        }
        [Test]
        public void TestMap2()
        {
            EF.Allergy allle = new EF.Allergy();
            var ale=Mapper.AllergyMapper(allle);
            Assert.That(typeof(Models.Allergy), Is.EqualTo(ale.GetType()));
        }

        [Test]
        public void TestMap3()
        {
            List<EF.Allergy> allle = new List<EF.Allergy>();
            var ale = Mapper.AllergyMapper(allle);
            Assert.That(typeof(List<Models.Allergy>), Is.EqualTo(ale.GetType()));
        }
    }
}