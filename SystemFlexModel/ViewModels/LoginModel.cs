using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.Models;

namespace SystemFlexModel.ViewModels
{
   public class LoginModel : UserModel
    {
        List<Menu> Menus { get; set; }
    }
}
