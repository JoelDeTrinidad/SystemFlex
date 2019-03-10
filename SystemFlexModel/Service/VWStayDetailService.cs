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
    public class VWStayDetailService : IVWStayDetailService
    {
        SHTContext db = new SHTContext();

        public List<VWStayDetail> Getview()
        {
            try
            {
                var vwList = db.vwDetalleEstancia.ToList();
                return Mapper.Map<List<vwDetalleEstancia>, List<VWStayDetail>>(vwList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public void DeleteStayDetail(int Id)
        {
            try
            {
                var DeleteStayDetail = db.DetalleHospedaje.SingleOrDefault(a => a.DetalleId == Id);
                db.DetalleHospedaje.Remove(DeleteStayDetail);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


    }
}
