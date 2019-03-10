using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemFlexModel.Models;

namespace SystemFlexWebApi.Models
{
    public class LoginModel : UserModel
    {
        List<Menu> Menus { get; set; }
    }
}