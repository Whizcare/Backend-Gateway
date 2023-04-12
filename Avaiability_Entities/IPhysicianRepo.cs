using TE = DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public interface IPhysicianRepo
    {
        public TE.PhysicianAvailabilityStatus AddAvailability(TE.PhysicianAvailabilityStatus phy_status);
        public TE.PhysicianAvailabilityStatus UpdateAvailability(TE.PhysicianAvailabilityStatus phy_status);
        public TE.PhysicianAvailabilityStatus GetStatus(Guid id);
    }
}
