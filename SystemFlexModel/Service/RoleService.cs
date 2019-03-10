using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.ViewModels;
using SystemFlexModel.Models;
using System.Data.Entity;
using AutoMapper;
using SystemFlexModel.Interfaces;

namespace SystemFlexModel.Service
{
    public class RoleService : IRoleService
    {
        SHTContext db = new SHTContext();

        //get the list of roles existing
        public List<RoleModel> GetRoles()
        {
            try
            {
                var rolesList = db.Perfiles.ToList();
                return Mapper.Map<List<Perfiles>, List<RoleModel>>(rolesList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public RoleModel CreateRole(RoleModel Role)
        {

            try
            {
                var RoleCreated = db.Perfiles.FirstOrDefault(a => a.Nombre.Contains(Role.Name));

                if (RoleCreated != null)
                {
                    return null;
                }
                
                var NewRole = new Perfiles()
                {
                    Nombre = Role.Name,
                    Descripcion = Role.Description,
                };
                db.Perfiles.Add(NewRole);
                db.SaveChanges();
                var Id = NewRole.PerfilId;
                NewRole = db.Perfiles.FirstOrDefault(a => a.PerfilId == NewRole.PerfilId);
                return Mapper.Map<Perfiles, RoleModel>(NewRole);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


        public string EditRoles(RoleModel Role)
        {

            Perfiles RoleReged = null;
            Boolean ifExist = false;
            try
            {
                var RoleToEdit = db.Perfiles.FirstOrDefault(a => a.Nombre == Role.Name && a.PerfilId != Role.RoleId);

                if (RoleToEdit != null)
                {
                    ifExist = true;
                }
                else
                {
         
                    RoleReged = db.Perfiles.Where(p => p.PerfilId == Role.RoleId).SingleOrDefault();
                    RoleReged.Nombre = Role.Name;
                    RoleReged.Descripcion = Role.Description;

                    db.Perfiles.Attach(RoleReged);
                    db.Entry(RoleReged).State = EntityState.Modified;
                    db.SaveChanges();
  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            if (ifExist)
            {
                return null;
            }
            else
            {
                return "OK";
            }
        }


        public string ConfirmationRoleAssigned(int id)
        {
            Boolean ifExist = false;
            try
            {
                var verificationRole = db.PerfilUsuario.FirstOrDefault(r => r.PerfilId == id);

                if (verificationRole != null)
                {
                    ifExist = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            if (ifExist)
            {
                return null;
            }
            else
            {
                return "Ok";
            }

        }
        public void DeleteRole(int id)
        {
            try
            {
                var DeleteRoles = db.Perfiles.SingleOrDefault(a => a.PerfilId == id);
                db.Perfiles.Remove(DeleteRoles);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

    }
}
