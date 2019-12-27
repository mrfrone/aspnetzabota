using AutoMapper;
using aspnetzabota.Admin.Database.Entities;
using aspnetzabota.Admin.Datamodel.Tokens;
using aspnetzabota.Common.AutoMapper.Extensions;

namespace aspnetzabota.Admin.Datamodel.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Jwts, Jwt>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Token, opts => opts.MapFrom(u => u.Token))
                .ForMember(u => u.Expires, opts => opts.MapFrom(u => u.Expires));

            //CreateMap<Database.Entities.Identities, LazuritIdentity>()
            //    .IgnoreOther()
            //    .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
            //    .ForMember(u => u.Login, opts => opts.MapFrom(u => u.Login))
            //    .ForMember(u => u.IsBanned, opts => opts.MapFrom(u => u.IsBanned));

            //CreateMap<Database.Entities.UsersProfiles, LazuritUserProfile>()
            //    .IgnoreOther()
            //    .ForMember(u => u.IdentityId, opts => opts.MapFrom(u => u.IdentityId))
            //    .ForMember(u => u.FirstName, opts => opts.MapFrom(u => u.FirstName))
            //    .ForMember(u => u.PatronymicName, opts => opts.MapFrom(u => u.PatronymicName))
            //    .ForMember(u => u.LastName, opts => opts.MapFrom(u => u.LastName))
            //    .ForMember(u => u.Email, opts => opts.MapFrom(u => u.Email))
            //    .ForMember(u => u.Phone, opts => opts.MapFrom(u => u.Identity.Login))
            //    .ForMember(u => u.IsBanned, opts => opts.MapFrom(u => u.Identity.IsBanned));

        }
    }
}