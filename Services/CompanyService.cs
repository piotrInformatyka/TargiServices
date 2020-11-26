
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Targi.Core.Domain;
using Targi.Core.Repositories;
using Targi.Infrastructure.Dto;
using System.Linq;
using Targi.Infrastructure.Command.Companies;
using Targi.Infrastructure.Extensions;
using Targi.Infrastructure.Dto.Companies;
using Targi.Infrastructure.Command;

namespace Targi.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;

        }
        public async Task<CompanyProfileDto> GetCompanyAsync(Guid userId)
        {
            var user = await _companyRepository.GetCompanyOrFailAsync(userId);
            return _mapper.Map<CompanyProfileDto>(user.CompanyProfile);
        }
        public async Task<IEnumerable<CompanyProfileForListDto>> GetCompaniesForList()
        {
            var users = await _companyRepository.GetCompaniesForList();
            return _mapper.Map<IEnumerable<CompanyProfileForListDto>>(users);
        }
        public async Task<IEnumerable<CompanyProfileForListModeratorDto>> GetAllForModerator()
        {
            var users = await _companyRepository.GetAllForModerator();
            users = users.Where(x => x.Role == "company");
            return _mapper.Map<IEnumerable<CompanyProfileForListModeratorDto>>(users);
        }
        public async Task<IEnumerable<CompanyForAcceptDto>> GetNotAcceptedCompaniesAsync()
        {
            var users = await _companyRepository.GetAllAsync();
            var usersToReturn = users.Where(x => x.Role == "company").Where(x => x.IsActive == false).Where(x => x.IsCompany == false);
            return _mapper.Map<IEnumerable<CompanyForAcceptDto>>(usersToReturn);
        }
        public async Task<IEnumerable<CompanyForAcceptDto>> GetDeactivatedCompaniesAsync()
        {
            var users = await _companyRepository.GetAllAsync();
            var usersToReturn = users.Where(x => x.Role == "company").Where(x => x.IsActive == false).Where(x => x.IsCompany == true);
            return _mapper.Map<IEnumerable<CompanyForAcceptDto>>(usersToReturn);
        }
        public async Task<bool> UpdateCompany(Guid userId, CompanyForUpdate companyForUpdate)
        {
            var company = await _companyRepository.GetCompanyOrFailAsync(userId);
            _mapper.Map(companyForUpdate, company.CompanyProfile);
            company.SetIsCompany();
            return (await _companyRepository.SaveAll());
        }
        public async Task UpdatePhotos(Guid userId, Guid photoId, string description, string url)
        {
            var company = await _companyRepository.GetCompanyOrFailAsync(userId);
            company.CompanyProfile.UpdatePhotos(description, url);
            await _companyRepository.SaveAll();

        }
    }
}
