using System;
using Audit_Models;
namespace Audit_BusinessLogic
{
	public interface IAuditLogic
	{
		public Audit_Data Add(Audit_Data audit);

	}
}

