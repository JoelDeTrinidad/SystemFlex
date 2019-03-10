using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SystemFlexModel.Interfaces;
using SystemFlexModel.Service;

namespace SystemFlexWebApi.Controllers
{
    [EnableCors(origins:"*", headers: "*", methods:"*")]
    public class RolesUsersController : ApiController
    {
        IRolesUsersService RolesUsersService = new RolesUsersService();
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var RolesUserList = RolesUsersService.GetAll();
                if(RolesUserList.Count() < 1)
                {
                    return NotFound();
                }
                return Ok(RolesUserList);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }
    }
}
