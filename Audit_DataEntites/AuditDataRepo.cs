using Audit_DataEntites.Entity;

namespace Audit_DataEntites;
public class AuditDataRepo : IAuditData
{
    private readonly AuditDbContext context;
    public AuditDataRepo(AuditDbContext _context)
    {
        context = _context;
    }
    public AuditDatum Addauditdata(AuditDatum audit)
    {
        context.AuditData.Add(audit);
        context.SaveChanges();
        return audit;
    }
}

