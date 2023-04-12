using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Prescriptions
    {
        public Guid PrescriptionId { get; set; }

        public Guid? HhId { get; set; }

        public string? MedicineName { get; set; }

        public string? Dosage { get; set; }

        public string? Note { get; set; }
    }
}
