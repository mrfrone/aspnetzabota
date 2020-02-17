using AutoMapper;
using aspnetzabota.Common.AutoMapper.Extensions;
using aspnetzabota.Content.Datamodel.Department;
using aspnetzabota.Content.Datamodel.License;
using aspnetzabota.Content.Datamodel.News;
using aspnetzabota.Content.Datamodel.Review;
using aspnetzabota.Content.Datamodel.Slider;

namespace aspnetzabota.Content.Datamodel.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Entities.Department, ZabotaDepartment>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.ID))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.ShortName, opts => opts.MapFrom(u => u.ShortName))
                .ForMember(u => u.IMG, opts => opts.MapFrom(u => u.IMG))
                .ForMember(u => u.Description, opts => opts.MapFrom(u => u.Description))
                .ForMember(u => u.DepartmentPriceID, opts => opts.MapFrom(u => u.DepartmentPriceID));

            CreateMap<Database.Entities.Licenses, ZabotaLicenses>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.name))
                .ForMember(u => u.Photo, opts => opts.MapFrom(u => u.photo));

            CreateMap<Database.Entities.LicensesPhoto, ZabotaLicensesPhoto>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.id))
                .ForMember(u => u.Path, opts => opts.MapFrom(u => u.path));

            CreateMap<Database.Entities.News, ZabotaNews>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.ID))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.Description, opts => opts.MapFrom(u => u.Description))
                .ForMember(u => u.IMG, opts => opts.MapFrom(u => u.IMG))
                .ForMember(u => u.Date, opts => opts.MapFrom(u => u.Date))
                .ForMember(u => u.CategoryID, opts => opts.MapFrom(u => u.categoryID))
                .ForMember(u => u.Category, opts => opts.MapFrom(u => u.Category));

            CreateMap<Database.Entities.Review, ZabotaReview>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.id))
                .ForMember(u => u.Author, opts => opts.MapFrom(u => u.author))
                .ForMember(u => u.Email, opts => opts.MapFrom(u => u.email))
                .ForMember(u => u.Text, opts => opts.MapFrom(u => u.text))
                .ForMember(u => u.Date, opts => opts.MapFrom(u => u.date));

            CreateMap<Database.Entities.Slider, ZabotaSlider>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.ID))
                .ForMember(u => u.Image, opts => opts.MapFrom(u => u.image));
            CreateMap<Database.Entities.Category, ZabotaCategory>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.ID))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.News, opts => opts.MapFrom(u => u.news));
        }
    }
}