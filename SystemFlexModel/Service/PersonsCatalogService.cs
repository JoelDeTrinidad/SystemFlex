using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.ViewModels;
using SystemFlexModel.Models;
using System.Data.Entity;
using AutoMapper;
using SystemFlexModel.Interfaces;

namespace SystemFlexModel.Service
{
    public class PersonsCatalogService : IPersonsCatalogService
    {
        SHTContext db = new SHTContext();

        //Get list from persons catalog
        public List<PersonsCatalogModel> GetCatalog()
        {

            try
            {
                var CatalogList = db.CatalogoPersonas.ToList();
                return Mapper.Map<List<CatalogoPersonas>, List<PersonsCatalogModel>>(CatalogList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

    }
}
