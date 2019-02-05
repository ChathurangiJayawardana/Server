using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RoleCarryOuts = new HashSet<RoleCarryOuts>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<RoleCarryOuts> RoleCarryOuts { get; set; }
    }
}
