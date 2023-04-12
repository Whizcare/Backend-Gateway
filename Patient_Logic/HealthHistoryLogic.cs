using System;
using Models;
using DataEntities;

namespace Patient_Logic
{
	public class HealthHistoryLogic : IHealthHistoryLogic
	{
        private readonly IHealthHistory h;
		public HealthHistoryLogic(IHealthHistory _h)
		{
            h = _h;
		}

        public HealthHistory AddHealthHistory(HealthHistory healthHistory) => Mapper.Map(h.AddHealthHistory(Mapper.Map(healthHistory)));
      
        

        public IEnumerable<HealthHistory> GetHealthHistory(Guid patientId)
        {
            return Mapper.Map(h.GetHealthHistory(patientId));
        }
       
    }
}

