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
    public class PersonsCatalogController : ApiController
    {
        IPersonsCatalogService personsService = new PersonsCatalogService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var catalog = personsService.GetCatalog();
                if (catalog.Count() < 1)
                {
                    return NotFound();
                }
                return Ok(catalog);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
            }

        }

    }
}
