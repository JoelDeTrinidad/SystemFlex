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
    public class VWStayDetailController : ApiController
    {
        IVWStayDetailService viewDetailService = new VWStayDetailService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var vwList = viewDetailService.Getview();
                if (vwList.Count() < 1)
                {
                    return NotFound();
                }
                return Ok(vwList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteStayDetail(int Id)
        {
            try
            {
                if(Id < 1)
                {
                    return BadRequest();
                }
                 viewDetailService.DeleteStayDetail(Id);
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
