using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.Interfaces;
using SystemFlexModel.Models;
using SystemFlexModel.Tools;
using SystemFlexModel.ViewModels;

namespace SystemFlexModel.Service
{
    public class LoginService : ILoginService
    {
        SHTContext db = new SHTContext();
        public LoginModel Login(LoginModel ParamAccount)
        {
            try
            {
                var passwSha1 = Encryption.SHA1HashStringForUTF8String(ParamAccount.Password);

                var User = db.Usuarios.FirstOrDefault(a => a.Usuario == ParamAccount.User && a.Clave == passwSha1 &&
                    a.Activo == true);

                if (User == null)
                {
                    return null;
                }

                var Roles = db.PerfilUsuario.Where(RoleUser => RoleUser.UsuarioId == User.UsuarioId).ToList();

                List<OpcioneMenu> OptionMenu = new List<OpcioneMenu>();
                foreach (var rol in Roles)
                {
                    var Options = db.OpcioneMenu.Where(menu => menu.PerfilesOpcionMenu.Count(roleMenu =>
                    roleMenu.PerfilId == rol.PerfilId) > 0 && menu.Activo == true || menu.Visible == false).ToList();
                    OptionMenu.AddRange(Options);
                }

                User.UltimoAcceso = DateTime.Now;

                db.Usuarios.Attach(User);
                db.Entry(User).State = EntityState.Modified;
                db.SaveChanges();

                var Account = AutoMapper.Mapper.Map<Usuarios, LoginModel>(User);
                //var Menus = AutoMapper.Mapper.Map<List<OpcioneMenu>, List<MenuModel>>(OptionMenu);
                //Account.Menus = Menus;

                return Account;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                throw;
            }
        }
    }
}
