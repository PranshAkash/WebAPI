using AutoMapper;
using Data.Sources;

namespace Services.Identity
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<UserData, ApplicationUser>();
            CreateMap<ApplicationUser, UserData>();
        }
    }
}
