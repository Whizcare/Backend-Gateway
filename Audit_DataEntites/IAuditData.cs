using System;
using df=Audit_DataEntites.Entity;
namespace Audit_DataEntites
{
	public interface IAuditData
	{
		public df.AuditDatum Addauditdata(df.AuditDatum audit);
		
	}
}

