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
    public class CatalogRoomsController : ApiController
    {
        ICatalogRoomsService CatalogRoomService = new CatalogRoomsService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var Catalog = CatalogRoomService.GetCatalog();
                if (Catalog.Count() < 1)
                {
                    return NotFound();
                }
                return Ok(Catalog);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }
        }
    }
}
