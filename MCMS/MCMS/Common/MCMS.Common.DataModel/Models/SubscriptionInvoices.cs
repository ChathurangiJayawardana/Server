using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class SubscriptionInvoices
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime? PaidAt { get; set; }

        public Clinics Clinic { get; set; }
    }
}
