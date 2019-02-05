using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class Payments
    {
        public int Id { get; set; }
        public int? AppointmentId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public byte IsReceived { get; set; }

        public Appointments Appointment { get; set; }
    }
}
