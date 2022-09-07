using AutoMapper;
using SignalRBackend.BLL.DTO;
using SignalRBackend.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.WEB.Configurations.MappingConfig
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<LoginViewModel, LoginDTO>().ReverseMap();
            CreateMap<AuthenticatedResponseViewModel, AuthenticatedResponseDTO>().ReverseMap();
        }
    }
}
