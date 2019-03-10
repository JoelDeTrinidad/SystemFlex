using System;
using System.Collections.Generic;
using System.Linq;
using SystemFlexModel.Tools;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.ViewModels;
using SystemFlexModel.Models;
using System.Data.Entity;
using AutoMapper;
using SystemFlexModel.Interfaces;

namespace SystemFlexModel.Service
{
   public class UserService : IUserService
    {
        SHTContext db = new SHTContext();

        public List<UserModel> UserGetAll()
        {
            try
            {
                var UserList = db.Usuarios.ToList();
                return Mapper.Map<List<Usuarios>, List<UserModel>>(UserList); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public UserModel CreateUser(UserModel User)
        {
            try
            {
                var UserCreated = db.Usuarios.FirstOrDefault(a => a.Usuario.Contains(User.User));

                if (UserCreated != null)
                {
                    return null;
                }
                var passwSha1 = Encryption.SHA1HashStringForUTF8String(User.Password);
                var NewUser = new Usuarios()
                {
                    Nombres = User.Name,
                    Apellidos = User.LastName,
                    Usuario = User.User,
                    Clave = passwSha1,
                    Correo = User.Email,
                    Activo = User.IsActive,
                    FechaCreacion = DateTime.Now,
                    Observaciones = User.comments,
                    
                };
                db.Usuarios.Add(NewUser);
                db.SaveChanges();
                var Id = NewUser.UsuarioId;
                NewUser = db.Usuarios.FirstOrDefault(a => a.UsuarioId == NewUser.UsuarioId);
                return Mapper.Map<Usuarios, UserModel>(NewUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

     public UserModel EditUser(UserModel User)
        {
            try
            {
                Usuarios RegUser = null;
                {
                    RegUser = db.Usuarios.Where(a => a.UsuarioId == User.Id).SingleOrDefault();
                    if(RegUser.Clave != User.Password)
                    {
                        var passwSha1 = Encryption.SHA1HashStringForUTF8String(User.Password);
                        RegUser.Nombres = User.Name;
                        RegUser.Apellidos = User.LastName;
                        RegUser.Usuario = User.User;
                        RegUser.Clave = passwSha1;
                        RegUser.Correo = User.Email;
                        RegUser.Activo = User.IsActive;
                        RegUser.Observaciones = User.comments;
                    }
                    else
                    {
                        RegUser.Nombres = User.Name;
                        RegUser.Apellidos = User.LastName;
                        RegUser.Usuario = User.User;
                        RegUser.Clave = User.Password;
                        RegUser.Correo = User.Email;
                        RegUser.Activo = User.IsActive;
                        RegUser.Observaciones = User.comments;
                    }
                }
                db.Usuarios.Attach(RegUser);
                db.Entry(RegUser).State = EntityState.Modified;
                db.SaveChanges();
                return Mapper.Map<Usuarios, UserModel>(RegUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DisableUser(int Id)
        {
            try
            {
                var RegisterDisableUser = db.Usuarios.SingleOrDefault(a=> a.UsuarioId == Id);
                RegisterDisableUser.Activo = false;
                db.Usuarios.Attach(RegisterDisableUser);
                db.Entry(RegisterDisableUser).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public UserModel GetUserById(int Id)
        {
            try
            {
                var User = db.Usuarios.FirstOrDefault(a => a.UsuarioId == Id);
                return Mapper.Map<Usuarios, UserModel>(User);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
           
        }
    }
}
