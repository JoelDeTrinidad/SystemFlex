using AutoMapper;
using SystemFlexModel.Models;
using SystemFlexModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemFlexModel.Tools
{
    public class AutoMapperConfig : Profile
    {
        public override string ProfileName { get { return "AutoMapperConfig"; } }

        protected override void Configure()
        {
            CreateMap<Usuarios, UserModel>()
            .ForMember(a => a.Id, b => b.MapFrom(c => c.UsuarioId))
            .ForMember(a => a.Name, b => b.MapFrom(c => c.Nombres))
            .ForMember(a => a.LastName, b => b.MapFrom(c => c.Apellidos))
            .ForMember(a => a.User, b => b.MapFrom(c => c.Usuario))
            .ForMember(a => a.Password, b => b.MapFrom(c => c.Clave))
            .ForMember(a => a.Email, b => b.MapFrom(c => c.Correo))
            .ForMember(a => a.IsActive, b => b.MapFrom(c => c.Activo))
            .ForMember(a => a.Access, b => b.MapFrom(c => c.UltimoAcceso))
            .ForMember(a => a.comments, b => b.MapFrom(c => c.Observaciones))
            .ForMember(a => a.ImgUrl, b => b.MapFrom(c => c.ImagenUrl));


            CreateMap<Perfiles, RoleModel>()
                .ForMember(a => a.RoleId, b => b.MapFrom(c => c.PerfilId))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Nombre))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.Descripcion));

            CreateMap<PerfilUsuario, RolesUsersModel>()
            .ForMember(a => a.RolesUserId, b => b.MapFrom(c => c.PerfilUsuarioId))
            .ForMember(a => a.User, b => b.MapFrom(c => c.Usuarios))
            .ForMember(a => a.Role, b => b.MapFrom(c => c.Perfiles));

            CreateMap<CatalogoPersonas, PersonsCatalogModel>()
                .ForMember(a => a.IdCatalog, b => b.MapFrom(c => c.CatalogoId))
                .ForMember(a => a.AdultsQuantity, b => b.MapFrom(c => c.CantidadAdultos))
                .ForMember(a => a.RoomQuantity, b => b.MapFrom(c => c.CantidadHabitacion));


            CreateMap<vwDetalleEstancia, VWStayDetail>()
               .ForMember(a => a.DetailId, b => b.MapFrom(c => c.DetalleId))
               .ForMember(a => a.UserId, b => b.MapFrom(c => c.UsuarioId))
               .ForMember(a => a.DateCreation, b => b.MapFrom(c => c.FechaCreacion))
               .ForMember(a => a.InitialDate, b => b.MapFrom(c => c.FechaInicial))
               .ForMember(a => a.EndDate, b => b.MapFrom(c => c.FechaFinal))
               .ForMember(a => a.Days, b => b.MapFrom(c => c.Dias))
               .ForMember(a => a.CatalogId, b => b.MapFrom(c => c.CatalogoId))
               .ForMember(a => a.roomQuantity, b => b.MapFrom(c => c.CantidadHabitaciones))
               .ForMember(a => a.roomQuantityCatalog, b => b.MapFrom(c => c.CantidadPersonaCatalogo));

            CreateMap<Usuarios, LoginModel>()
               .ForMember(a => a.Id, b => b.MapFrom(c => c.UsuarioId))
               .ForMember(a => a.Name, b => b.MapFrom(c => c.Nombres))
               .ForMember(a => a.LastName, b => b.MapFrom(c => c.Apellidos))
               .ForMember(a => a.User, b => b.MapFrom(c => c.Usuario));

            CreateMap<DetalleHospedaje, StayDetailModel>()
                .ForMember(a => a.DetailId, b => b.MapFrom(c => c.DetalleId))
                .ForMember(a => a.UserId, b => b.MapFrom(c => c.UsuarioId))
                .ForMember(a => a.CatalogId, b => b.MapFrom(c => c.CatalogoId))
                .ForMember(a => a.InitialDate, b => b.MapFrom(c => c.FechaInicial))
                .ForMember(a => a.EndDate, b => b.MapFrom(c => c.FechaFinal))
                .ForMember(a => a.Days, b => b.MapFrom(c => c.Dias))
                .ForMember(a => a.CreationDate, b => b.MapFrom(c => c.FechaCreacion));

            CreateMap<CatalogoHabitaciones, CatalogRoomsModel>()
                .ForMember(a => a.RoomId, b => b.MapFrom(c => c.HabitacionId))
                .ForMember(a => a.Information, b => b.MapFrom(c => c.Informacion))
                .ForMember(a => a.Price, b => b.MapFrom(c => c.Precio))
                .ForMember(a => a.ImageHbUrl, b => b.MapFrom(c => c.ImagenHbUrl));

            CreateMap<ComprobanteReservaciones, PaymentCheckModel>()
                .ForMember(a => a.VoucherId, b => b.MapFrom(c => c.ComprobanteId))
                .ForMember(a => a.DetailId, b => b.MapFrom(c => c.DetalleId))
                .ForMember(a => a.UserId, b => b.MapFrom(c => c.UsuarioId))
                .ForMember(a => a.CodeId, b => b.MapFrom(c => c.CodigoId))
                .ForMember(a => a.ExtraId, b => b.MapFrom(c => c.ExtraId))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Nombre))
                .ForMember(a => a.LastName, b => b.MapFrom(c => c.Apellidos))
                .ForMember(a => a.Email, b => b.MapFrom(c => c.Correo))
                .ForMember(a => a.TotalPayment, b => b.MapFrom(c => c.PagoTotal))
                .ForMember(a => a.Payed, b => b.MapFrom(c => c.Pagado))
                .ForMember(a => a.Reserved, b => b.MapFrom(c => c.HabitacionesReservadas))
                .ForMember(a => a.PaymentTransaction, b => b.MapFrom(c => c.TransaccionPago));

            CreateMap<HabitacionesReservadas,ReservedRoomModel>()
                .ForMember(a => a.ReservationId, b => b.MapFrom(c => c.ReservacionId))
                .ForMember(a => a.RoomId, b => b.MapFrom(c => c.HabitacionId))
                .ForMember(a => a.CheckId, b => b.MapFrom(c => c.ComprobanteId));

            CreateMap<TransaccionPago, PaymentTransactionModel>()
                .ForMember(a => a.PaymentId, b => b.MapFrom(c => c.PagoId))
                .ForMember(a => a.CheckId, b => b.MapFrom(c => c.ComprobanteId))
                .ForMember(a => a.NumberCard, b => b.MapFrom(c => c.NumeroTarjeta))
                .ForMember(a => a.Expiration, b => b.MapFrom(c => c.FechaCaducidad))
                .ForMember(a => a.Code, b => b.MapFrom(c => c.CodigoSeguridad));
        }

    }
}
