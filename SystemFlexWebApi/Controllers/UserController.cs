using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SystemFlexModel.Models;
using SystemFlexModel.Service;
using System.Web.Http.Cors;
using SystemFlexModel.Interfaces;
using SystemFlexWebApi.Models;
using SystemFlexWebApi.Tools;

namespace SystemFlexWebApi.Controllers
{
   [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        IUserService UserService = new UserService();
        [HttpGet]
        public IHttpActionResult UserGetAll()
        {
            try
           {
                var UserList = UserService.UserGetAll();
                if(UserList.Count() < 1)
                {
                    return NotFound();
                }
                return Ok(UserList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
            
        }
        [Route("api/User/GetUserById/{Id}")]
        [HttpGet] 
       public IHttpActionResult GetUserById(int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest();
                }
                var User = UserService.GetUserById(Id);
                return Ok(User);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return InternalServerError();
            }
           

        }
        [HttpPost]
        public IHttpActionResult Post(UserModel User)
        {
            try
            {
                if (User == null)
                {
                    return BadRequest();
                }

                var NewUser = UserService.CreateUser(AutoMapper.Mapper.Map<UserModel,
                  SystemFlexModel.ViewModels.UserModel>(User));

                if (NewUser == null)
                {

                    return new HandleHttpError(HttpStatusCode.Conflict, "Ya existe un Usuario con ese nombre");
                }

                return Ok(NewUser);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }
     [HttpPut]
   public IHttpActionResult EditUser(UserModel User)
        {
            try
            {
                if (User == null)
                {
                    return BadRequest();
                }
                var RegUser = UserService.EditUser(AutoMapper.Mapper.Map<UserModel,
                    SystemFlexModel.ViewModels.UserModel>(User));
                return Ok(RegUser);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
           
        }
        [Route("api/User/DisableUser")]
        [HttpPost]
        public IHttpActionResult DisableUser(UserModel User)
        {
            try
            {
               if(User.Id <= 0)
                {
                    return BadRequest();
                }
                 UserService.DisableUser(User.Id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
           
        }

    }
}
