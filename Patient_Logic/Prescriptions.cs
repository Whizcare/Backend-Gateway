using System;
using DataEntities;
using Models;

namespace Patient_Logic
{
	public class PrescriptionsLogic : IPresciptionLogic
	{
        private readonly IPrescriptions pr;

		public PrescriptionsLogic(IPrescriptions _pr)
		{
            pr = _pr;
		}

        public Prescriptions AddPrescriptions(Prescriptions prescriptions) => Mapper.Map(pr.AddPrescription(Mapper.Map(prescriptions)));


        public IEnumerable<Prescriptions> GetPrescriptions(Guid prId)
        {
            return Mapper.Map(pr.GetPrescription(prId));
        }
       
    }
}

