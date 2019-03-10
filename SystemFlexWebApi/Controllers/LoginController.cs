using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SystemFlexModel.Interfaces;
using SystemFlexModel.Service;
using SystemFlexModel.ViewModels;

namespace SystemFlexWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        ILoginService LoginService = new LoginService();
        [Route("api/Login/Account")]
        [HttpPost]
        public IHttpActionResult Account(LoginModel ParamAccount)
        {
            try
            {
                if(ParamAccount == null)
                {
                    return BadRequest();
                }
                var Login = LoginService.Login(AutoMapper.Mapper.Map<LoginModel,
              SystemFlexModel.ViewModels.LoginModel>(ParamAccount));
                if (Login == null)
                {
                    return NotFound();
                }
                return Ok(Login);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }
    }
}
