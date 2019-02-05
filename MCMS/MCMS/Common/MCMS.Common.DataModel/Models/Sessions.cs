using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class Sessions
    {
        public Sessions()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public byte HasConducted { get; set; }
        public decimal? Fee { get; set; }

        public Clinics Clinic { get; set; }
        public Doctors Doctor { get; set; }
        public ICollection<Appointments> Appointments { get; set; }
    }
}
