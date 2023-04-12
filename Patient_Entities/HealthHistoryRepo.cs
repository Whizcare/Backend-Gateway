using System;
using DataEntities.Entities;

namespace DataEntities
{
    public class HealthHistoryRepo : IHealthHistory
    {
        private readonly ProjectDatabaseContext context;
        public HealthHistoryRepo(ProjectDatabaseContext _context)
        {
            context = _context;
        }
        public HealthHistory AddHealthHistory(HealthHistory healthHistory)
        {
            context.HealthHistories.Add(healthHistory);
            context.SaveChanges();
            return healthHistory;
        }

        public List<HealthHistory> GetHealthHistory(Guid patientId)
        {
            var h=(from hh in context.HealthHistories
                   orderby hh.Date descending
                   where hh.PatientId == patientId
                   select hh ).ToList();
            return h;
        }
     
    }
}

