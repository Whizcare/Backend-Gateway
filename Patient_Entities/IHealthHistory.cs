using DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public interface IHealthHistory
    {
        HealthHistory AddHealthHistory(HealthHistory healthHistory);
        List<HealthHistory> GetHealthHistory(Guid patientId);
    }
}
