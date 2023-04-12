using System;
using Models;
namespace Patient_Logic
{
	public interface IPresciptionLogic
	{
		Prescriptions AddPrescriptions(Prescriptions prescriptions);
		IEnumerable<Prescriptions> GetPrescriptions(Guid prId);
		
	}
}

