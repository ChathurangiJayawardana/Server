using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class RoleCarryOuts
    {
        public int RoleGroupId { get; set; }
        public int RoleId { get; set; }

        public Roles Role { get; set; }
        public RoleGroups RoleGroup { get; set; }
    }
}
