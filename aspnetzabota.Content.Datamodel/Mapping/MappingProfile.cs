using AutoMapper;
using aspnetzabota.Common.AutoMapper.Extensions;
using aspnetzabota.Content.Datamodel.Department;
using aspnetzabota.Content.Datamodel.License;
using aspnetzabota.Content.Datamodel.Articles;
using aspnetzabota.Content.Datamodel.Review;
using aspnetzabota.Content.Datamodel.Slider;
using aspnetzabota.Content.Datamodel.Price;

namespace aspnetzabota.Content.Datamodel.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Entities.Department, ZabotaDepartment>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.ShortName, opts => opts.MapFrom(u => u.ShortName))
                .ForMember(u => u.IMG, opts => opts.MapFrom(u => u.Img))
                .ForMember(u => u.Description, opts => opts.MapFrom(u => u.Description))
                .ForMember(u => u.DepartmentPriceID, opts => opts.MapFrom(u => u.DepartmentPriceID))
                .ForMember(u => u.Articles, opts => opts.MapFrom(u => u.Articles));

            CreateMap<Database.Entities.Licenses, ZabotaLicenses>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.Photo, opts => opts.MapFrom(u => u.Photo));

            CreateMap<Database.Entities.LicensesPhoto, ZabotaLicensesPhoto>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Path, opts => opts.MapFrom(u => u.Path));

            CreateMap<Database.Entities.Articles, ZabotaArticles>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.Description, opts => opts.MapFrom(u => u.Description))
                .ForMember(u => u.IMG, opts => opts.MapFrom(u => u.Img))
                .ForMember(u => u.Date, opts => opts.MapFrom(u => u.Date))
                .ForMember(u => u.CategoryID, opts => opts.MapFrom(u => u.CategoryID))
                .ForMember(u => u.Category, opts => opts.MapFrom(u => u.Category))
                .ForMember(u => u.DepartmentId, opts => opts.MapFrom(u => u.DepartmentId));

            CreateMap<Database.Entities.Review, ZabotaReview>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Author, opts => opts.MapFrom(u => u.Author))
                .ForMember(u => u.Email, opts => opts.MapFrom(u => u.Email))
                .ForMember(u => u.Text, opts => opts.MapFrom(u => u.Text))
                .ForMember(u => u.Date, opts => opts.MapFrom(u => u.Date));

            CreateMap<Database.Entities.Slider, ZabotaSlider>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Image, opts => opts.MapFrom(u => u.Image));

            CreateMap<Database.Entities.Category, ZabotaCategory>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.ID))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.News, opts => opts.MapFrom(u => u.news));

            CreateMap<Database.Entities.PriceArticles, ZabotaPriceArticles>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.PriceId, opts => opts.MapFrom(u => u.PriceId))
                .ForMember(u => u.Article, opts => opts.MapFrom(u => u.Article));
        }
    }
}