using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class Inventories
    {
        public Inventories()
        {
            Prescriptions = new HashSet<Prescriptions>();
        }

        public int Id { get; set; }
        public int? ClinicId { get; set; }
        public int? AddedBy { get; set; }
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string StorageTemperature { get; set; }
        public string Manufacturer { get; set; }
        public string Strength { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int BatchNo { get; set; }
        public int ReorderLevel { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public string Notes { get; set; }

        public Users AddedByNavigation { get; set; }
        public Clinics Clinic { get; set; }
        public ICollection<Prescriptions> Prescriptions { get; set; }
    }
}
