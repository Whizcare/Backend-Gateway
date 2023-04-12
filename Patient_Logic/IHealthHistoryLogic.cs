using System;
using Models;
namespace Patient_Logic
{
	public interface IHealthHistoryLogic
	{
		HealthHistory AddHealthHistory(HealthHistory healthHistory);
		IEnumerable<HealthHistory> GetHealthHistory(Guid patientId);
		
	}
}

