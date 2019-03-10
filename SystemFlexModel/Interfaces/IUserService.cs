using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.ViewModels;

namespace SystemFlexModel.Interfaces
{
   public interface IUserService
    {
        List<UserModel> UserGetAll();
        UserModel GetUserById(int Id);
        UserModel CreateUser(UserModel User);
        UserModel EditUser(UserModel User);
        void DisableUser(int Id);


    }
}
