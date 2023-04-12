using M=Audit_Models;
using Df = Audit_DataEntites.Entity;
using Audit_BusinessLogic;
namespace Audit_Test;

[TestFixture]
public class Tests
{
    [Test]
    public void Audt_M()
    {
        M.Audit_Data audit = new M.Audit_Data();
        var ps = Mapper.AuditMapper(audit);
        Assert.That(typeof(Df.AuditDatum), Is.EqualTo(ps.GetType()));
    }

    [Test]
    public void Audit_DF()
    {
        Df.AuditDatum audit = new Df.AuditDatum();
        var PS = Mapper.AuditMapper(audit);
        Assert.That(typeof(M.Audit_Data), Is.EqualTo(PS.GetType()));
    }
    
}
