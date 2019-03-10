using AutoMapper;
using SystemFlexWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemFlexWebApi.App_Start
{
    public class AutoMapperWebConfig : Profile
    {
        public override string ProfileName { get { return "AutoMapperConfig"; } }
        protected override void Configure()
        {
            CreateMap<SystemFlexModel.ViewModels.UserModel, UserModel>();
            CreateMap<SystemFlexModel.ViewModels.RoleModel, RoleModel>();
            CreateMap<SystemFlexModel.ViewModels.PersonsCatalogModel, PersonsCatalogModel>();
            CreateMap<SystemFlexModel.ViewModels.RolesUsersModel, RolesUsersModel>();
            CreateMap<SystemFlexModel.ViewModels.VWStayDetail, VWStayDetail>();
            CreateMap<SystemFlexModel.ViewModels.StayDetailModel, StayDetailModel>();
            CreateMap<SystemFlexModel.ViewModels.CatalogRoomsModel, CatalogRoomsModel>();
            CreateMap<SystemFlexModel.ViewModels.PaymentCheckModel, PaymentCheckModel>();
            CreateMap<SystemFlexModel.ViewModels.ReservedRoomModel, ReservedRoomModel>();
            CreateMap<SystemFlexModel.ViewModels.PaymentTransactionModel, PaymentTransactionModel>();

            CreateMap<UserModel, SystemFlexModel.ViewModels.UserModel>();
            CreateMap<RoleModel, SystemFlexModel.ViewModels.RoleModel>();
            CreateMap<RolesUsersModel, SystemFlexModel.ViewModels.RolesUsersModel>();
            CreateMap<PersonsCatalogModel, SystemFlexModel.ViewModels.PersonsCatalogModel>();
            CreateMap<VWStayDetail, SystemFlexModel.ViewModels.VWStayDetail>();
            CreateMap<StayDetailModel, SystemFlexModel.ViewModels.StayDetailModel>();
            CreateMap<CatalogRoomsModel, SystemFlexModel.ViewModels.CatalogRoomsModel>();
            CreateMap<PaymentCheckModel, SystemFlexModel.ViewModels.PaymentCheckModel>();
            CreateMap<ReservedRoomModel, SystemFlexModel.ViewModels.ReservedRoomModel>();
            CreateMap<PaymentTransactionModel, SystemFlexModel.ViewModels.PaymentTransactionModel>();
        }
    }
}