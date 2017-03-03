using AutoMapper;
using FinessaAesthetica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinessaAesthetica
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {           
            Mapper.CreateMap<LoginViewModel, Users>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));


            Mapper.CreateMap<BranchInventory, MainInventory>()
                .ForMember(dest => dest.MaximumThreshold, opt => opt.MapFrom(src => src.MaximumThreshold))
                .ForMember(dest => dest.MinimumThreshold, opt => opt.MapFrom(src => src.MinimumThreshold))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            //Mapper.CreateMap<SystemUser, PortalUser>()
            //    .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.FullName))
            //    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.DomainName))
            //    .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.SystemUserId))
            //    .ForMember(dest => dest.BusinessUnitID, opt => opt.MapFrom(src => src.BusinessUnitId.Id))
            //    .ForMember(dest => dest.BusinessUnit, opt => opt.MapFrom(src => src.BusinessUnitId))
            //    .ForMember(dest => dest.PositionID, opt => opt.MapFrom(src => src.PositionId.Id))
            //    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.PositionId));
        }
    }
}