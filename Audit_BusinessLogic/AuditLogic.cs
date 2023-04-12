using Audit_Models;
using df=Audit_DataEntites;
namespace Audit_BusinessLogic;

public class AuditLogic : IAuditLogic
{
    private readonly df.IAuditData repo;
    public AuditLogic(df.IAuditData _repo)
    {
        repo = _repo;
    }
    public Audit_Data Add(Audit_Data audit)
    {
        return Mapper.AuditMapper(repo.Addauditdata(Mapper.AuditMapper(audit)));
    }
}



