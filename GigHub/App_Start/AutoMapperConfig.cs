using AutoMapper;
using GigHub.Core.Dtos;
using GigHub.Core.Models;

namespace GigHub
{
    public class AutoMapperConfig 
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Gig, GigDto>();
                cfg.CreateMap<ApplicationUser, UserDto>();
                cfg.CreateMap<Notification, NotificationDto>();
            });
        }
    }
}