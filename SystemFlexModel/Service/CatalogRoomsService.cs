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
    public class CatalogRoomsService : ICatalogRoomsService
    {
        SHTContext db = new SHTContext();


        //Get list from persons catalog
        public List<CatalogRoomsModel> GetCatalog()
        {

            try
            {
                var CatalogRoomList = db.CatalogoHabitaciones.ToList();
                return Mapper.Map<List<CatalogoHabitaciones>, List<CatalogRoomsModel>>(CatalogRoomList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

    }
}
