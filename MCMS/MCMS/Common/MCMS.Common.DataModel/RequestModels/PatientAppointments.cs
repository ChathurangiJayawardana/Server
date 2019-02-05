using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMS.Common.MCMS.Common.DataModel.RequestModels
{
    public class PatientAppointments
    {
        public int PatientId { get; set; }
        public int ClinicId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
