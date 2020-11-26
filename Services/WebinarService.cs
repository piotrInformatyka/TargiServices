using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targi.Core.Domain;
using Targi.Core.Repositories;
using Targi.Infrastructure.Command;
using Targi.Infrastructure.Data;
using Targi.Infrastructure.Dto;
using Targi.Infrastructure.Extensions;
using Targi.Infrastructure.Services.Interfaces;

namespace Targi.Infrastructure.Services
{
    public class WebinarService : IWebinarService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public WebinarService(ICompanyRepository companyRepository, IMapper mapper, DataContext contex)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _dataContext = contex;
        }
        public async Task<Guid> AddWebinarAsync(Guid userId, WebinarForUpdate command)
        {
            var company = await _companyRepository.GetCompanyOrFailAsync(userId);
            var webinar = company.CompanyProfile.AddWebinar(command.Title, command.Description, command.WebinarUrl, command.StartDateOfTheEvent, command.EndDateOfTheEvent);
            if (!await _companyRepository.SaveAll())
                throw new Exception("Failed to add webinar");
            return (webinar.Id);
        }
        public async Task<bool> UpdateWebinarAsync(Guid webinarId, WebinarForUpdate webinarForUpdate)
        {
            var webinar = await FindWebinarById(webinarId);
            _mapper.Map(webinarForUpdate, webinar);
            return await _dataContext.SaveChangesAsync() > 0;
        }
        public async Task<WebinarDetailDto> GetWebinarDetailAsync(Guid webinarId)
        {
            var webinar = await FindWebinarById(webinarId);
            return _mapper.Map<WebinarDetailDto>(webinar);
        }
        public async Task<IEnumerable<WebinarForListDto>> GetWebinarsAsync()
        {
            var webinars = await GetAllWebinarsDAO();
            return _mapper.Map<IEnumerable<WebinarForListDto>>(webinars);
        }
        public async Task<bool> UpdatePhotos(Guid webinarId, string description, string url)
        {
            var webinar = await FindWebinarById(webinarId);
            webinar.UpdatePhotos(description, url);
            return (await _companyRepository.SaveAll());
        }
        public async Task<bool> DeleteWebinar(Guid webinarId)
        {
            var webinar = await FindWebinarById(webinarId);
            _dataContext.Remove(webinar);
            return (await _companyRepository.SaveAll());
        }

        //DAOs
        private async Task<Webinar> FindWebinarById(Guid webinarId)
        {
            var webinar = await _dataContext.Webinars.Include(x => x.Photos)
                .Include(x => x.CompanyProfile).ThenInclude(p => p.Photos).SingleOrDefaultAsync(x => x.Id == webinarId);
            return webinar;
        }
        private async Task<IEnumerable<Webinar>> GetAllWebinarsDAO()
        {
            var webinars = await _dataContext.Webinars.Include(x => x.CompanyProfile).Include(x => x.Photos).ToListAsync();
            return webinars;
        }

    }
}
