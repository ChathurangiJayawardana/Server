using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class Clinics
    {
        public Clinics()
        {
            Appointments = new HashSet<Appointments>();
            Inventories = new HashSet<Inventories>();
            Sessions = new HashSet<Sessions>();
            Settlements = new HashSet<Settlements>();
            SubscriptionInvoices = new HashSet<SubscriptionInvoices>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime SubscribedAt { get; set; }
        public string BillingCycle { get; set; }
        public byte IsActive { get; set; }

        public ICollection<Appointments> Appointments { get; set; }
        public ICollection<Inventories> Inventories { get; set; }
        public ICollection<Sessions> Sessions { get; set; }
        public ICollection<Settlements> Settlements { get; set; }
        public ICollection<SubscriptionInvoices> SubscriptionInvoices { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
