using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.Models;
using SystemFlexModel.Interfaces;
using SystemFlexModel.ViewModels;
using AutoMapper;

namespace SystemFlexModel.Service
{
   public class RolesUsersService : IRolesUsersService
    {
        SHTContext db = new SHTContext();
        public List<RolesUsersModel> GetAll()
        {
            try
            {
                var RolesUserList = db.PerfilUsuario.Where(a=> a.Usuarios.UsuarioId == a.Usuarios.UsuarioId
                && a.Perfiles.PerfilId == a.Perfiles.PerfilId).ToList();
                return Mapper.Map<List<PerfilUsuario>, List<RolesUsersModel>>(RolesUserList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<UserModel> GetActiveUser()
        {
            try
            {
               List<Usuarios> GetUser = db.Usuarios.ToList();
                return Mapper.Map<List<Usuarios>, List<UserModel>>(GetUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<RoleModel> GetActiveRole()
        {
            try
            {
                List<Perfiles> GetPerfil = db.Perfiles.ToList();
                return Mapper.Map<List<Perfiles>, List<RoleModel>>(GetPerfil);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
