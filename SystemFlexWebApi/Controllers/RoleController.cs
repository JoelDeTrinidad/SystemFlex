using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SystemFlexModel.Models;
using SystemFlexModel.Service;
using SystemFlexModel.Interfaces;
using System.Web.Http.Cors;
using SystemFlexWebApi.Models;
using SystemFlexWebApi.Tools;

namespace SystemFlexWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RoleController : ApiController
    {
        IRoleService roleService = new RoleService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var roles = roleService.GetRoles();
                if (roles.Count() < 1)
                {
                    return NotFound();
                }
                return Ok(roles);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }


        [HttpPost]
        public IHttpActionResult Post(RoleModel Role)
        {
            try
            {
                if (Role == null)
                {
                    return BadRequest();
                }


                var NewRole = roleService.CreateRole(AutoMapper.Mapper.Map<RoleModel,
                    SystemFlexModel.ViewModels.RoleModel>(Role));

                if (NewRole == null)
                {
                    return new HandleHttpError(HttpStatusCode.Conflict, "El perfil ya existe");
                }
                return Ok(NewRole);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        [HttpPut]
        public IHttpActionResult Put(RoleModel Role)
        {
            try
            {
                if (Role == null)
                {
                    return BadRequest();
                }

                var RoleForEdit = roleService.EditRoles(AutoMapper.Mapper.Map<RoleModel,
                    SystemFlexModel.ViewModels.RoleModel>(Role));

                if (RoleForEdit == null)
                {
                    return new HandleHttpError(HttpStatusCode.Conflict, "El nombre de perfil ya existe");
                }
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteRole(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest();
                }
                roleService.DeleteRole(id);
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
