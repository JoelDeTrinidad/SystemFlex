using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SystemFlexModel.Service;
using SystemFlexModel.Interfaces;
using System.Web.Http.Cors;
using SystemFlexWebApi.Models;
using SystemFlexWebApi.Tools;

namespace SystemFlexWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StayDetailController : ApiController
    {

        IStayDetailService StayDetailService = new StayDetailService();
        [HttpPost]
        public IHttpActionResult Post(StayDetailModel StayDetail)
        {
            try
            {
                if (StayDetail == null)
                {
                    return BadRequest();
                }


                var NewStayDetail = StayDetailService.CreateStayDetail(AutoMapper.Mapper.Map<StayDetailModel,
                    SystemFlexModel.ViewModels.StayDetailModel>(StayDetail));

                if (NewStayDetail == null)
                {
                    return new HandleHttpError(HttpStatusCode.Conflict, "Error, la solicitud contiene fechas que han sido reservadas. Elija un rango distinto");
                }
                return Ok(NewStayDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

    }
}
