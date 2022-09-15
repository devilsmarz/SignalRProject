using AutoMapper;
using SignalRBackend.BLL.DTO;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.WEB.ViewModels;

namespace SignalRBackend.WEB.Configurations.MappingConfig
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<LoginViewModel, LoginDTO>().ReverseMap();
            CreateMap<AuthenticatedResponseViewModel, AuthenticatedResponseDTO>().ReverseMap();
            CreateMap<MessageViewModel, MessageDTO>().ReverseMap();
            CreateMap<MessageDTO, Message>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<ChatDTO, Chat>().ReverseMap();
            CreateMap<UserViewModel, UserDTO>().ReverseMap();
            CreateMap<ChatViewModel, ChatDTO>().ReverseMap();
            CreateMap<PageInfoViewModel, PageInfoDTO>().ReverseMap();
        }
    }
}
