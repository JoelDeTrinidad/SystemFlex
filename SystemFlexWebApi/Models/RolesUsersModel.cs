using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemFlexWebApi.Models
{
    public class RolesUsersModel
    {
        public int RolesUserId { get; set; }
        public UserModel User { get; set; }
        public RoleModel Role { get; set; }
    }
}