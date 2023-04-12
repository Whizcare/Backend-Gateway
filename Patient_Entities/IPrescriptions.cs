
using DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public interface IPrescriptions
    {
        Prescription AddPrescription(Prescription prescription);
        List<Prescription> GetPrescription(Guid hhid);
    }
}
