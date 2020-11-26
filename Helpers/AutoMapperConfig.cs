using AutoMapper;
using AutoMapper.EquivalencyExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Targi.Core.Domain;
using Targi.Infrastructure.Command;
using Targi.Infrastructure.Command.Companies;
using Targi.Infrastructure.Command.JobOffers;
using Targi.Infrastructure.Dto;
using Targi.Infrastructure.Dto.Companies;

namespace Targi.Infrastructure.Helpers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.AddCollectionMappers();
                //models => modelsDTO
                
                //BENEFITS
                cfg.CreateMap<BenefitCard, BenefitCardDto>();
                //SOCIALS
                cfg.CreateMap<Social, SocialDto>();
                cfg.CreateMap<Social, SocialDto>();
                //COMPANY PROFILES
                cfg.CreateMap<CompanyProfile, CompanyProfileDto>();
                cfg.CreateMap<User, CompanyProfileForListDto>()
                    .ForMember(x => x.UserId, m => m.MapFrom(p => p.Id))
                    .ForMember(x => x.CompanyName, m => m.MapFrom(p => p.CompanyProfile.CompanyName))
                    .ForMember(x => x.LogoUrl, m => m.MapFrom(p => p.CompanyProfile.Photos.SingleOrDefault(x => x.Description == "logo").Url))
                    .ForMember(x => x.BackgroundUrl, m => m.MapFrom(p => p.CompanyProfile.Photos.SingleOrDefault(x => x.Description == "bg_img").Url));
                cfg.CreateMap<User, CompanyProfileForListModeratorDto>()
                    .ForMember(x => x.UserId, m => m.MapFrom(p => p.Id))
                    .ForMember(x => x.CompanyName, m => m.MapFrom(p => p.CompanyProfile.CompanyName))
                    .ForMember(x => x.LogoUrl, m => m.MapFrom(p => p.CompanyProfile.Photos.SingleOrDefault(x => x.Description == "logo").Url))
                    .ForMember(x => x.CompanyStatus, m => m.MapFrom(p => p.CompanyProfile.CompanyStatus))
                    .ForMember(x => x.DayOfParticipation, m => m.MapFrom(p => p.CompanyProfile.DayOfParticipation))
                    .ForMember(x => x.ContactPerson, m => m.MapFrom(p => p.CompanyProfile.ContactPerson))
                    .ForMember(x => x.PhoneNumber, m => m.MapFrom(p => p.CompanyProfile.PhoneNumber))
                    .ForMember(x => x.MaxJobOffers, m => m.MapFrom(p => p.CompanyProfile.MaxJobOffers));
                //USERS
                cfg.CreateMap<User, UserCompanyDetailDto>()
                    .ForMember(x => x.CompanyProfile, m => m.MapFrom(p => p.CompanyProfile));
                cfg.CreateMap<User, CompanyForAcceptDto>()
                    .ForMember(x => x.CompanyName, m => m.MapFrom(p => p.CompanyProfile.CompanyName))
                    .ForMember(x => x.PhoneNumber, m => m.MapFrom(p => p.CompanyProfile.PhoneNumber))
                    .ForMember(x => x.ContactPerson, m => m.MapFrom(p => p.CompanyProfile.ContactPerson));
                //JOB OFFERS
                cfg.CreateMap<JobOffer, JobOfferForListDto>()
                    .ForMember(x => x.CompanyName, m => m.MapFrom(p => p.CompanyProfile.CompanyName))
                    .ForMember(x => x.UserId, m => m.MapFrom(p => p.CompanyProfile.UserId))
                    .ForMember(x => x.LogoUrl, m => m.MapFrom(p => p.CompanyProfile.Photos.SingleOrDefault(x => x.Description == "logo").Url));
                cfg.CreateMap<JobOffer, JobOfferDetailDto>()
                   .ForMember(x => x.CompanyName, m => m.MapFrom(p => p.CompanyProfile.CompanyName))
                   .ForMember(x => x.UserId, m => m.MapFrom(p => p.CompanyProfile.UserId))
                   .ForMember(x => x.LogoUrl, m => m.MapFrom(p => p.CompanyProfile.Photos.SingleOrDefault(x => x.Description == "logo").Url));
                cfg.CreateMap<JobOffer, JobOfferForListHomeDto>()
                    .ForMember(x => x.CompanyName, m => m.MapFrom(p => p.CompanyProfile.CompanyName))
                    .ForMember(x => x.UserId, m => m.MapFrom(p => p.CompanyProfile.UserId))
                    .ForMember(x => x.LogoUrl, m => m.MapFrom(p => p.CompanyProfile.Photos.SingleOrDefault(x => x.Description == "logo").Url));
                //WEBINARS
                cfg.CreateMap<Webinar, WebinarDetailDto>()
                    .ForMember(x => x.UserId, m => m.MapFrom(p => p.CompanyProfile.UserId))
                    .ForMember(x => x.CompanyName, m => m.MapFrom(p => p.CompanyProfile.CompanyName))
                    .ForMember(x => x.LogoCompanyUrl, m => m.MapFrom(p => p.CompanyProfile.Photos.SingleOrDefault(x => x.Description == "logo").Url));
                cfg.CreateMap<Webinar, WebinarForListDto>()
                    .ForMember(x => x.UserId, m => m.MapFrom(p => p.CompanyProfile.UserId))
                    .ForMember(x => x.BackgroundUrl, m => m.MapFrom(p => p.Photos.SingleOrDefault(x => x.Description == "bg_img").Url))
                    .ForMember(x => x.CompanyName, m => m.MapFrom(p => p.CompanyProfile.CompanyName));
                //PHOTOS
                cfg.CreateMap<Photo, PhotoDto>();
                
                
                
               // commandsForUpdate => model
                cfg.CreateMap<CompanyForUpdate, CompanyProfile>()
                    .ForMember(model => model.JobOffers, opt => opt.Ignore())
                    .ForMember(model => model.CompanyName, opt => opt.Ignore());
                cfg.CreateMap<SocialForUpdate, Social>()
                    .EqualityComparison((src, dst) => src.Id == dst.Id);
                cfg.CreateMap<BenefitCardForUpdate, BenefitCard>()
                    .EqualityComparison((src, dst) => src.Id == dst.Id);
                cfg.CreateMap<JobOfferForUpdate, JobOffer>();
                cfg.CreateMap<WebinarForUpdate, Webinar>();
               
            }).CreateMapper();
    }
}
