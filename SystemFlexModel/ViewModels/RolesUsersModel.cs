using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemFlexModel.ViewModels
{
    public class RolesUsersModel
    {
        public int RolesUserId { get; set; }
        public UserModel User { get; set; }
        public RoleModel Role { get; set; }
    }
}
