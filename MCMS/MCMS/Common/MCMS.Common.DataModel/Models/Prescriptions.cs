using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class Prescriptions
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        public string Notes { get; set; }
        public DateTime IssuedAt { get; set; }
        public byte IsPublic { get; set; }

        public Appointments Appointment { get; set; }
        public Inventories Inventory { get; set; }
    }
}
