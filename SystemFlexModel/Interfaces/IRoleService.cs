using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.ViewModels;

namespace SystemFlexModel.Interfaces
{
    public interface IRoleService
    {
        List<RoleModel> GetRoles();
        RoleModel CreateRole(RoleModel Role);
        string EditRoles(RoleModel Role);
        string ConfirmationRoleAssigned(int id);
        void DeleteRole(int id);
    }
}
