using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targi.Core.Domain;
using Targi.Core.Repositories;
using Targi.Infrastructure.Command.JobOffers;
using Targi.Infrastructure.Data;
using Targi.Infrastructure.Dto;
using Targi.Infrastructure.Extensions;
using Targi.Infrastructure.Helpers;
using Targi.Infrastructure.Services.Interfaces;

namespace Targi.Infrastructure.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public JobOfferService(ICompanyRepository companyRepository, IMapper mapper, DataContext context)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _dataContext = context;
        }
        public async Task<Guid> AddJobOfferAsync(Guid userId, JobOfferForUpdate command)
        {
            var company = await _companyRepository.GetCompanyOrFailAsync(userId);
            var jobOffer = company.CompanyProfile.AddJobOffer(command.Category, command.Title, command.Location, 
                           command.WageLow, command.WageHigh, command.Description);
            if (!await _companyRepository.SaveAll())
                throw new Exception("Failed to add job offer");
            return (jobOffer.Id);
        }

        public async Task<bool> UpdateJobOfferAsync(Guid userId, Guid jobId, JobOfferForUpdate jobOfferForUpdate)
        {
            var company = await _companyRepository.GetCompanyOrFailAsync(userId);
            foreach(var jobOffer in company.CompanyProfile.JobOffers)
            {
                if (jobOffer.Id == jobId)
                    _mapper.Map(jobOfferForUpdate, jobOffer);
            }
            return (await _companyRepository.SaveAll());
        }
        public async Task<bool> SetIsPromotedAsync(Guid jobId)
        {
            var jobOffer = await FindJobOfferById(jobId);
            jobOffer.SetIsPromoted();
            return (await _companyRepository.SaveAll());
        }
        public async Task<bool> DeleteJobOfferAsync(Guid userId, Guid jobId)
        {
            var jobOffer = await FindJobOfferById(jobId);
            if (jobOffer.CompanyProfile.UserId != userId)
                throw new Exception("userId is different from userId in token");
            _dataContext.Remove(jobOffer);
            return (await _companyRepository.SaveAll());
        }
        public async Task<IEnumerable<JobOfferForListDto>> GetJobOffersForCompany(Guid userId)
        {
            var company = await _companyRepository.GetCompanyOrFailAsync(userId);
            return _mapper.Map<IEnumerable<JobOfferForListDto>>(company.CompanyProfile.JobOffers);
        }
        public async Task<JobOfferDetailDto> GetDetailJobOfferAsync(Guid jobId)
        {
            var jobOffer = await FindJobOfferById(jobId);
            return _mapper.Map<JobOfferDetailDto>(jobOffer);
        }
        public async Task<bool> UpdatePhotos(Guid userId, Guid jobId, string description, string url)
        {
            var company = await _companyRepository.GetCompanyOrFailAsync(userId);
            var jobOffer = company.CompanyProfile.JobOffers.SingleOrDefault(x => x.Id == jobId);
            jobOffer.UpdatePhotos(description, url);
            return(await _companyRepository.SaveAll());
        }
        public async Task<IEnumerable<JobOfferForListHomeDto>> GetJobOffers(JobOfferParams jobOfferParams)
        {
            var jobOffers = await GetOffers(jobOfferParams);
            return _mapper.Map<IEnumerable<JobOfferForListHomeDto>>(jobOffers);
        }
        private async Task<JobOffer> FindJobOfferById(Guid jobOfferId)
        {
            var jobOffer = await _dataContext.JobOffers.Include(x => x.Photos).Include(x => x.CompanyProfile)
                .ThenInclude(p => p.Photos).SingleOrDefaultAsync(x => x.Id == jobOfferId);
            return jobOffer;
        }

        //DAOs
        private async Task<PagedList<JobOffer>> GetOffers(JobOfferParams jobOfferParams)
        {
            var jobOffers = _dataContext.JobOffers.Include(x => x.CompanyProfile.User)
                .Include(p => p.CompanyProfile).ThenInclude(x => x.Photos)
                .Include(p => p.Photos).AsQueryable();
            jobOffers = jobOffers.Where(x => x.CompanyProfile.User.IsActive);
            if (!string.IsNullOrEmpty(jobOfferParams.JobOfferName))
                jobOffers = jobOffers.Where(x => (x.Title.ToLower().Contains(jobOfferParams.JobOfferName.ToLower())) 
                    || (x.CompanyProfile.CompanyName.ToLower().Contains(jobOfferParams.JobOfferName.ToLower())));
            if (!string.IsNullOrEmpty(jobOfferParams.Category))
                jobOffers = jobOffers.Where(x => x.Category == jobOfferParams.Category);
            return await PagedList<JobOffer>.CreateList(jobOffers, jobOfferParams.PageNumber, jobOfferParams.PageSize);
        }

    }
}
