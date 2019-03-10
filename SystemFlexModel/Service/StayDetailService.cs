using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.Interfaces;
using SystemFlexModel.Models;
using SystemFlexModel.Tools;
using SystemFlexModel.ViewModels;

namespace SystemFlexModel.Service
{
    public class StayDetailService : IStayDetailService
    {
        SHTContext db = new SHTContext();

        public string CreateStayDetail(StayDetailModel Detail)
        {
            Boolean ifExist = false;
            try
            {

                var DetailCreated = db.DetalleHospedaje.FirstOrDefault(a => a.FechaInicial == Detail.InitialDate && a.FechaFinal == Detail.EndDate);

                if (DetailCreated != null)
                {
                    ifExist = true;
                }
             
                var NewDetail = new DetalleHospedaje()
                {
                    UsuarioId = Detail.UserId,
                    CatalogoId = Detail.CatalogId,
                    FechaInicial = Detail.InitialDate,
                    FechaFinal = Detail.EndDate,
                    Dias = Detail.Days,
                    FechaCreacion = Detail.CreationDate
                };
                db.DetalleHospedaje.Add(NewDetail);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            if (ifExist)
            {
                return null;
            }
            else
            {
                return "OK";
            }
        }
    }
}
