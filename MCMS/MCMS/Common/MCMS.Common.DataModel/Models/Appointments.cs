using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class Appointments
    {
        public Appointments()
        {
            Payments = new HashSet<Payments>();
            Prescriptions = new HashSet<Prescriptions>();
        }

        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int SessionId { get; set; }
        public DateTime AppointedAt { get; set; }
        public byte IsPresent { get; set; }
        public int? CreatedBy { get; set; }
        public string Diagnosis { get; set; }

        public Clinics Clinic { get; set; }
        public Users CreatedByNavigation { get; set; }
        public Doctors Doctor { get; set; }
        public Patients Patient { get; set; }
        public Sessions Session { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public ICollection<Prescriptions> Prescriptions { get; set; }
    }
}
