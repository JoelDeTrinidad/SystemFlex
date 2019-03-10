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
    public class PaymentCheckController : ApiController
    {
        IPaymentCheckService PaymentService = new PaymentCheckService();


        [HttpPost]
        public IHttpActionResult PostPayment(PaymentCheckModel PayData)
        {
            try
            {
                if (PayData == null)
                {
                    return BadRequest();
                }


                var NewPay = PaymentService.MakePayment(AutoMapper.Mapper.Map<PaymentCheckModel,
                    SystemFlexModel.ViewModels.PaymentCheckModel>(PayData));

                if (NewPay == null)
                {
                    return new HandleHttpError(HttpStatusCode.Conflict, "ERROR, El pago de esta solicitud ha sido facturado anteriormente");
                }
                return Ok(NewPay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
    }
}
