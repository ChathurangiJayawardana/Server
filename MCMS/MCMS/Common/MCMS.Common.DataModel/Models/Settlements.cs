using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class Settlements
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset PayedAt { get; set; }

        public Clinics Clinic { get; set; }
        public Doctors Doctor { get; set; }
    }
}
