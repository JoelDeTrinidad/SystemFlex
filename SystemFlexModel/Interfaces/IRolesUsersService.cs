using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.ViewModels;

namespace SystemFlexModel.Interfaces
{
   public interface IRolesUsersService
    {
        List<RolesUsersModel> GetAll();
        List<UserModel> GetActiveUser();
        List<RoleModel> GetActiveRole();
    }
}
