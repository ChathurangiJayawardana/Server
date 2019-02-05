using System;
using System.Collections.Generic;

namespace MCMS.Common.MCMS.Common.DataModel.Models
{
    public partial class UserRoleGroups
    {
        public int UserId { get; set; }
        public int RoleGroupId { get; set; }

        public RoleGroups RoleGroup { get; set; }
        public Users User { get; set; }
    }
}
