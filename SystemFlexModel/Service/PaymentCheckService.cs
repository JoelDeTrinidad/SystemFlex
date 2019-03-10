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
    public class PaymentCheckService : IPaymentCheckService
    {
        SHTContext db = new SHTContext();



        public string MakePayment(PaymentCheckModel PaymentData)
        {
            Boolean ifExist = false;
            try
            {

                var PaymentCreated = db.ComprobanteReservaciones.FirstOrDefault(a => a.DetalleId == PaymentData.DetailId && a.UsuarioId == PaymentData.UserId);

                if (PaymentCreated != null)
                {
                    ifExist = true;
                }
                else
                {
                    //process to save reserve
                    var NewPayment = new ComprobanteReservaciones()
                    {
                        DetalleId = PaymentData.DetailId,
                        UsuarioId = PaymentData.UserId,
                        CodigoId = PaymentData.CodeId,
                        ExtraId = PaymentData.ExtraId,
                        Nombre = PaymentData.Name,
                        Apellidos = PaymentData.LastName,
                        Correo = PaymentData.Email,
                        PagoTotal = PaymentData.TotalPayment,
                        Pagado = PaymentData.Payed
                    };
                    db.ComprobanteReservaciones.Add(NewPayment);
                    db.SaveChanges();
                    var Id = NewPayment.ComprobanteId;

                    //process to pay
                    var NewTransaction = new TransaccionPago()
                    {
                        ComprobanteId = Id,
                        NumeroTarjeta = PaymentData.PaymentTransaction.NumberCard,
                        FechaCaducidad = PaymentData.PaymentTransaction.Expiration,
                        CodigoSeguridad = PaymentData.PaymentTransaction.Code
                    };
                    db.TransaccionPago.Add(NewTransaction);
                    db.SaveChanges();

                    //process to reserver the room(s)
                    foreach (var items in PaymentData.CatalogRoom)
                    {
                        var NewReserve = new HabitacionesReservadas()
                        {
                            ComprobanteId = Id,
                            HabitacionId = items.RoomId
                        };
                        db.HabitacionesReservadas.Add(NewReserve);
                    }
                    db.SaveChanges();
                }
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
